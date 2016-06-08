The Facebook SDK for iOS makes it easier and faster to develop Facebook integrated iOS apps.

## Integration with iOS 9

### Whitelist Facebook Servers for Network Requests

If you compile your app with iOS SDK 9.0, you will be affected by [App Transport Security][1]. Currently, you will need to whitelist Facebook domains in your app by adding the following to your application's Info.plist:

```
<key>NSAppTransportSecurity</key>
<dict>
    <key>NSExceptionDomains</key>
    <dict>
        <key>facebook.com</key>
        <dict>
            <key>NSIncludesSubdomains</key>
            <true/>                
            <key>NSThirdPartyExceptionRequiresForwardSecrecy</key>
            <false/>
        </dict>
        <key>fbcdn.net</key>
        <dict>
            <key>NSIncludesSubdomains</key>
            <true/>
            <key>NSThirdPartyExceptionRequiresForwardSecrecy</key>
            <false/>
        </dict>
        <key>akamaihd.net</key>
        <dict>
            <key>NSIncludesSubdomains</key>
            <true/>
            <key>NSThirdPartyExceptionRequiresForwardSecrecy</key>
            <false/>
        </dict>
    </dict>
</dict>
```

### Whitelist Facebook Apps

If you use any of the Facebook dialogs (e.g., Login, Share, App Invites, etc.) that can perform an app switch to Facebook apps, you will need to update your application's plist to handle the changes to `CanOpenUrl` described in https://developer.apple.com/videos/wwdc/2015/?id=703

If you're recompiling with iOS SDK 9.0, add the following to your application's plist *if you're using a version of the SDK v4.5 or older*:

```
<key>LSApplicationQueriesSchemes</key>
<array>
    <string>fbapi</string>
    <string>fbapi20130214</string>
    <string>fbapi20130410</string>
    <string>fbapi20130702</string>
    <string>fbapi20131010</string>
    <string>fbapi20131219</string>    
    <string>fbapi20140410</string>
    <string>fbapi20140116</string>
    <string>fbapi20150313</string>
    <string>fbapi20150629</string>
    <string>fbauth</string>
    <string>fbauth2</string>
    <string>fb-messenger-api20140430</string>
</array>
```

If you're using `Facebook.MessengerShareKit` from versions older than the v4.6 release, also add:

```
<string>fb-messenger-platform-20150128</string>
<string>fb-messenger-platform-20150218</string>
<string>fb-messenger-platform-20150305</string>
```

If you're using v4.6.0 of the SDK, you only need to add:

```
<key>LSApplicationQueriesSchemes</key>
<array>
        <string>fbapi</string>
        <string>fb-messenger-api</string>
        <string>fbauth2</string>
        <string>fbshareextension</string>
</array>
```

This will allow the Facebook SDK integration to properly identify installed Facebook apps to perform an app switch. If you are not recompiling with iOS SDK 9.0, your app is limited to 50 distinct schemes (calls to `CanOpenURL` afterwards return *false*).

## Sample

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
	// This is false by default,
	// If you set true, you can handle the user profile info once is logged into FB with the Profile.Notifications.ObserveDidChange notification,
	// If you set false, you need to get the user Profile info by hand with a GraphRequest
	Profile.EnableUpdatesOnAccessTokenChange (true);
	Settings.AppID = appId;
	Settings.DisplayName = appName;
	//...
	
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
UILabel nameLabel;

public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	// If was send true to Profile.EnableUpdatesOnAccessTokenChange method
	// this notification will be called after the user is logged in and
	// after the AccessToken is gotten
	Profile.Notifications.ObserveDidChange ((sender, e) => {

		if (e.NewProfile == null)
			return;
		
		nameLabel.Text = e.NewProfile.Name;
	});

	// Set the Read and Publish permissions you want to get
	loginView = new LoginButton (new CGRect (51, 0, 218, 46)) {
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
	pictureView = new ProfilePictureView (new CGRect (50, 50, 220, 220));

	// Create the label that will hold user's facebook name
	nameLabel = new UILabel (new RectangleF (20, 319, 280, 21)) {
		TextAlignment = UITextAlignment.Center,
		BackgroundColor = UIColor.Clear
	};

	// Add views to main view
	View.AddSubview (loginView);
	View.AddSubview (pictureView);
	View.AddSubview (nameLabel);
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

## Documentation

* SDK Reference: [https://developers.facebook.com/docs/reference/ios/current/](https://developers.facebook.com/docs/reference/ios/current/)

## Contact & Discuss

* Bugs Tracker: [https://developers.facebook.com/bugs](https://developers.facebook.com/bugs)
* StackOverflow: [http://facebook.stackoverflow.com/questions/tagged/facebook-ios-sdk](http://facebook.stackoverflow.com/questions/tagged/facebook-ios-sdk)