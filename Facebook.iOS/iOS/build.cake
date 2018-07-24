#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

SDK_VERSION = "4.33.0";
XAMARIN_FIX_VERSION = "0";
SDK_FULL_VERSION = $"{SDK_VERSION}.{XAMARIN_FIX_VERSION}";

var buildSpec = new BuildSpec () {
	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder {
			SolutionPath = "./samples/FacebookiOSSample/FacebookiOSSample.sln",
			Configuration = "Release",
			Platform = "iPhone",
			BuildsOn = BuildPlatforms.Mac },

		new IOSSolutionBuilder {
			SolutionPath = "./samples/HelloFacebook/HelloFacebook.sln",
			Configuration = "Release",
			Platform = "iPhone",
			BuildsOn = BuildPlatforms.Mac },
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.iOS.nuspec", Version = SDK_FULL_VERSION, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

MY_DEPENDENCIES = new [] { "CoreKit", "LoginKit", "PlacesKit", "ShareKit", "MessengerShareKit" };

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
