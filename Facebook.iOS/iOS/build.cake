#load "../common.ios.cake"
#load "../../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

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
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.iOS.nuspec", Version = SDK_FULL_VERSION, RequireLicenseAcceptance = true, BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

MY_DEPENDENCIES = new [] { "CoreKit", "LoginKit", "MarketingKit", "PlacesKit", "ShareKit" };

Task ("pre-nuget-base").IsDependeeOf ("nuget-base").Does (() => {
	StartProcess("touch", new ProcessSettings { Arguments = "_._" });
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
