# Facebook Account Kit for iOS

## Table of content

- [Facebook Account Kit for iOS](#facebook-account-kit-for-ios)
	- [Table of content](#table-of-content)
	- [1. Select an App or Create a New App](#1-select-an-app-or-create-a-new-app)
	- [2. Choose Your App Settings](#2-choose-your-app-settings)
	- [3. Set up Your Developer Environment](#3-set-up-your-developer-environment)
		- [Configure the SDK](#configure-the-sdk)
		- [Initialize the SDK](#initialize-the-sdk)
	- [4. Configure Login View Controller](#4-configure-login-view-controller)
		- [UI Theming](#ui-theming)
	- [5. Handle Different Login States](#5-handle-different-login-states)
		- [6. Initiate a Login Flow for SMS](#6-initiate-a-login-flow-for-sms)
	- [7. Initiate a Login Flow for Email](#7-initiate-a-login-flow-for-email)
	- [8. Handle Login Callback](#8-handle-login-callback)
	- [9. Access Account Information](#9-access-account-information)
	- [10. Provide the Logout Flow](#10-provide-the-logout-flow)
- [Customizing the Account Kit UI for iOS](#customizing-the-account-kit-ui-for-ios)
	- [Basic UI](#basic-ui)
		- [Classic Skin](#classic-skin)

## 1. Select an App or Create a New App

Select an [app or create a new one][1]. Then, click on the **+** icon next to the **PRODUCTS** label to add **Account Kit**.

## 2. Choose Your App Settings

Choose whether to allow email and SMS login, and choose security settings for your app. For more information on choosing your access token setting, see [Access Tokens][2], and for information on choosing your app secret setting, see [Using the Graph API][3].

## 3. Set up Your Developer Environment

### Configure the SDK

Add both your **Facebook App ID** and **Account Kit Client Token** to your **Info.plist** file as strings. Make sure you have enabled Account Kit in the App Dashboard. You'll find the Account Kit client token in the Account Kit section of the App Dashboard. The application name will be used in the UI on the login screen.

```xml
<plist version="1.0">
<dict>
  <key>FacebookAppID</key>
  <string>{your-app-id}</string>
  <key>AccountKitClientToken</key>
  <string>{your-account-kit-client-token}</string>
  <key>CFBundleURLTypes</key>
  <array>
    <dict>
      <key>CFBundleURLSchemes</key>
      <array>
        <string>ak{your-app-id}</string>
      </array>
    </dict>
  </array>
  ...
</dict>
</plist>
```

If you wish to disable App Events for your Account Kit application, add the following entry to your **Info.plist** file inside the <dict> tag:

```xml
<key>AccountKitFacebookAppEventsEnabled</key>
<integer>0</integer>
```

By default, this flag is set to `1`. See [App Events and Analytics][4] for more information.

### Initialize the SDK

In your initial view controllers, add the `Facebook.AccountKit` namespace and declare an `accountKit` variable to manage all Account Kit interactions. Declare the view controller to be an implementer of `IViewControllerDelegate`.

```csharp
using Facebook.AccountKit;

public partial class LoginViewController : UIViewController, IViewControllerDelegate
{
	AccountKit accountKit;
	UIViewController pendingLoginViewController;
}
```

When your initial view controller is loaded, check and initialize your `accountKit` variable. Be sure the response type you use to initialize Account Kit matches the one selected in your app's dashboard in the Facebook developer portal, either `ResponseType.AccessToken` or `ResponseType.AuthorizationCode`.

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	// initialize Account Kit
	if (accountKit == null)
		// may also specify AKFResponseTypeAccessToken
		accountKit = new AccountKit (ResponseType.AccessToken); //Or use Code

	// view controller for resuming login
	pendingLoginViewController = accountKit.GetViewControllerForLoginResume ();
}
```

## 4. Configure Login View Controller

You can configure your login view controller with the following parameters:

| Parameter              | Description |
|------------------------|-------------|
| `Delegate`             | `IViewControllerDelegate`: Pass in the delegate handling the login callback. |
| `EnableSendToFacebook` | `BOOL`: Set to `true` to allow receiving Facebook notifications (if available) as a backup method of verification. |
| `EnableGetACall`       | `BOOL`: Set to `true` to allow receiving phone calls as backup verification method. |
| `UiManager`            | `IUIManager`: Pass in either an instance of `SkinManager` or a class implementing `IAdvancedUIManager` if you would like to use the Advanced UI. Otherwise you can pass in `null`. For more information, see [Customizing the UI](#customizing-the-account-kit-ui-for-ios). |

The delegate for your `LoginViewController` must implement the `IViewControllerDelegate` protocol. All of the protocol methods are optional, but you should at least handle successful login callbacks for the login flows (SMS or Email) that you use in your app. Set up your main view controller to receive login callbacks:

```csharp
using Facebook.AccountKit;

public partial class LoginViewController : UIViewController, IViewControllerDelegate
{
	...
}
```

Prepare the Account Kit login view controller by setting a delegate as shown in the following code block.

```csharp
void PrepareLoginViewController (IViewController loginViewController)
{
	loginViewController.Delegate = this;
	// Optionally, you may set up backup verification methods.
	loginViewController.EnableSendToFacebook = true;
	loginViewController.EnableGetACall = true;
}
```

### UI Theming

(optional) You can create a classic skin UI with blue color using the following code:

```csharp
loginViewController.UiManager = new SkinManager (SkinType.Classic, UIColor.Blue);
```

You may apply a theme or use the _Advanced UI Manager_ if you want to customize the user interface. For more information, see [Customizing the UI](#customizing-the-account-kit-ui-for-ios).

## 5. Handle Different Login States

When your initial view controller appears, you should bypass the login view controller if the user is already logged in. It will also resume pending logins if any are present.

Your view controller needs to maintain a handle to an `AccountKit` object at all times. You can declare this using the following code:

```csharp
public partial class ViewController : UIViewController, IViewControllerDelegate
{
	AccountKit accountKit;
}
```

To initialize Account Kit, we recommend doing this in the `ViewDidLoad` event of your view controller. The following code initializes Account Kit to use the token access flow:

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	accountKit = new AccountKit (ResponseType.AccessToken);
}
```

If your app receives the user's access token directly (because the **Enable Client Access Token Flow** switch in your app's dashboard is ON), then you should check for a valid, existing token using `accountKit.CurrentUserToken`.

```csharp
public override void ViewWillAppear (bool animated)
{
	base.ViewWillAppear (animated);
	if (accountKit.CurrentAccessToken != null) {
		// if the user is already logged in, go to the main screen
		ProceedToMainScreen ();
	} else {
		// Show the login screen
		ShowLoginControls ();
	}
}
```

If your app receives an authorization code that it will pass to the server (because the **Enable Client Access Token Flow** switch in your app's dashboard is OFF), it is up to you to have your server communicate the correct login status to your client application and return that.

For more information on access tokens and authorization codes, see [Access Tokens and Authorization Codes][2].

### 6. Initiate a Login Flow for SMS

In your initial view controller, create a phone login handler to invoke when the login button is clicked by the user. There are two important parameters shown in the code below:

| Parameter     | Description |
|---------------|-------------|
| phoneNumber   | `PhoneNumber` Pass this to pre-fill the phone number field in the phone login flow. Use `null` to skip pre-filling. |
| state         | `string` This should be a random, non-guessable value. Any value passed via this parameter will be returned with the login response; compare the value in the response with this value to verify that the response you received was for the request you issued. |

```csharp
void LoginWithPhone (NSObject sender)
{
	PhoneNumber phoneNumber = null;
	var state = new NSUuid ().AsString ();
	var viewController = accountKit.GetViewControllerForPhoneLogin (phoneNumber, state);
	PrepareLoginViewController (viewController.AsIViewControllerProtocol ()); // see above
	PresentViewController (viewController, true, null);
}
```

## 7. Initiate a Login Flow for Email

In your initial view controller, create an email login handler to invoke when the login button is clicked by the user. There are two important parameters shown in the code below:

| Parameter | Description |
|-----------|-------------|
| `email`   | `string` Pass this to pre-fill the email address field in the email login flow. Use `null` to skip pre-filling. |
| `state`   | `string` This should be a random, non-guessable value. Any value passed via this parameter will be returned with the login response; compare the value in the response with this value to verify that the response you received was for the request you issued. |

```csharp
void LoginWithEmail (NSObject sender)
{
	string email = null;
	var state = new NSUuid ().AsString ();
	var viewController = accountKit.GetViewControllerForEmailLogin (email, state);
	PrepareLoginViewController (viewController.AsIViewControllerProtocol ()); // see above
	PresentViewController (viewController, true, null);
}
```

## 8. Handle Login Callback

How you handle a login depends on whether your app uses an access token or an authorization code. For more information, see [Access Tokens and Authorization Codes][2].

To handle a successful login in Access Token mode:

```csharp
[Export ("viewController:didCompleteLoginWithAccessToken:state:")]
public void DidCompleteLogin (UIViewController viewController, IAccessToken accessToken, string state)
{
	ProceedToMainScreen ();
}
```

To handle a successful login in Authorization Code mode:

```csharp
[Export("viewController:didCompleteLoginWithAuthorizationCode:state:")]
public void DidCompleteLogin (UIViewController viewController, string code, string state)
{
	// Pass the code to your own server and have your server exchange it for a user access token.
	// You should wait until you receive a response from your server before proceeding to the main screen.
	SendAuthorizationCodeToServer (code);
	ProceedToMainScreen ();
}
```

You may also handle a failed or canceled login:

```csharp
[Export ("viewController:didFailWithError:")]
public void DidFail (UIViewController viewController, NSError error)
{
	// ... implement appropriate error handling ...
	Console.WriteLine($"{nameof (ViewController)} did fail with error: {error.LocalizedDescription}");
}

[Export ("viewControllerDidCancel:")]
public void DidCancel (UIViewController viewController)
{
	// ... handle user cancellation of the login process ...
}
```

## 9. Access Account Information

Once you have successfully logged in, you can access account information. For example, to display the account ID and the login credential used in access token mode:

```csharp
accountKit.RequestAccount (HandleRequestAccount);

void HandleRequestAccount (IAccount account, NSError error)
{
	// account ID
	LblAccountId.Text = account.AccountId;
	LblTitle.Text = account.PhoneNumber != null ? "Phone Number" : "Email Address";
	LblValue.Text = account.PhoneNumber?.GetStringRepresentation () ?? account.EmailAddress;
}
```

To display the account ID and the login credential used in Authorization Code mode, call your server to use the Graph API with the exchanged access token stored on your server (see [Access Token Validation][5]) and have your server pass the account ID and credential back to your app.

## 10. Provide the Logout Flow

You can invoke the `LogOut` method to log a user out of Account Kit:

```csharp
accountKit.LogOut();
```

---

# Customizing the Account Kit UI for iOS

The user interface for the login screens is provided by the SDK. You can customize this user interface to match your app. For guidelines on customizing the UI, see [Customize the UI in Best Practices][6].

Account Kit offers two ways to customize the the user interface:

* [Basic UI](#basic-ui) with three skins and limited customizability
* [Advanced UI](#avanced-ui) with the ability to customize individual elements

## Basic UI

The basic UI offers three skins to choose from:

* Classic
* Translucent
* Contemporary

For each skin you can optionally add a background image. If you add a background image, you can also choose a color and the background tint opacity as a value between 55-85%. The background tint also determines the color of the disclosure text, whether the text appears in black disclosure on a white background, or white on a black background.

The skin and the options you choose control the appearance of phone-number and email screens and all other screens in the login flow.

### Classic Skin

The following images of email and SMS screens show the classic skin without a background image, with a background image and a white tint, and with an image and a black tint.

<p>
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17625995_1634207839939850_6051199768594481152_n.jpg?_nc_cat=0&_nc_eui2=v1%3AAeFhvkpVZ2BMEKmgd5GpMIewT5Td3eiE8u1tSnMm9OvNJxBLU00XZMY5pojWnJLh9tmksahUCkh6O1FYPaEIaFhkhUejtt2btVkOcVc5l9-d4g&oh=2c353d9b003393868d992fb1b682d70b&oe=5B55FF51" />
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17636447_291368214609973_5285817423713271808_n.jpg?_nc_cat=0&_nc_eui2=v1%3AAeFxWXkPuYlCLH8FZGhdko5Q90NFd1DHcwgahiVYk8MPsUqAkq1fe4Ok4kzSnAvdEOQuVqSLcmZ4UP3OfwCOnhci5qEDv4pXP5ZD7aGs-OzprA&oh=cfbdb8f5b446e6dfa08009d6bf9a4243&oe=5B89C174" />
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17527818_1406262429424711_1054494267365392384_n.jpg?_nc_cat=0&_nc_eui2=v1%3AAeFojOISnVL9fJpdAzvS8q32awBoJ-O1tBg7K508K9GpBhQLHXGRvyVgEyC_d68AAkxqjuyGsW-5I8uFANIKWsyLS4bLuzqe0MbfHakFKe6-6A&oh=6cb6e1e77403423d29d3b31a6e254f3e&oe=5B98F0E3" />
</p>


[1]: https://developers.facebook.com/apps/
[2]: https://developers.facebook.com/docs/accountkit/accesstokens
[3]: https://developers.facebook.com/docs/accountkit/graphapi
[4]: https://developers.facebook.com/docs/accountkit/appeventsanalytics
[5]: https://developers.facebook.com/docs/accountkit/graphapi#at-validation
[6]: https://developers.facebook.com/docs/accountkit/bestpractices/#customizeui
