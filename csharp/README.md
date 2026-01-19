# C# Examples – IDS peak Generic SDK

This directory contains C# examples demonstrating how to use the IDS peak Generic SDK via its **.NET** Bindings.

The examples require at least:
- **.NET Framework 4.6.1** (classic)
- **.NET 6** (modern)

## Requirements

- An [IDS peak Setup](https://en.ids-imaging.com/download-peak.html) (Runtime Setup which provides the GenTL is enough)
- .NET SDK / Visual Studio for building and running examples

> Note: The C# bindings include the necessary runtime DLLs to run the examples.
Installing the IDS peak Runtime Setup is still required to provide the necessary GenTL for device access.

## Build Instructions

The IDS peak SDK includes native (unmanaged) DLLs. To ensure your
application builds and loads correctly, you must specify the target platform
when building. For example, use x64 or x86 with the Platform parameter
in `dotnet build` or `MSBuild`.

### .NET (modern)

```bash
dotnet build -p:Platform=x64 exampleProject.csproj
dotnet run -p:Platform=x64 exampleProject.csproj
```

### .NET Framework

Use Visual Studio or msbuild with:
```bash
msbuild exampleProjectFramework.csproj /t:Restore
msbuild exampleProjectFramework.csproj /p:Platform=x64
```

## NuGet

IDS peak .NET packages are available on NuGet and can be added with:
```bash
dotnet add package IDSImaging.Peak.<PackageName>
```

## Included Examples

- [OpenCamera: command-line sample demonstrating device enumeration and access](open_camera)
