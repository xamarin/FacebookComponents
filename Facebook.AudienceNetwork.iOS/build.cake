
#load "../common.cake"

var TARGET = Argument ("t", Argument ("target", "Default"));

var iosPlatform = "7.0";
var fbAudienceNetworkiOSSdkVersion = "4.26.0";
var KVOControllerVersion = "1.2.0";

var IOS_PODS = new List<string> {
	"source 'https://github.com/CocoaPods/Specs.git'",
	$"platform :ios, '{iosPlatform}'",
	"install! 'cocoapods', :integrate_targets => false",
	"target 'FBAudienceNetworkiOS' do",
	$"\tpod 'FBAudienceNetwork', '{fbAudienceNetworkiOSSdkVersion}'",
	$"\tpod 'KVOController', '{KVOControllerVersion}'",
	"end",
};

string [] IOS_TARGETS = { "KVOController" };

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
	.WithCriteria (!FileExists ("./externals/Facebook.AudienceNetwork.a"))
	.Does (() => 
{
	EnsureDirectoryExists ("./externals");

	if (CocoaPodVersion () < new System.Version (1, 0))
		IOS_PODS.RemoveAt (2);

	FileWriteLines ("./externals/Podfile", IOS_PODS.ToArray ());

	CocoaPodInstall ("./externals", new CocoaPodInstallSettings { });

	CopyFile ("./externals/Pods/FBAudienceNetwork/FBAudienceNetwork.framework/FBAudienceNetwork", "./externals/Facebook.AudienceNetwork.a");

	foreach (var target in IOS_TARGETS)
		BuildXCodeFatLibrary ("./Pods/Pods.xcodeproj", target, Archs.Simulator | Archs.Simulator64 | Archs.ArmV7 | Archs.Arm64, target, $"{target}.a", null, target);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
