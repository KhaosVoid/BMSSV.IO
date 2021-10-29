# BMSSV.IO
An IO library for interacting with the Mercury Steam BMSSV save format.

This library is still in active development as samus.bmssv has not been fully parsed.

## Contributing
This is an independently developed project. Currently, pull requests will not be accepted as the project will be constantly changing to support my other projects relating to the BMSSV format.

***

# Install
This project is developed using .NET 5.0 and built as a NuGet package. To add this NuGet package to a project:

GitHub does not currently support access to package registries without authenticating. A private access token has been created to grant access to this package. Add the following to the configuration section in your NuGet.Config (replace '<token>' with '8xrJNGXRFecpJIn14nhtPKBmkXKuPD3kp0sN'):
```xml
<packageSources>
  <add key="KhaosVoidPackages" value="https://nuget.pkg.github.com/KhaosVoid/index.json" />
</packageSources>
<packageSourceCredentials>
  <KhaosVoidPackages>
    <add key="Username" value="Anonymous" />
    <add key="ClearTextPassword" value="ghp_<token>" />
  </KhaosVoidPackages>
</packageSourceCredentials>
```

To add the NuGet package to your project, you can either use the dotnet CLI or add a package reference line to your csproj.

dotnet CLI (replace 'packageVersion' with one of the [available package versions](https://github.com/KhaosVoid/BMSSV.IO/packages/1058678)):
```ps
$ dotnet add PROJECT package BMSSV.IO --version packageVersion
```

<br />

PackageReference (replace 'packageVersion' with one of the [available package versions](https://github.com/KhaosVoid/BMSSV.IO/packages/1058678)):
```xml
<ItemGroup>
  <PackageReference Include="BMSSV.IO" Version="packageVersion" />
</ItemGroup>
```
