# OpenCamera Sample

The **OpenCamera** sample demonstrates how to use the **IDS peak
`DeviceManager`** to discover, select, and open a camera. After opening
the device with control access, it retrieves basic device information
from the remote GenICam node map.

### Example Output

```bash
> dotnet run -p:Platform=x64 --project OpenCamera.csproj
IDS peak OpenCamera Sample
Devices available:
0: U3-36LxXC-C (IDS U3V Interface; IDS GenICam Producer (U3V) v.1.21.0.0)

Select device to open:
0
Model Name: U3-36LxXC-C
User ID: dev
Sensor Name: onsemi AR1335CSSC32SMD20
Max. resolution (w x h): 4200 x 3120
```

## Requirements

This example requires:

* **C# 8.0 or later**
* **.NET Framework 4.6.1** (for classic projects)
* **.NET 8** (for modern SDK-style projects)

> **Note:** The C# bindings include the necessary runtime DLLs to run
> the examples. Installing the IDS peak Runtime Setup is still required
> to provide the drivers and GenTL libraries for device access.


## Build Instructions

The IDS peak SDK includes **native (unmanaged) DLLs**. To ensure your
application builds and loads correctly, you must specify the target
platform (`x64` or `x86`) when building. Omitting this may cause runtime
errors due to architecture mismatches.

### Modern .NET

```bash
dotnet build -p:Platform=x64 OpenCamera.csproj
dotnet run -p:Platform=x64 OpenCamera.csproj
```

### .NET Framework

Use Visual Studio, or build from the command line:

```bash
# Restore NuGet packages
msbuild OpenCameraFramework.csproj /t:Restore

# Build for a specific platform
msbuild OpenCameraFramework.csproj /p:Platform=x64
```
