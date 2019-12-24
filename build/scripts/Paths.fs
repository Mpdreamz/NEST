﻿namespace Scripts

open Projects

module Paths =

    let OwnerName = "elastic"
    let RepositoryName = "elasticsearch-net"
    let Repository = sprintf "https://github.com/%s/%s" OwnerName RepositoryName

    let BuildFolder = "build"
    let TargetsFolder = "build/scripts"
    
    let BuildOutput = sprintf "%s/output" BuildFolder
    let Output(folder) = sprintf "%s/%s" BuildOutput folder
    
    let ProjectOutputFolder (project:DotNetProject) (framework:DotNetFramework) = 
        sprintf "src/%s/bin/Release/%s" project.Name framework.Identifier.Nuget
  
    let Tool tool = sprintf "packages/build/%s" tool
    let CheckedInToolsFolder = "build/tools"
    let KeysFolder = sprintf "%s/keys" BuildFolder
    let NugetOutput = sprintf "%s/_packages" BuildOutput
    let SourceFolder = "src"
    
    let Solution = "Elasticsearch.sln"
    
    let Keys(keyFile) = sprintf "%s/%s" KeysFolder keyFile
    let Source(folder) = sprintf "%s/%s" SourceFolder folder
    let TestsSource(folder) = sprintf "tests/%s"  folder
    
    let ProjFile(project:DotNetProject) =
        match project with 
        | Project p -> 
            match p with 
            | _ -> sprintf "%s/%s/%s.csproj" SourceFolder project.Name project.Name
        | PrivateProject p ->
            match p with
            | RestSpecTestRunner 
            | Tests -> sprintf "tests/%s/%s.csproj" project.Name project.Name
            | DocGenerator 
            | ApiGenerator -> sprintf "%s/%s/%s.csproj" SourceFolder project.Name project.Name

    let BinFolder (folder:string) = 
        let f = folder.Replace(@"\", "/")
        sprintf "%s/%s/bin/Release" SourceFolder f
