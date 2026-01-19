# C# Examples – IDS peak Generic SDK

This directory contains C# examples demonstrating how to use the IDS
peak Generic SDK via its **.NET** Bindings.

The examples require at least:
- **.NET Framework 4.6.1** (classic)
- **.NET 6** (modern)

## Requirements

- An [IDS peak Setup](https://en.ids-imaging.com/download-peak.html) (Runtime Setup which provides the GenTL is enough)
- .NET SDK / Visual Studio for building and running examples

> Note: The C# bindings include the necessary runtime DLLs to run the
> examples.
Installing the IDS peak Runtime Setup is still required to provide the necessary GenTL for device access.

## Build Instructions

The IDS peak SDK relies on **native (unmanaged) DLLs** that are
distributed inside the referenced NuGet packages.

If **no `RuntimeIdentifier` (`-r`) is specified**, all available native
runtimes from the packages will be copied to your build output. This
makes the build artifact larger but maximizes compatibility across
platforms.

To **reduce the size of the application output**, you can specify a
concrete runtime, for example:

```bash
dotnet build -r win-x64
```

This will include only the native libraries required for that runtime.

### .NET (modern, SDK-style)

```bash
dotnet build exampleProject.csproj
dotnet run --project exampleProject.csproj
```

> Optional (smaller output):
>
> ```bash
> dotnet build -r win-x64 exampleProject.csproj
> dotnet run -r win-x64 --project exampleProject.csproj
> ```

### .NET Framework (classic)

Use Visual Studio **or** build from the command line:

```bash
# Restore packages first
msbuild exampleProjectFramework.csproj /t:Restore

# Build for a specific platform (required for native DLLs)
msbuild exampleProjectFramework.csproj /p:Platform=x64
```

> **Note:** For .NET Framework projects you must specify `x86` or `x64`
> because classic .NET does not use the NuGet `runtimes/` mechanism the
> way modern .NET does.

## NuGet

IDS peak .NET packages are available on NuGet and can be added with:
```bash
dotnet add package IDSImaging.Peak.<PackageName>
```

## Included Examples

- [OpenCamera: command-line sample demonstrating device enumeration and access](open_camera)
