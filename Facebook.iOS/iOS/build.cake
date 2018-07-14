#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

var facebookiOSSdkVersion = "4.33.0";
var facebookiOSXamarinFixVersion = "0";
var facebookiOSFullVersion = $"{facebookiOSSdkVersion}.{facebookiOSXamarinFixVersion}";

string [] IOS_TARGETS = null;
List<string> IOS_PODS = null;

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
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.iOS.nuspec", Version = facebookiOSFullVersion, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

MyDependencies = new [] { "CoreKit", "LoginKit", "PlacesKit", "ShareKit", "MessengerShareKit" };

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
