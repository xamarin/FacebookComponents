
#load "../common.cake"

var SDK_VERSION = "4.19.0";
var SDK_URL = string.Format ("https://origincache.facebook.com/developers/resources/?id=FacebookSDKs-iOS-{0}.zip", SDK_VERSION);
var SDK_FILE = "FacebookSDKs-iOS.zip";
var SDK_PATH = "./externals/FacebookSDKs";

var TARGET = Argument ("t", Argument ("target", "Default"));

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new IOSSolutionBuilder {
			SolutionPath = "./source/Facebook.AudienceNetwork/Facebook.AudienceNetwork.sln",
			Configuration = "Release",
			BuildsOn = BuildPlatforms.Mac,
			OutputFiles = new [] { 
				new OutputFileCopy {
					FromFile = "./source/Facebook.AudienceNetwork/bin/unified/Release/Facebook.AudienceNetwork.dll",
					ToDirectory = "./output/unified/"
				}
			}
		}	
	},

	Samples = new ISolutionBuilder [] {
		new IOSSolutionBuilder {
			SolutionPath = "./samples/FBAudienceNetworkSample/FBAudienceNetworkSample.sln",
			Configuration = "Release|iPhone",
			BuildsOn = BuildPlatforms.Mac }
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Facebook.AudienceNetwork.iOS.nuspec", BuildsOn = BuildPlatforms.Mac},
	},

	Components = new [] {
		new Component {ManifestDirectory = "./component", BuildsOn = BuildPlatforms.Mac},
	},
};

Task ("externals")
	.WithCriteria (!FileExists ("./externals/Facebook.AudienceNetwork.a"))
	.Does (() => 
{
	if (!DirectoryExists ("./externals/"))
		CreateDirectory ("./externals");

	DownloadFile (SDK_URL, "./externals/" + SDK_FILE, new Cake.Xamarin.Build.DownloadFileSettings
	{
		UserAgent = "curl/7.43.0"
	});

	Unzip ("./externals/" + SDK_FILE, SDK_PATH);

	CopyFile (SDK_PATH + "/FBAudienceNetwork.framework/FBAudienceNetwork", "./externals/Facebook.AudienceNetwork.a");

	DeleteDirectory (SDK_PATH, true);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
