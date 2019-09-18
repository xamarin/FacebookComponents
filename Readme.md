# Xamarin Components for Facebook

Xamarin creates and maintains Xamarin.Android and Xamarin.iOS bindings for Facebook SDKs.

## Building 

### Prerequisites

Before building the libraries and samples in this repository, you will need to install [.NET Core][30] and the [Cake .NET Core Tool][32]:

```sh
dotnet tool install -g cake.tool
```

When building on macOS, you may also need to install [CocoaPods][31]:

```sh
# Homebrew
brew install cocoapods

# Ruby Gems
gem install cocoapods
```

### Compiling

You can either build all the libraries and samples in the repository from the root:

```sh
dotnet cake
```

Or, you can build each component separately:

```sh
# iOS
cd Facebook.iOS
dotnet cake

# Android
cd Facebook.Android
dotnet cake
```

The following targets can be specified using the `--target=<target-name>`:

 - `libs` builds the class library bindings (depends on `externals`)
 - `externals` downloads and builds the external dependencies
 - `samples` builds all of the samples (depends on `libs`)
 - `nuget` builds the nuget packages (depends on `libs`)
 - `clean` cleans up everything


### Working in Visual Studio

Before the `.sln` files will compile in the IDEs, the external dependencies need to be downloaded. This can be done by running the `externals` target:

```sh
dotnet cake --target=externals
```

After the externals are downloaded and built, the `.sln` files should compile in your IDE.


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

[30]: https://dotnet.microsoft.com/download
[31]: https://cocoapods.org/
[32]: http://cakebuild.net
[33]: https://cla2.dotnetfoundation.org/
[34]: http://www.dotnetfoundation.org/projects

