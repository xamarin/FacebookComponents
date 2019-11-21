var VERBOSITY = Argument ("v", Argument ("verbosity", Verbosity.Normal));
var CONFIGURATION = Argument ("c", Argument ("configuration", "Release"));

var TARGET = Argument ("t", Argument ("target", "ci"));

// key/value of (path, macOnly)
var PROJECTS = new Dictionary<DirectoryPath, bool> {
	{ "./Facebook.Android/", false },
	{ "./Facebook.iOS/", true }
};

var cakeSettings = new CakeSettings {
	Arguments = new Dictionary<string, string> {
		{ "configuration", CONFIGURATION },
		{ "target", TARGET },
	},
	Verbosity = VERBOSITY
};

foreach (var project in PROJECTS) {
	if (project.Value && IsRunningOnWindows ())
		continue;

	CakeExecuteScript (project.Key.CombineWithFilePath ("build.cake"), cakeSettings);

	EnsureDirectoryExists ("./output/");
	CopyDirectory (project.Key.Combine ("output"), "./output/");
}
