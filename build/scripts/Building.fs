﻿namespace Scripts

open System.IO

open Paths
open Projects
open Tooling
open Versioning
open Fake.Core
open Fake.IO
open Fake.IO
open Fake.IO.Globbing.Operators
open System.Xml
open System.Xml.Linq
open System.Xml.XPath
open System.IO.Compression

module Build =

    let Restore() = DotNet.Exec ["restore"; Solution; ] |> ignore
        
    let Compile args version = 
        let props = 
            [ 
                "CurrentVersion", (version.Full.ToString());
                "CurrentAssemblyVersion", (version.Assembly.ToString());
                "CurrentAssemblyFileVersion", (version.AssemblyFile.ToString());
            ] 
            |> List.map (fun (p,v) -> sprintf "%s=%s" p v)
            |> String.concat ";"
            |> sprintf "/property:%s"
            
        DotNet.Exec ["build"; Solution; "-c"; "Release"; props] |> ignore

    let Pack version = 
        let props = 
            [ 
                "CurrentVersion", (version.Full.ToString());
                "CurrentAssemblyVersion", (version.Assembly.ToString());
                "CurrentAssemblyFileVersion", (version.AssemblyFile.ToString());
            ] 
            |> List.map (fun (p,v) -> sprintf "%s=%s" p v)
            |> String.concat ";"
            |> sprintf "/p:%s"
            
        DotNet.Exec ["pack"; Solution; "-c"; "Release"; "-o"; Paths.NugetOutput ; props] |> ignore

    let Clean isCanary =
        printfn "Cleaning known output folders"
        Shell.cleanDir Paths.BuildOutput
        if isCanary then 
            DotNet.Exec ["clean"; Solution; "-c"; "Release"; "-v"; "q"] |> ignore 
            DotNetProject.All |> Seq.iter(fun p -> Shell.cleanDir (Paths.BinFolder p.Name))
            
            
    let private assemblyRewriter = "assembly-rewriter"
    let private keyFile = Paths.Keys "keypair.snk"
    let private tmp = "build/output/_packages/tmp" 
    
    let VersionedPack version =
        let packages = Versioning.BuiltArtifacts version
        let currentMajorVersion = version.Full.Major
        
        let newId nugetId = sprintf "%s.v%i" nugetId currentMajorVersion
        let replaceId nugetId str = str |> String.replace nugetId (newId nugetId)
        
        let updatePackage package nugetId = 
            let nuspec = !! (sprintf "%s/*.nuspec" tmp) |> Seq.head
            printfn "Validating: %s => %s" package nuspec
            let xName n = XName.op_Implicit n
            use stream = File.OpenRead <| nuspec 
            let doc = XDocument.Load(stream) 
            let nsManager = new XmlNamespaceManager(doc.CreateNavigator().NameTable);
            nsManager.AddNamespace("x", "http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd")
            
            doc.XPathSelectElement("/x:package/x:metadata/x:id", nsManager).Value <- newId nugetId
            let titleNode = doc.XPathSelectElement("/x:package/x:metadata/x:title", nsManager) 
            titleNode.Value <- sprintf "%i.x namespaced package, can be installed alongside %s" currentMajorVersion nugetId
            let descriptionNode = doc.XPathSelectElement("/x:package/x:metadata/x:description", nsManager) 
            descriptionNode.Value <- sprintf "%i.x namespaced package, can be installed alongside %s" currentMajorVersion nugetId
            let iconNode = doc.XPathSelectElement("/x:package/x:metadata/x:iconUrl", nsManager) 
            iconNode.Value <- iconNode.Value.Replace("icon", "icon-aux")
            let iconNode = doc.XPathSelectElement("/x:package/x:metadata/x:icon", nsManager) 
            iconNode.Value <- iconNode.Value.Replace("icon", "icon-aux")
            
            let deps =
                doc.XPathSelectElements("/x:package//x:dependency", nsManager)
                |> Seq.map (fun e -> e.Attribute(xName "id").Value)
                |> Seq.filter (fun id -> packages |> Seq.exists (fun p -> p.NugetId = id))
                |> Seq.toList
                
            // update dependencies we've built to their versioned counterparts
            doc.XPathSelectElements("/x:package//x:dependency", nsManager)
            |> Seq.map (fun e -> (e, e.Attribute(xName "id").Value))
            // filter packages that exist in the build output folder `tmp`
            |> Seq.filter (fun (e, id) -> packages |> Seq.exists (fun p -> p.NugetId = id))
            |> Seq.iter (fun (e, id) -> e.Attribute(xName "id").Value <- newId id)
            
            doc.Save(nuspec |> replaceId nugetId)
            stream.Dispose()
            Shell.rm nuspec
            
            deps
            
            
        let rewriteLibFolder libFolder project nugetId dependencies = 
            let info = DirectoryInfo libFolder
            let tfm = info.Name
            let fullPath = Path.GetFullPath libFolder
            
            let mainDll = sprintf "%s.dll" (Path.Combine(fullPath, project)) 
            let renamedDll dll = dll |> String.replace ".dll" (sprintf "%i.dll" version.Full.Major)
            
            printfn "dll: %s Nuget id: %s dependencies: %A" mainDll nugetId dependencies
            let depAssemblies =
                dependencies
                |> Seq.map (fun d -> sprintf "%s.dll" (Path.Combine(Paths.InplaceBuildOutput project tfm, d)))
            let dlls =
               [mainDll]
               |> Seq.append depAssemblies
               |> Seq.map (fun dll ->
                   sprintf @"-i ""%s"" -o ""%s"" " dll (renamedDll dll)
               )
               |> Seq.fold (+) " "
           
            Tooling.DotNet.ExecIn "." [assemblyRewriter; dlls] |> ignore
           
            let rewrittenDll = renamedDll mainDll 
            let ilMergeArgs = [
                "/internalize"; 
                (sprintf "/lib:%s" (Paths.InplaceBuildOutput project tfm)); 
                (sprintf "/keyfile:%s" keyFile); 
                (sprintf "/out:%s" rewrittenDll)
            ]
                
            Tooling.ILRepack.Exec (ilMergeArgs |> List.append [rewrittenDll])
            Shell.rm mainDll
            let mainPdb = sprintf "%s.pdb" (Path.Combine(fullPath, project))
            if File.exists mainPdb then Shell.rm mainPdb
        
        packages
        |> Seq.iter(fun p ->
            
            Zip.unzip tmp p.Package
            let nugetId = p.NugetId
            let project = p.AssemblyName
            
            //update nuget metadata
            let deps = updatePackage p.Package nugetId

            //rewrite assemblies to versioned counterparts
            let dependentAssemblies =
                let injectEsNet = 
                    match deps |> Seq.contains "NEST" with
                    | true -> List.append deps ["Elasticsearch.Net"]
                    | false -> deps
                injectEsNet
                |> Seq.map (fun id ->
                    let p = packages |> Seq.find (fun p -> p.NugetId = id)
                    p.AssemblyName
                )
                |> Seq.distinct
            
            let directories = Directory.GetDirectories <| sprintf "%s/lib" tmp
            directories
            |> Seq.iter (fun libFolder -> rewriteLibFolder libFolder project nugetId dependentAssemblies)
                
            //Repackage
            let versionedPackage = p.Package |> replaceId nugetId 
            ZipFile.CreateFromDirectory(tmp, versionedPackage)
            printfn "Created %s" versionedPackage
            
            Directory.delete tmp
        )
        
         