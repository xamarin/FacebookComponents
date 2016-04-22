**(Requires iOS 7 or later.)**

Integrate with Facebook for your iOS app. Build engaging social apps, enable easy login and get more installs:

* **Share:** You can share, send a message, or like content in your app. Also, share Custom Stories with Open Graph.
* **Login:** You can sign in to your app with their Facebook Login.
* **App Events:** Understand people's actions in your app and measure the effectiveness of your Mobile App Ads.
* **Graph API:** Get data in and out of Facebook's social graph. Query data, post stories, upload photos and do other tasks.
* **App Links:** Link to a context in your app.

### AppDelegate.cs

```csharp

using Facebook.CoreKit;
//...

// Replace here you own Facebook App Id and App Name, if you don't have one go to
// https://developers.facebook.com/apps
string appId = "Your-Id-Here";
string appName = "Your_App_Display_Name";

public override bool FinishedLaunching (UIApplication app, NSDictionary options)
{
	Settings.AppID = FacebookAppId;
	Settings.DefaultDisplayName = DisplayName;
	// ...
	
	// This method verifies if you have been logged into the app before, and keep you logged in after you reopen or kill your app.
	return ApplicationDelegate.SharedInstance.FinishedLaunching (application, launchOptions);
}

public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
{
	// We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
	return ApplicationDelegate.SharedInstance.OpenUrl (application, url, sourceApplication, annotation);
}

```

### YourViewController.cs

```csharp

using Facebook.LoginKit;
using Facebook.CoreKit;
//...

// To see the full list of permissions, visit the following link:
// https://developers.facebook.com/docs/facebook-login/permissions/v2.3

// This permission is set by default, even if you don't add it, but FB recommends to add it anyway
List<string> readPermissions = new List<string> { "public_profile" };

LoginButton loginView;
ProfilePictureView pictureView;

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	
	loginButton = new LoginButton (new CGRect (48, 0, 218, 46)) {
		LoginBehavior = LoginBehavior.Native,
		ReadPermissions = readPermissions.ToArray ()
	};
	
	// Handle actions once the user is logged in
	loginView.Completed += (sender, e) => {
		if (e.Error != null) {
			// Handle if there was an error
		}
		
		if (e.Result.IsCancelled) {
			// Handle if the user cancelled the login request
		}
		
		// Handle your successful login
	};

	// Handle actions once the user is logged out
	loginView.LoggedOut += (sender, e) => {
		// Handle your logout
	};

	// The user image profile is set automatically once is logged in
	pictureView = new ProfilePictureView (new CGRect (50, 0, 220, 220));

	// Add views to main view
	View.AddSubview (loginView);
	View.AddSubview (pictureView);
}

```

### Info.plist

In you Info.plist file of your project, go to the `Advanced` tab and add a `URL Type`. On the `URL Schemes` input write `fbYour-Id-Here`, replacing `Your-Id-Here` with your app Id.

### Controlling the login dialogs

The Facebook SDK automatically selects the optimal login dialog flow based on the account settings and capabilities of a person's device.

If you want to use your System Account of Settings, just change the FB Login's behavior:

```csharp

loginView.LoginBehavior = LoginBehavior.SystemAccount;

```

*Screenshot generated with [PlaceIt](http://placeit.breezi.com/).*