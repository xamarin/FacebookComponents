
#load "../common.cake"
#load "poco.ios.cake"
#load "components.cake"
#load "custom_externals_download.cake"

var TARGET = Argument ("t", Argument ("target", "nuget"));
var SDKS = Argument ("sdks", "");

// Artifacts that need to be built from pods or be copied from pods
var ARTIFACTS_FROM_PODS = new List<Artifact> ();

var SOURCES_TARGETS = new List<string> ();
var SAMPLES_TARGETS = new List<string> {
	"FacebookiOSSample",
	"FBAccountKitSample",
	"FBAudienceNetworkSample",
	"HelloFacebook",
};

// Podfile basic structure
var PODFILE_BEGIN = new [] {
	"platform :ios, '{0}'",
	"install! 'cocoapods', :integrate_targets => false",
	"use_frameworks!",
	"target 'XamarinFacebook' do",
};
var PODFILE_END = new [] {
	"end",
};

// Prepares the artifacts to be built.
// From CI will always build everything but, locally you can customize what
// you build, just to save time when testing locally.
Task("prepare-artifacts")
	.IsDependeeOf("externals")
	.Does(() =>
{
	SetArtifactsDependencies ();

	var orderedArtifactsForBuild = new List<Artifact> ();

	if (string.IsNullOrWhiteSpace (SDKS) || TARGET == "samples")
	{
		orderedArtifactsForBuild.AddRange (ARTIFACTS.Values);
		orderedArtifactsForBuild.Sort ((f, s) => ((iOSArtifact)s).BuildOrder.CompareTo (((iOSArtifact)f).BuildOrder));

		// Remove the artifact from the dictionary if the source is different than Pods
		// You will need to add the code to download the framework at custom_externals_download.cake
		ARTIFACTS.Remove ("AudienceNetwork");
		ARTIFACTS.Remove ("FacebookSdks");
		
		ARTIFACTS_FROM_PODS.AddRange (ARTIFACTS.Values);

		foreach (var artifact in orderedArtifactsForBuild)
			SOURCES_TARGETS.Add(artifact.CsprojName);

		Information ("Build order:");

		foreach (var target in SOURCES_TARGETS)
			Information (target);

		return;
	}

	var sdks = SDKS.Split (',');
	foreach (var sdk in sdks) {
		var artifact = ARTIFACTS [sdk];
		switch (sdk)
		{
		case "AudienceNetwork":
		case "FacebookSdks":
			orderedArtifactsForBuild.Add (artifact);
			AddArtifactDependencies (orderedArtifactsForBuild, artifact.Dependencies);
			break;
		default:
			orderedArtifactsForBuild.Add(artifact);
			AddArtifactDependencies (orderedArtifactsForBuild, artifact.Dependencies);
			ARTIFACTS_FROM_PODS.Add (artifact);
			break;
		}
	}

	orderedArtifactsForBuild = orderedArtifactsForBuild.Distinct ().ToList ();
	orderedArtifactsForBuild.Sort ((f, s) => ((iOSArtifact)s).BuildOrder.CompareTo (((iOSArtifact)f).BuildOrder));

	foreach (var artifact in orderedArtifactsForBuild)
			SOURCES_TARGETS.Add(artifact.CsprojName);

	Information ("Build order:");

	foreach (var target in SOURCES_TARGETS)
		Information (target);
});

Task ("externals")
	.WithCriteria (!DirectoryExists ("./externals/"))
	.Does (() => 
{
	EnsureDirectoryExists ("./externals/");

	foreach (var artifact in ARTIFACTS_FROM_PODS) {
		UpdateVersionInCsproj (artifact);
		CreateAndInstallPodfile (artifact);
		BuildSdkOnPodfile (artifact);
	}

	// Call custom methods created at custom_externals_download.cake file
	// to download frameworks and/or bundles for the artifact
	if (SOURCES_TARGETS.Contains (ACCOUNT_KIT_ARTIFACT.CsprojName)) {
		UpdateVersionInCsproj (ACCOUNT_KIT_ARTIFACT);
		DownloadAccountKit (ACCOUNT_KIT_ARTIFACT);
	}
	
	if (SOURCES_TARGETS.Contains (AUDIENCE_NETWORK_ARTIFACT.CsprojName)) {
		UpdateVersionInCsproj (AUDIENCE_NETWORK_ARTIFACT);
		DownloadAudienceNetwork (AUDIENCE_NETWORK_ARTIFACT);
	}

	if (SOURCES_TARGETS.Contains (FACEBOOK_SDKS_ARTIFACT.CsprojName)) {
		UpdateVersionInCsproj (FACEBOOK_SDKS_ARTIFACT);
	}
});

Task ("libs")
	.IsDependentOn("externals")
	.Does(() =>
{
	CleanVisualStudioSolution ();

	var targets = $@"source\\{string.Join (@";source\\", SOURCES_TARGETS)}";

	MSBuild("./Xamarin.Facebook.sln", c => {
		c.Configuration = "Release";
		c.Restore = true;
		c.MaxCpuCount = 0;
		c.Targets.Clear();
		c.Targets.Add(targets);
	});
});

Task ("samples")
	.IsDependentOn("libs")
	.Does(() =>
{
	var targets = $@"samples\\{string.Join (@";samples\\", SAMPLES_TARGETS)}";

	MSBuild("./Xamarin.Facebook.sln", c => {
		c.Configuration = "Release";
		c.Restore = true;
		c.MaxCpuCount = 0;
		c.Targets.Clear();
		c.Targets.Add(targets);
	});
});

Task ("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	EnsureDirectoryExists("./output");

	var targets = $@"source\\{string.Join (@":Pack;source\\", SOURCES_TARGETS)}:Pack";

	MSBuild("./Xamarin.Facebook.sln", c => {
		c.Configuration = "Release";
		c.Restore = true;
		c.MaxCpuCount = 0;
		c.Targets.Clear();
		c.Targets.Add(targets);
		c.Properties.Add("PackageOutputPath", new [] { "../../output/" });
	});
});

Task ("clean")
	.Does (() => 
{
	CleanVisualStudioSolution ();

	var deleteDirectorySettings = new DeleteDirectorySettings {
		Recursive = true,
		Force = true
	};

	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", deleteDirectorySettings);

	if (DirectoryExists ("./output/"))
		DeleteDirectory ("./output", deleteDirectorySettings);
});

RunTarget (TARGET);

void AddArtifactDependencies (List<Artifact> list, Artifact [] dependencies)
{
	if (dependencies == null)
		return;
	
	list.AddRange (dependencies);

	foreach (var dependency in dependencies)
		AddArtifactDependencies (list, dependency.Dependencies);
}

void CreateAndInstallPodfile (Artifact artifact)
{
	if (artifact == null)
		return;

	var iOSArtifact = (iOSArtifact)artifact;

	var podfilePath = $"./externals/{iOSArtifact.Id}/";
	EnsureDirectoryExists (podfilePath);

	var podfileBegin = new List<string> (PODFILE_BEGIN);
	podfileBegin [0] = string.Format (podfileBegin [0], iOSArtifact.MinimunSupportedVersion);
	
	var podfile = new List<string> (podfileBegin);
	podfile.Add ($"\tpod '{iOSArtifact.Id}', '{iOSArtifact.Version}'");
	podfile.AddRange (PODFILE_END);

	FileWriteLines ($"{podfilePath}Podfile", podfile.ToArray ());
	CocoaPodInstall (podfilePath);
}

void BuildSdkOnPodfile (Artifact artifact)
{
	var iOSArtifact = (iOSArtifact)artifact;

	var platforms = new [] { Platform.iOSArm64, Platform.iOSArmV7, Platform.iOSSimulator64, Platform.iOSSimulator };

	var podsProject = "./Pods/Pods.xcodeproj";
	var workingDirectory = $"./externals/{iOSArtifact.Id}";
	var framework = $"{iOSArtifact.FrameworkName}.framework";
	var paths = GetDirectories($"{workingDirectory}/Pods/**/{framework}");
	
	// if (TargetExistsInXcodeProject (podsProject, artifact.FrameworkName, workingDirectory)) {
	if (paths?.Count <= 0) {
		BuildXcodeFatFramework (podsProject, iOSArtifact.Id, platforms, libraryTitle: iOSArtifact.FrameworkName, workingDirectory: workingDirectory);
		CopyDirectory ($"{workingDirectory}/{framework}", $"./externals/{framework}");
	} else {
		foreach (var path in paths)
			CopyDirectory (path, $"./externals/{framework}");
	}
}

void UpdateVersionInCsproj (Artifact artifact) 
{
	var csprojPath = $"./source/{artifact.CsprojName}/{artifact.CsprojName}.csproj";
	XmlPoke(csprojPath, "/Project/PropertyGroup/FileVersion", artifact.NugetVersion);
	XmlPoke(csprojPath, "/Project/PropertyGroup/PackageVersion", artifact.NugetVersion);
}

void CleanVisualStudioSolution ()
{
	MSBuild("./Xamarin.Facebook.sln", c => {
		c.Configuration = "Release";
		c.Restore = true;
		c.MaxCpuCount = 0;
		c.Targets.Add("Clean");
	});

	var deleteDirectorySettings = new DeleteDirectorySettings {
		Recursive = true,
		Force = true
	};

	var bins = GetDirectories("./**/bin");
	DeleteDirectories (bins, deleteDirectorySettings);

	var objs = GetDirectories("./**/obj");
	DeleteDirectories (objs, deleteDirectorySettings);
}
