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
		- [Translucent Skin](#translucent-skin)
		- [Contemporary Skin](#contemporary-skin)
	- [Advanced UI](#advanced-ui)
	- [Using the Advanced UI Manager](#using-the-advanced-ui-manager)
		- [Localization](#localization)
- [Configuring Country Code Availability for SMS](#configuring-country-code-availability-for-sms)
	- [Whitelisting Country Codes](#whitelisting-country-codes)
	- [Blacklisting Country Codes](#blacklisting-country-codes)
		- [Default Country Code](#default-country-code)

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

The following images of email and SMS screens show the classic skin without a background image, with a background image and a white tint, and with an image and a black tint:

<p>
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17625995_1634207839939850_6051199768594481152_n.jpg?_nc_cat=0&_nc_eui2=v1%3AAeFhvkpVZ2BMEKmgd5GpMIewT5Td3eiE8u1tSnMm9OvNJxBLU00XZMY5pojWnJLh9tmksahUCkh6O1FYPaEIaFhkhUejtt2btVkOcVc5l9-d4g&oh=2c353d9b003393868d992fb1b682d70b&oe=5B55FF51" />
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17636447_291368214609973_5285817423713271808_n.jpg?_nc_cat=0&_nc_eui2=v1%3AAeFxWXkPuYlCLH8FZGhdko5Q90NFd1DHcwgahiVYk8MPsUqAkq1fe4Ok4kzSnAvdEOQuVqSLcmZ4UP3OfwCOnhci5qEDv4pXP5ZD7aGs-OzprA&oh=cfbdb8f5b446e6dfa08009d6bf9a4243&oe=5B89C174" />
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17527818_1406262429424711_1054494267365392384_n.jpg?_nc_cat=0&_nc_eui2=v1%3AAeFojOISnVL9fJpdAzvS8q32awBoJ-O1tBg7K508K9GpBhQLHXGRvyVgEyC_d68AAkxqjuyGsW-5I8uFANIKWsyLS4bLuzqe0MbfHakFKe6-6A&oh=6cb6e1e77403423d29d3b31a6e254f3e&oe=5B98F0E3" />
</p>

The other screens in the login flow follow the skin and options you choose. For example, the following verification screen represents the classic skin with a background image and a white tint:

<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17639068_254973868298833_7409600188043493376_n.png?_nc_cat=0&_nc_eui2=v1%3AAeGN-F2yGbCLtgxY6p2ASZ4422WrF4pn9b4avIiTx40SzUr5IX2bfAtItAQ_brY9xGKsc8LaGj9zjyEbMycUs9wr15Dq8NjaRkCRfViACSFssQ&oh=0c89fa55038b7bd49360914b96a59b42&oe=5B8CB45B" />

### Translucent Skin

The following pictures illustrate the translucent skin without a background image, with an background image and a white tint:

<p>
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17632948_797901453707374_6222656271800074240_n.png?_nc_cat=0&_nc_eui2=v1%3AAeFoNcZE1lvVO9hyatBtBdMF7QpXlnc9Ffn4MQgrF8LzGiFbE2TO7lzNYIpXANeMmP5oWzUFhPm3u5MAel8yaOhNc06TsjGrVWXD7JkiOlt-6w&oh=b8e2ff0d6fa3b774a5bf9ebc3a5d8380&oe=5B4F11A4" />
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17636445_407428996303861_4095262062744174592_n.png?_nc_cat=0&_nc_eui2=v1%3AAeHNYtEDNdUxFajYtoe8aAtAjXjhFM4KHC10fuZwTMOz_aURqt0AxCYkyjyoJE4A9DH2SSW1AwbPhxIMANjR-2oTVEIPS1_1KFZ51EF-zQYt7Q&oh=f616d49ac01b5000ae436815fb4104d8&oe=5B93875F" />
</p>

### Contemporary Skin

The following pictures illustrate the contemporary skin without a background image, with an background image and a white tint, and with an image and a black tint:

<p>
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17629506_1870188546594316_4786104039022526464_n.png?_nc_cat=0&_nc_eui2=v1%3AAeGEVjhhzxgHu8jQBLLXVN16mNUWpMxXfNxDd4MV-_0K6FcdShnf5THzOqi7DagNQs834KCjrd22KnYTZrEAvVoEkLpFUwN2nZ60PVX8LjwzJQ&oh=7b2dac9077e4646e28f0a86dd511c230&oe=5B89928B" />
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17632896_733823170122153_1795678981249302528_n.png?_nc_cat=0&_nc_eui2=v1%3AAeEx6gltfpplLE7Ht9MQQt-doGUl51g-TKaX05ko77aebsNEEN__v8yLZnUY9qlKBc1_3SwZLWs93gFaMKWU6OAnsPhqTuFf6AvRQy5qYUzrWQ&oh=054a0d465f9a5d469e984fe12ce67976&oe=5B9615B0" />
	<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17636453_773062582868962_3494230171907522560_n.png?_nc_cat=0&_nc_eui2=v1%3AAeHzumXZQsxDKwXE9yqsHC3-2g59AWExzZUSeWGupVLuXZ746kLZzEfUvNCrJ3wgGkcJdFe1jvA4w01v9EpHopnObve8LSFKP9cSbGj34Xo37w&oh=23f7ffe934f847d01157ccd9cb7f2b86&oe=5B93B9BF" />
</p>

The following code shows how to create a skin without a background image:

```csharp
// Constructor for a skin without a background image

// Init AccountKit
AccountKit accountKit;
accountKit = new AccountKit (ResponseType.AccessToken);

// Set view controller:
UIViewController viewController;

// --either-- Phone number login:
viewController = accountKit.GetViewControllerForPhoneLogin (null, null);

// --or-- Email login:
viewController = accountKit.GetViewControllerForEmailLogin (null, null);

// skinType can be SkinType.Classic, SkinType.Translucent, or SkinType.Contemporary
viewController.AsIViewControllerProtocol ().UiManager = new SkinManager («SkinType», «UIColor»);

// -- or --
// Constructor using the default theme color
viewController.AsIViewControllerProtocol ().UiManager = new SkinManager («SkinType»);
```

The following codes shows how to create a skin with a background image:

```csharp
// Constructor for a skin with a background image

// Init AccountKit
AccountKit accountKit;
accountKit = new AccountKit (ResponseType.AccessToken);

// Set view controller:
UIViewController viewController;

// --either-- Phone number login:
viewController = accountKit.GetViewControllerForPhoneLogin (null, null);

// --or-- Email login:
viewController = accountKit.GetViewControllerForEmailLogin (null, null);

// skinType can be SkinType.Classic, SkinType.Translucent, or SkinType.Contemporary
// backgroundTint is either BackgroundTint.White or BackgroundTint.Black
// tintIntensity is a number between 0.55 and 0.85
viewController.AsIViewControllerProtocol ().UiManager = new SkinManager («SkinType», «UIColor», «UIImage», «BackgroundTint», «nfloat»);
```

## Advanced UI

The advanced UI gives you the ability to customize many elements of the interface independently. With the advance UI, you can customize the following elements:

<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/16686725_265801823847783_8569343337666969600_n.png?_nc_cat=0&_nc_eui2=v1%3AAeEBSEVBZ61mBgCKlmQDTZMQf-IkOlzBAM-S1s7OalUfdrG4IeM8WcwMN9IKPoL4S2GGP6Rx1a8oXb-Abv29inriCcj5E6TJrIjKiNL1U4bR0g&oh=0d0233e6cb103fc32f3915393fa607bf&oe=5B53486F" />

> ![note_icon] **_Note_**: _Please don't obscure any elements of the Account Kit user interface when you adjust the text and background colors. This is required by our platform policy._

The following table provides the full set of customizable options.

| Property Name         | Description                                                         |
|-----------------------|---------------------------------------------------------------------|
| BackgroundColor       | Color for the background of the UI if an image is not used          |
| ButtonBackgroundColor | Color for the background of the buttons                             |
| ButtonBorderColor     | Color for the borders of buttons                                    |
| ButtonTextColor       | Color for the text on buttons                                       |
| IconColor             | Color for icons                                                     |
| InputBackgroundColor  | Color for the background of the input boxes.                        |
| InputBorderColor      | Color of the input boxes' border                                    |
| InputTextColor        | Text color of the input text for Phone Number and Confirmation Code |
| StatusBarStyle        | Style for the status bar at the top                                 |
| TextColor             | Color for text                                                      |

> ![note_icon] **_Note_**: If you specify a `BackgroundImage`, make sure your `BackgroundColor` is at least partly transparent (`Alpha` < 1.0), or your background image will not be visible.

## Using the Advanced UI Manager

Account Kit offers deeper customization of the login UI by allowing you to define an **Advanced UI** manager. You do this by creating a class that implements the `IAdvancedUIManager` interface and implementing individual methods to return custom views to be inserted in the login UI. For each view you want to customize, you must provide customizations appropriate to the current state of the login flow.

Create a new interface in `MyUIManager` class.

```csharp
using Facebook.AccountKit;

public class MyUIManager : NSObject, IUIManager {
	public ButtonType ConfirmButtonType { get; private set; }
	public ButtonType EntryButtonType { get; private set; }
	public Theme Theme { get; set; }
}
```

The `IUIManager` protocol lets you define the following customization points. This is how the protocol is defined:

```csharp
public interface IActionController : INativeObject, IDisposable
{
	void Back ();
	void Cancel ();
}

public static class IUIManager_Extensions
{
	public static UIView GetActionBarView (this IUIManager This, LoginFlowState state);
	public static UIView GetBodyView (this IUIManager This, LoginFlowState state);
	public static ButtonType GetButtonType (this IUIManager This, LoginFlowState state);
	public static UIView GetFooterView (this IUIManager This, LoginFlowState state);
	public static UIView GetHeaderView (this IUIManager This, LoginFlowState state);
	public static TextPosition GetTextPosition (this IUIManager This, LoginFlowState state);
	public static Theme GetTheme (this IUIManager This);
	public static void SetActionController (this IUIManager This, IActionController actionController);
	public static void SetError (this IUIManager This, NSError error);
}
```

Each UIView returned by these methods corresponds to a section on the UI:

<img height=400 src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/17636471_619551801572363_5108454034805620736_n.png?_nc_cat=0&_nc_eui2=v1%3AAeHWJE1kZC2qBWJwEG_PkfgrY6l4VUv8BPelHMUsnVU_M9qFm2nc_qNWt3SJoE_JsdHunkszYoKik6ScjYpgFVBoih_9j6Zsre2hszmZPGAaWw&oh=c4d343550cd4ce2efbc59cda6e42e44c&oe=5B9D8EB5" />

If you do not wish to customize a section of the UI, simply either do not implement the method, or return `null` to fall back to the default view for that portion of the screen.

The `IActionController` is the means to communicate back to Account Kit whether we want to go back to the previous screen or cancel the login flow. You'll need to maintain a handle to this action controlled inside your UI manager if you wish to perform these actions.

The following code shows how to implement an advanced UI manager:

```csharp
public class MyUIManager : NSObject, IUIManager {
	public ButtonType ConfirmButtonType { get; private set; }
	public ButtonType EntryButtonType { get; private set; }
	public Theme Theme { get; set; }

	IActionController actionController;

	[Export ("setActionController:")]
	void SetActionController (IActionController actionController)
	{
		this.actionController = actionController;
	}

	[Export ("buttonTypeForState:")]
	ButtonType GetButtonType (LoginFlowState state)
	{
		switch (state) {
		case LoginFlowState.CodeInput:
			return ConfirmButtonType;
		case LoginFlowState.PhoneNumberInput:
		case LoginFlowState.EmailInput:
			return EntryButtonType;
		default:
			return ButtonType.Default;
		}
	}
}
```

This example changes the text on the "submit" button of the email or phone number input to be `EntryButtonType` and for the code verification screen to be `ConfirmButtonType`, and leaves all the other buttons to be the default value for Account Kit.

### Localization

Localization support is also provided by the SDK. The [supported languages][7] are packaged with the SDK. You don't need anything else to display text in the appropriate locale.

---

# Configuring Country Code Availability for SMS

By default, the Account Kit SDK allows users to enter a phone number for any country code supported by Account Kit. For the list of supported country codes, see [SMS Country Codes][8]. You can customize availability by setting either a country code whitelist or a country code blacklist in the `LoginViewController`. The following table shows the possible combinations of lists and the results:

| Lists                     | Result |
|---------------------------|--------|
| No whitelist or blacklist | All country codes supported by Account Kit are available. |
| Whilelist                 | Only country codes in the whitelist are available. |
| Blacklist                 | All country codes supported by Account Kit except those in the blacklist are available. |
| Whitelist and blacklist   | Only the country codes in the whitelist that are not also in the blacklist are available. Note that the blacklist takes priority for codes that are in both lists. |

## Whitelisting Country Codes

Whitelisting a set of countries restricts the country code selector to only those countries in the whitelist. Specify a whitelist array in `loginViewController.WhitelistedCountryCodes`.

The value is an array of 2-letter country codes as defined by **ISO 3166-1 Alpha 2**. The following example restricts availability to just the **US +1** and the **Netherlands +31**:

```csharp
void PrepareLoginViewController (IViewController controller)
{
	...
	loginViewController.WhitelistedCountryCodes = new [] { "US", "NL" };
	...
}
```

## Blacklisting Country Codes

Blacklisting a set of countries allows a user to use all of Account Kit's supported countries except those defined in the blacklist. Set a blacklist in `loginViewController.BlacklistedCountryCodes`.

Just like the whitelist, the value is an array of short country codes as defined by **ISO 3166-1 Alpha 2**. The following example allows access everywhere that Account Kit is supported, except **ID +62**:

```csharp
void PrepareLoginViewController (IViewController controller)
{
	...
	loginViewController.BlacklistedCountryCodes = new [] { "ID" };
	...
}
```

### Default Country Code

You can configure your default country code by setting a country code in `loginViewController.DefaultCountryCode`. The following example sets the default country code to the **US +1**:

```csharp
void PrepareLoginViewController (IViewController controller)
{
	...
	loginViewController.DefaultCountryCode = "US";
	...
}
```

[1]: https://developers.facebook.com/apps/
[2]: https://developers.facebook.com/docs/accountkit/accesstokens
[3]: https://developers.facebook.com/docs/accountkit/graphapi
[4]: https://developers.facebook.com/docs/accountkit/appeventsanalytics
[5]: https://developers.facebook.com/docs/accountkit/graphapi#at-validation
[6]: https://developers.facebook.com/docs/accountkit/bestpractices/#customizeui
[7]: https://developers.facebook.com/docs/accountkit/languages
[8]: https://developers.facebook.com/docs/accountkit/countrycodes
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png