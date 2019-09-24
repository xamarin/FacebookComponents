var VERBOSITY = Argument ("v", Argument ("verbosity", Verbosity.Normal));
var CONFIGURATION = Argument ("c", Argument ("configuration", "Release"));

var FAIL_ON_BUILD_FAIL = Argument ("failonbuildfail", true);

var BUILD_NAMES = Argument ("names", Argument ("name", Argument ("n", "")));
var BUILD_TARGETS = Argument ("build-targets", Argument ("targets", Argument ("target", "Default")));

var FORCE_BUILD = Argument ("force", Argument ("forcebuild", Argument ("force-build", false)));
var POD_REPO_UPDATE = Argument ("update", Argument ("repo-update", Argument ("pod-repo-update", false)));

var ROOT_DIR = MakeAbsolute((DirectoryPath)".");

var COPY_OUTPUT_TO_ROOT = Argument ("copyoutputtoroot", false);
var ROOT_OUTPUT_DIR = ROOT_DIR.Combine ("output");

if (string.IsNullOrEmpty (BUILD_NAMES))
	Warning ("No items were specified, building everything. Use the --names=<comma-separated-names> argument to build a specific item.");

var cakeSettings = new CakeSettings {
	Arguments = new Dictionary<string, string> {
		{ "configuration", CONFIGURATION },
		{ "copyoutputtoroot", COPY_OUTPUT_TO_ROOT.ToString () },
		{ "root", ROOT_DIR.FullPath },
		{ "output", ROOT_DIR.Combine ("output").FullPath },
		{ "names", BUILD_NAMES },
		{ "targets", BUILD_TARGETS },
		{ "forcebuild", true.ToString () },
		{ "repo-update", POD_REPO_UPDATE.ToString () },
		{ "failonbuildfail", FAIL_ON_BUILD_FAIL.ToString () },
	},
	Verbosity = VERBOSITY
};

var CAKE_FILE_URL = "https://raw.githubusercontent.com/xamarin/XamarinComponents/master/.ci/build-manifest.cake";
var CAKE_FILE = "./externals/build-manifest.cake";

if (!FileExists (CAKE_FILE)) {
    EnsureDirectoryExists ("./externals/");
    DownloadFile (CAKE_FILE_URL, CAKE_FILE);
}

CakeExecuteScript (CAKE_FILE, cakeSettings);
