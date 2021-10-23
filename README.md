# BMSSV.IO
An IO library for interacting with the Mercury Steam BMSSV save format.

This library is still in active development as samus.bmssv has not been fully parsed.

## Contributing
This is an independently developed project. Currently, pull requests will not be accepted as the project will be constantly changing to support my other projects relating to the BMSSV format.

***

# Install
This project is developed using .NET 5.0 and built as a NuGet package. To add this NuGet package to a project:

GitHub does not currently support access to package registries without authenticating. A private access token has been created to grant access to this package. Add the following to the configuration section in your NuGet.Config:
```xml
<packageSources>
  <add key="KhaosVoidPackages" value="https://nuget.pkg.github.com/KhaosVoid/index.json" />
</packageSources>
<packageSourceCredentials>
  <KhaosVoidPackages>
    <add key="Username" value="Anonymous" />
    <add key="ClearTextPassword" value="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" />
  </KhaosVoidPackages>
</packageSourceCredentials>
```

To add the NuGet package to your project, you can either use the dotnet CLI or add a package reference line to your csproj.

dotnet CLI:
```ps
$ dotnet add PROJECT package BMSSV.IO --version 2021.10.22.1
```

<br />

PackageReference (replace 'packageVersion' with the desired package version):
```xml
<ItemGroup>
  <PackageReference Include="BMSSV.IO" Version="packageVersion" />
</ItemGroup>
```
