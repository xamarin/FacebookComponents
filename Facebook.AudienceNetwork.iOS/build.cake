
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

var SDK_VERSION = "4.27.2";
var SDK_URL = string.Format ("https://origincache.facebook.com/developers/resources/?id=FBAudienceNetwork-{0}.zip", SDK_VERSION);
var SDK_FILE = "FBAudienceNetwork.zip";
var SDK_PATH = "./externals/FBAudienceNetwork";
var SDK_FRAMEWORK = "FBAudienceNetwork.framework";

var buildSpec = new BuildSpec () {
	Libs = new ISolutionBuilder [] {
		new DefaultSolutionBuilder {
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
			Configuration = "Release",
			Platform = "iPhone",
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
	.IsDependentOn ("externals-base")
	.WithCriteria (!FileExists ($"./externals/{SDK_FRAMEWORK}"))
	.Does (() => 
{
	EnsureDirectoryExists ("./externals");

	DownloadFile (SDK_URL, $"./externals/{SDK_FILE}", new Cake.Xamarin.Build.DownloadFileSettings
	{
		UserAgent = "curl/7.43.0"
	});

	Unzip ($"./externals/{SDK_FILE}", SDK_PATH);

	CopyDirectory ($"{SDK_PATH}/{SDK_FRAMEWORK}", $"./externals/{SDK_FRAMEWORK}");

	DeleteDirectory (SDK_PATH, true);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
