# C# Examples – IDS peak Generic SDK

This directory contains C# examples demonstrating how to use the IDS peak Generic SDK via its **.NET** Bindings.

The examples require:
- **.NET Framework 4.6.1** (classic)
- **.NET 6** (modern)

## Requirements
- An [IDS peak Setup](https://en.ids-imaging.com/download-peak.html) (Runtime Setup which provides the GenTL is enough)
- .NET SDK / Visual Studio for building and running examples

> Note: The C# bindings include the necessary runtime DLLs to run the examples.
Installing the IDS peak Runtime Setup is still required to provide the necessary GenTL for device access.

## Build Instructions

### .NET (modern)
```bash
dotnet build
dotnet run --project <exampleProjectPath>
```

### .NET Framework
Use Visual Studio or:
```bash
msbuild exampleProjectFramework.csproj /t:Restore
msbuild exampleProjectFramework.csproj
```

## NuGet
IDS peak .NET packages are available on NuGet and can be added with:
```bash
dotnet add package IDSImaging.Peak.<PackageName>
```

## Included Examples
*(Add example list here)*
