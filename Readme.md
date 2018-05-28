# Xamarin Components for Facebook

Xamarin creates and maintains Xamarin.Android and Xamarin.iOS bindings for Facebook SDKs.

## Building

Before building you will need to have [CocoaPods][31] installed on your OS X system.

The build script for this project uses [Cake][32].  To run the build, you can use the bootstrapper file for OS X:

**Mac**:

```
cd Facebook.iOS
sh ../build.sh --target=libs
```

The bootstrapper script will automatically download Cake.exe and all the required tools and files into the `./tools/` folder.

The following targets can be specified:

 - `libs` builds the class library bindings (depends on `externals`)
 - `externals` downloads and builds the external dependencies
 - `samples` builds all of the samples (depends on `libs`)
 - `nuget` builds the nuget packages (depends on `libs`)
 - `clean` cleans up everything


### Working in Xamarin Studio

Before the `.sln` files will compile in Xamarin Studio, the external dependencies need to be downloaded.  This can be done by running the `build.sh` or `build.ps1` with the target `externals`.  After the externals are setup, the `.sln` files should compile in an IDE.


## License

The license for this repository is specified in 
[License.md](License.md)

## External-Dependency-Info and THIRD-PARTY-NOTICE Files

Files named **External-Dependency-Info** within this repository exist to provide content to the **THIRD-PARTY-NOTICES** file of the Xamarin Component and NuGet binary packages. Information within the **External-Dependency-Info** files describe potential dependencies bundled with packages as a result of building projects within this repo. 

## Contribution Guidelines

You will need to complete a Contribution License Agreement before your pull request can be accepted. You can complete the CLA by going through the steps at [https://cla2.dotnetfoundation.org/][33].

## .NET Foundation
This project is part of the [.NET Foundation][34]


[1]: Facebook.Android
[2]: Facebook.AudienceNetwork.iOS
[3]: Facebook.iOS

[11]: https://components.xamarin.com/view/facebookandroid
[12]: https://components.xamarin.com/view/fbaudiencenetworkios
[13]: https://components.xamarin.com/view/facebookios

[21]: https://www.nuget.org/packages/Xamarin.Facebook.Android/
[23]: https://www.nuget.org/packages/Xamarin.Facebook.iOS/

[31]: https://cocoapods.org/
[32]: http://cakebuild.net
[33]: https://cla2.dotnetfoundation.org/
[34]: http://www.dotnetfoundation.org/projects

