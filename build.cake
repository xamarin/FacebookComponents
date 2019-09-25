var VERBOSITY = Argument ("v", Argument ("verbosity", Verbosity.Normal));
var CONFIGURATION = Argument ("c", Argument ("configuration", "Release"));

var BUILD_TARGET = Argument ("t", Argument ("target", "Default"));

var PROJECTS = new DirectoryPath [] {
	"./Facebook.Android/",
	"./Facebook.iOS/"
};

var cakeSettings = new CakeSettings {
	Arguments = new Dictionary<string, string> {
		{ "configuration", CONFIGURATION },
		{ "target", BUILD_TARGET },
	},
	Verbosity = VERBOSITY
};

foreach (var project in PROJECTS) {
	CakeExecuteScript (project.CombineWithFilePath ("build.cake"), cakeSettings);

	EnsureDirectoryExists ("./output/");
	CopyDirectory (project.Combine ("output"), "./output/");
}
