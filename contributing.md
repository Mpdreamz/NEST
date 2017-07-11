# Contributing

Contributing back to `Elasticsearch.Net` and `NEST` is very much appreciated. 
Whether you [feel the need to change one character](https://github.com/elasticsearch/elasticsearch-net/pull/536) or have a go at 
[mapping new API's](http://github.com/elasticsearch/elasticsearch-net/pull/376) no PR is too small or too big. 

In fact many of our most aweseome features/fixes have been provided to us by [these wonderful folks](https://github.com/elasticsearch/elasticsearch-net/graphs/contributors) to which we are forever indebted 

## Sign the CLA

We do ask that you sign the [Elasticsearch CLA](http://www.elasticsearch.org/contributor-agreement/) before we can accept pull requests from you. 

## Coding Styleguide

Please install the [editorconfig vs extension](https://visualstudiogallery.msdn.microsoft.com/c8bccfe2-650c-4b42-bc5c-845e21f96328)
this will automatically switch to our indentation, whitespace, newlines settings while working on our project
**while leaving your default settings intact**.

In most cases we won't shun a PR just because it uses the wrong indentation settings though it'll be **very** much appreciated!

## Tests

PR's with tests are more likely to be reviewed faster because it makes our jobs that much more easy, that being said
we respect that you are fixing a bug in your own time and might not have the time/energy to submit a PR with complete tests. 
In those cases we tend to pull your bits locally and write tests ourselves but this may mean your PR might sit idle longer then you would like.

## Branches

- `1.x` for latest 1.x compatible client
- `master` for 2.0 compatible client

## Git

We do not require rebased/squashed commits although we do very much appreciate it! 

Please submit your [Pull Requests](https://help.github.com/articles/creating-a-pull-request/) to 

- [`master`](https://github.com/elastic/elasticsearch-net/tree/master) branch for 2.0
- [`1.x`](https://github.com/elastic/elasticsearch-net/tree/1.x) branch for 1.x

# Building the solution

The solution uses a number of awesome Open Source software tools to ease development:

## Paket

[Paket](https://fsprojects.github.io/Paket/) is the dependency manager of choice for handling dependencies of both the solution and the build automation system. It works for both .NET and Mono, with an ability to reference packages from Nuget and also files directly from github.

## FAKE

[FAKE (F# MAKE)](http://fsharp.github.io/FAKE/) is used as the build automation system for the solution. To get started after cloning the solution, it's best to run the build script in the root

for Windows 

```
build.bat
```

for OSX/Linux

```
build.sh
```

This will

- Pull down all the paket dependencies for the build process as well as the solution
- Run the default build target for the solution

You can also compile the solution within Visual Studio if you prefer, but the build script is going to be faster.

## Tests

The `Tests` project contains both xunit unit and integration tests. A `tests.yaml` file within the root of the `Tests` project determines the test mode when running tests inside Visual Studio; the build script has a number of different build targets to run different types of tests, see the `Targets.fsx` script in the `scripts` project for the complete list.

## Troubleshooting

### Could not load file or assembly FSharp.Core

You may come across an exception similar to below when running the build script

>Unhandled Exception: System.IO.FileLoadException: Could not load file or assembly 'FSharp.Core, Version=4.3.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
   at <StartupCode$FAKE>.$Program.main@()

The `1.x` and `master` branches have diverged dramatically as a result of changes in preparation for 2.0. This includes changes to the build process such that switching between the `master` and `1.x` branches and back again can change the versions of packages used within the build processes. To rectify this issue, try deleting the `packages` folder within the root of the solution and run the build script again.

If working on both 1.x and 2.0 versions of NEST, it is recommended to clone the git repository for each version into separate directories to avoid the need to switch between the divergent branches.

### System.Exception: Attempting to run with dotnet.exe with 1.0.x but global.json mandates 1.0.1

When running the `build` script, you may encounter a mismatch with your version of the .NET Core runtime. Ensure your version of .NET Core exactly matches the version specified under `sdk` in the `global.json` file.

```json
{
  "sdk": {
    "version": "1.0.1"
  }
}
```
