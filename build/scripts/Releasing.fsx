﻿#I @"../../packages/build/FAKE/tools"
#I @"../../packages/build/FSharp.Data/lib/net40"
#r @"FakeLib.dll"
#r @"FSharp.Data.dll"
#load @"Paths.fsx"
#load @"Projects.fsx"
#load @"Versioning.fsx"
#load @"Building.fsx"
open System
open System.IO
open Fake 
open Paths
open Projects
open Versioning
open Building
open FSharp.Data

// TODO: Use a complete project.json skeleton
type ProjectJson = JsonProvider<"../../src/Nest/project.json">

type Release() = 
    static let nugetPack = fun (projectName: ProjectName) ->
        let name = projectName.Nuget;
        CreateDir Paths.NugetOutput
        let package = (sprintf @"build\%s.nuspec" name)
        let packageContents = ReadFileAsString package
        let re = @"(?<start>\<version\>|""(Elasticsearch.Net|Nest)"" version="")[^""><]+(?<end>\<\/version\>|"")"
        let replacedContents = regex_replace re (sprintf "${start}%s${end}" Versioning.FileVersion) packageContents
        WriteStringToFile false package replacedContents
    
        let dir = sprintf "%s/%s/" Paths.BuildOutput name
        let nugetOutFile =  Paths.Output(sprintf "%s/%s.%s.nupkg" name name Versioning.FileVersion);
        NuGetPack (fun p ->
          {p with 
            Version = Versioning.FileVersion
            WorkingDir = "build" 
            OutputPath = dir
          })
          package
        traceFAKE "%s" dir
        MoveFile Paths.NugetOutput nugetOutFile

    static let updateVersion project =
        CreateDir Paths.NugetOutput
        use file = File.Open (project, FileMode.Open)
        let doc = ProjectJson.Load file

        let newDoc = ProjectJson.Root(
                        doc.Authors, 
                        doc.Owners, 
                        doc.ProjectUrl, 
                        doc.LicenseUrl,
                        doc.RequireLicenseAcceptance, 
                        doc.IconUrl, 
                        doc.Summary, 
                        doc.Description, 
                        doc.Title, 
                        doc.Tags,
                        doc.Repository,
                        doc.Copyright,
                        Versioning.FileVersion,
                        doc.CompilationOptions,
                        doc.Configurations,
                        doc.Dependencies,
                        doc.Commands,
                        doc.Frameworks)
        
        file.Close ()
        File.Delete project
        use writer = new StreamWriter(File.Open (project, FileMode.Create))
        newDoc.JsonValue.WriteTo(writer, JsonSaveOptions.None)

    static member PackAll() =
        DotNetProject.All
        |> Seq.map (fun p -> p.ProjectName)
        |> Seq.iter(fun p -> nugetPack p)

    static member PackAllDnx() =
        let projects = !! "src/Nest/project.json" 
                       ++ "src/Elasticsearch.Net/project.json"

        // update versions
        projects |> Seq.iter updateVersion

        // build nuget packages
        projects
        |> Seq.map DirectoryName
        |> Seq.iter(fun project -> 
            //even though this says desktop it still packs all the tfm's it just hints wich installed dnx version to use
            Tooling.Dnu.Exec Tooling.DotNetRuntime.Desktop Build.BuildFailure project ["pack"; (Paths.Quote project); "--configuration Release";])

        projects
        |> Seq.iter(fun project ->
            let projectName = (project |> DirectoryName |> directoryInfo).Name
            let srcFolder = Paths.BinFolder(projectName)
            let package = sprintf "%s/%s.%s.nupkg" srcFolder projectName Versioning.FileVersion

            // unzip package
            let unzippedDir = sprintf "%s/%s" srcFolder projectName
            ZipHelper.Unzip unzippedDir package
                        
            // rename NEST package id
            if (projectName.Equals("Nest", StringComparison.InvariantCultureIgnoreCase))
            then
                let nuspec = sprintf "%s/Nest.nuspec" unzippedDir
                FileHelper.RegexReplaceInFileWithEncoding 
                    "<id>Nest</id>" 
                    "<id>NEST</id>" 
                    System.Text.Encoding.UTF8 
                    nuspec

                // TODO: Make this more generic in limiting to major version based
                // on the major version of the version specified.
                FileHelper.RegexReplaceInFileWithEncoding 
                    "<dependency id=\"Newtonsoft.Json\" version=\".*\" />" 
                    "<dependency id=\"Newtonsoft.Json\" version=\"[8,9)\" />"  
                    System.Text.Encoding.UTF8 
                    nuspec


            // Include PDB for each target framework
            let frameworkDirs = (sprintf "%s/lib" unzippedDir |> directoryInfo).GetDirectories()
            for frameworkDir in frameworkDirs do
                let frameworkPdbDir = sprintf "%s/%s" srcFolder frameworkDir.Name
                gitLink frameworkPdbDir projectName
                let pdb = sprintf "%s.pdb" projectName
                let frameworkPdbFile = sprintf "%s/%s" frameworkPdbDir pdb
                if fileExists frameworkPdbFile
                then CopyFile (sprintf "%s/%s" frameworkDir.FullName pdb) frameworkPdbFile

            // re-zip package
            ZipHelper.Zip unzippedDir package !!(sprintf "%s/**/*.*" unzippedDir)
            DeleteDir unzippedDir

            // move to nuget output
            MoveFile Paths.NugetOutput package
        )

    static member PublishCanaryBuild accessKey = 
        !! "build/output/_packages/*-ci*.nupkg"
        |> Seq.iter(fun f -> 
            let success = Tooling.execProcess (Tooling.NugetFile()) ["push"; f; accessKey; "-source"; "https://www.myget.org/F/elasticsearch-net/api/v2/package"] 
            match success with
            | 0 -> traceFAKE "publish to myget succeeded" |> ignore
            | _ -> failwith "publish to myget failed" |> ignore
        )