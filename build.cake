var VERBOSITY = Argument ("v", Argument ("verbosity", Verbosity.Normal));
var CONFIGURATION = Argument ("c", Argument ("configuration", "Release"));

var TARGET = Argument ("t", Argument ("target", "ci"));

var PROJECTS = new DirectoryPath [] {
	"./Facebook.Android/",
	"./Facebook.iOS/"
};

var cakeSettings = new CakeSettings {
	Arguments = new Dictionary<string, string> {
		{ "configuration", CONFIGURATION },
		{ "target", TARGET },
	},
	Verbosity = VERBOSITY
};

foreach (var project in PROJECTS) {
	CakeExecuteScript (project.CombineWithFilePath ("build.cake"), cakeSettings);

	EnsureDirectoryExists ("./output/");
	CopyDirectory (project.Combine ("output"), "./output/");
}
