
#load "common.cake"
#load "poco.cake"
#load "components.cake"
#load "custom_externals_download.cake"

var TARGET = Argument ("t", Argument ("target", "ci"));
var NAMES = Argument ("names", "");

var BUILD_COMMIT = EnvironmentVariable("BUILD_COMMIT") ?? "DEV";
var BUILD_NUMBER = EnvironmentVariable("BUILD_NUMBER") ?? "DEBUG";
var BUILD_TIMESTAMP = DateTime.UtcNow.ToString();

var IS_LOCAL_BUILD = true;
var BACKSLASH = string.Empty;

var SOURCES_SOLUTION_PATH = "./source/Sources.sln";
var SAMPLES_SOLUTION_PATH = "./samples/Samples.sln";
var EXTERNALS_PATH = new DirectoryPath ("./externals");

// Artifacts that need to be built from pods or be copied from pods
var ARTIFACTS_TO_BUILD = new List<Artifact> ();

var SOURCES_TARGETS = new List<string> ();
var SAMPLES_TARGETS = new List<string> ();

Setup (context =>
{
	IS_LOCAL_BUILD = string.IsNullOrWhiteSpace (EnvironmentVariable ("AGENT_ID"));
	Information ($"Is a local build? {IS_LOCAL_BUILD}");
	BACKSLASH = IS_LOCAL_BUILD ? @"\\" : @"\";
});

// Prepares the artifacts to be built.
// From CI will always build everything but, locally you can customize what
// you build, just to save time when testing locally.
Task("prepare-artifacts")
	.IsDependeeOf("externals")
	.Does(() =>
{
	SetArtifactsDependencies ();
	SetArtifactsPodSpecs ();
	SetArtifactsExtraPodfileLines ();
	SetArtifactsSamples ();

	var orderedArtifactsForBuild = new List<Artifact> ();
	var orderedArtifactsForSamples = new List<Artifact> ();

	if (string.IsNullOrWhiteSpace (NAMES)) {
		orderedArtifactsForBuild.AddRange (ARTIFACTS.Values);
		orderedArtifactsForSamples.AddRange (ARTIFACTS.Values);
	} else {
		var names = NAMES.Split (',');
		foreach (var name in names) {
			if (!(ARTIFACTS.ContainsKey (name) && ARTIFACTS [name] is Artifact artifact))
				throw new Exception($"The {name} component does not exist.");
			
			orderedArtifactsForBuild.Add (artifact);
			AddArtifactDependencies (orderedArtifactsForBuild, artifact.Dependencies);
			orderedArtifactsForSamples.Add (artifact);
		}

		orderedArtifactsForBuild = orderedArtifactsForBuild.Distinct ().ToList ();
		orderedArtifactsForSamples = orderedArtifactsForSamples.Distinct ().ToList ();
	}

	orderedArtifactsForBuild.Sort ((f, s) => s.BuildOrder.CompareTo (f.BuildOrder));
	orderedArtifactsForSamples.Sort ((f, s) => s.BuildOrder.CompareTo (f.BuildOrder));
	ARTIFACTS_TO_BUILD.AddRange (orderedArtifactsForBuild);

	Information ("Build order:");

	foreach (var artifact in ARTIFACTS_TO_BUILD) {
		SOURCES_TARGETS.Add(artifact.CsprojName.Replace ('.', '_'));
		Information (artifact.Id);
	}

	foreach (var artifact in orderedArtifactsForSamples)
		if (artifact.Samples != null)
			foreach (var sample in artifact.Samples)
				SAMPLES_TARGETS.Add(sample.Replace ('.', '_'));
});

Task ("externals")
	.WithCriteria (!DirectoryExists (EXTERNALS_PATH) || !string.IsNullOrWhiteSpace (NAMES))
	.Does (() => 
{
	EnsureDirectoryExists (EXTERNALS_PATH);

	Information ("////////////////////////////////////////");
	Information ("// Pods Repo Update Started           //");
	Information ("////////////////////////////////////////");
	
	Information ("\nUpdating Cocoapods repo...");
	CocoaPodRepoUpdate ();

	Information ("////////////////////////////////////////");
	Information ("// Pods Repo Update Ended             //");
	Information ("////////////////////////////////////////");

	if (string.IsNullOrWhiteSpace (NAMES)) {
		foreach (var artifact in ARTIFACTS_TO_BUILD) {
			UpdateVersionInCsproj (artifact);
			CreateAndInstallPodfile (artifact);
			BuildSdkOnPodfile (artifact);
		}
	} else {
		foreach (var artifact in ARTIFACTS_TO_BUILD) {
			UpdateVersionInCsproj (artifact);

			foreach (var podSpec in artifact.PodSpecs) {
				if (podSpec.FrameworkSource != FrameworkSource.Pods)
					continue;
				
				if (DirectoryExists (EXTERNALS_PATH.Combine ($"{podSpec.FrameworkName}.framework")))
					break;

				CreateAndInstallPodfile (artifact);
				BuildSdkOnPodfile (artifact);
			}
		}
	}

	// Call here custom methods created at custom_externals_download.cake file
	// to download frameworks and/or bundles for the artifact
});

Task ("ci-setup")
	.WithCriteria (!BuildSystem.IsLocalBuild)
	.Does (() => 
{
	var glob = "./source/**/AssemblyInfo.cs";

	ReplaceTextInFiles(glob, "{BUILD_COMMIT}", BUILD_COMMIT);
	ReplaceTextInFiles(glob, "{BUILD_NUMBER}", BUILD_NUMBER);
	ReplaceTextInFiles(glob, "{BUILD_TIMESTAMP}", BUILD_TIMESTAMP);
});

Task ("libs")
	.IsDependentOn("externals")
	.IsDependentOn("ci-setup")
	.Does(() =>
{
	MSBuild(SOURCES_SOLUTION_PATH, c => {
		c.Configuration = "Release";
		c.Restore = true;
		c.MaxCpuCount = 0;
	});
});

Task ("samples")
	.IsDependentOn("libs")
	.Does(() =>
{
	MSBuild(SAMPLES_SOLUTION_PATH, c => {
		c.Configuration = "Release";
		c.Restore = true;
		c.MaxCpuCount = 0;
	});
});

Task ("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	EnsureDirectoryExists("./output");

	MSBuild(SOURCES_SOLUTION_PATH, c => {
		c.Configuration = "Release";
		c.Restore = true;
		c.MaxCpuCount = 0;
		c.Targets.Clear();
		c.Targets.Add("Pack");
		c.Properties.Add("PackageOutputPath", new [] { "../../output/" });
	});
});

Task ("clean")
	.Does (() => 
{
	var deleteDirectorySettings = new DeleteDirectorySettings {
		Recursive = true,
		Force = true
	};

	var bins = GetDirectories("./**/bin");
	DeleteDirectories (bins, deleteDirectorySettings);

	var objs = GetDirectories("./**/obj");
	DeleteDirectories (objs, deleteDirectorySettings);

	if (DirectoryExists ("./externals/"))
		DeleteDirectory ("./externals", deleteDirectorySettings);

	if (DirectoryExists ("./output/"))
		DeleteDirectory ("./output", deleteDirectorySettings);
});

Task ("ci")
	.IsDependentOn("externals")
	.IsDependentOn("libs")
	.IsDependentOn("nuget")
	.IsDependentOn("samples");

Teardown (context =>
{
	var artifacts = GetFiles ("./output/**/*");

	if (artifacts?.Count () <= 0)
		return;

	Information ($"Found Artifacts ({artifacts.Count ()})");
	foreach (var a in artifacts)
		Information ("{0}", a);
});

RunTarget (TARGET);
