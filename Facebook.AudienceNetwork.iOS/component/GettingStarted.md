# Getting Started with the Facebook Audience Network

Facebook's Audience Network allows you to monetize your iOS app with targeted ads. Please, follow [this guide][1] to walks you through steps to get started on Audience Network.

---

# Preparing Your Audience Network Integration For App Transport Security (ATS)

[App Transport Security (ATS)][11] is a privacy feature introduced in iOS 9. It's enabled by default for new applications and enforces secure connections. This guide will review actions you should take to ensure you are prepared when using the Facebook SDK for iOS.

## Audience Network SDK is built to be 100% compliant.

Part of being compliant is leveraging `SFSafariViewController` for displaying content. `SFSafariViewController` by default disables ATS. You do not need to enable any exceptions in your configuration for ads to be delivered from Audience Network.

---

# Adding the Native Ad API in iOS

The Native Ad API allows you to build a customized experience for the ads you show in your app. When using the Native Ad API, instead of receiving an ad ready to be displayed, you will receive a group of ad properties such as a title, an image, a call to action, and you will have to use them to construct a custom `UIView` where the ad is shown.

> ![information_icon] _Please consult our [guidelines for native ads][2] when designing native ads in your app._

Let's implement the following native ad placement. You will create the following views to our native ad.

* **View #1:** advertiser icon
* **View #2:** ad title
* **View #3:** sponsored label
* **View #4:** advertiser choice
* **View #5:** ad media view
* **View #6:** social context
* **View #7:** ad body
* **View #8:** ad call to action button

![adImage](https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15119831_604335559772201_4765472987522531328_n.png?oh=22c58081ee60e967200d36ad28fcfe81&oe=5B4D8C88)

## Step 1: Create Native Ad Views in Storyboard

> ![information_icon] _When designing native ads and banner ads, ensure you have followed [iOS layout guideline][3] for optimal user experience._

> ![information_icon] _If you want to use the Xcode designer instead of Visual Studio designer to create the Native Ad View, plaese, read the first step of this [guide][4]._

1. Open the **MainStoryboard.storyboard** file in Visual Studio and add a `UIView` element to the main View element and name it to `AdUIView`. In addition, add an `ImgAdIcon` (UIImageView), `LblAdTitle` (UILabel), `AdCoverMediaView` (FBMediaView), `LblAdSocialContext` (UILabel), `BtnAdCallToActiona` (UIButton), `AdChoiceView` (FBAdChoicesView), `LblAdBody` (UILabel), `LblSponsored` (UILabel) under `AdUIView` as illustrated in the image below.

	<image src="./screenshots/1.png" width="800" />

2. Add the necessary constraints to the view.
3. Build and run the project. You should see from your device or simulator empty content as follows: 

	<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15186225_1112058292183318_3645203031185686528_n.png?oh=115fbf575ca427d6f747b93fc3fffbba&oe=5B3EC0E7" height="500" />

Now that you have created all the UI elements to show native ads, the next step is to load the native ad and bind the contents to the UI elements.

## Step 2: Load and Show Native Ad

1. Now, in your View Controller file, import the `Facebook.AudienceNetwork` namespace, declare that `ViewController` implements the `INativeAdDelegate` protocol and add a nativeAd instance variable:

	```csharp
	using Facebook.AudienceNetwork;

	namespace YourApp
	{
		public partial class ViewController : UIViewController, INativeAdDelegate
		{
			NativeAd nativeAd;
		}
	}
	```

2. In `ViewDidLoad` method, add the following lines of code to load native ad content:

	```csharp
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		// Perform any additional setup after loading the view, typically from a nib.

		nativeAd = new NativeAd ("Native_Placement_Id") { 
			Delegate = this,
			MediaCachePolicy = NativeAdsCachePolicy.All
		};
		nativeAd.LoadAd ();
	}
	```

	Replace `Native_Placement_Id` with your own placement id string. If you don't have a placement id or don't know how to get one, you can refer to the [Getting Started Guide][5].

	Set `MediaCachePolicy` to be `NativeAdsCachePolicy.All`. This will configure native ad to wait to call `NativeAdDidLoad` until all ad assets are loaded.

	Audience Network supports five cache options in native ads as defined in their framework:

	| Cache Constants | Description                            |
	|-----------------|----------------------------------------|
	| None            | No pre-caching, default                |
	| Icon            | Pre-cache ad icon                      |
	| Image           | Pre-cache ad images                    |
	| Video           | Pre-cache ad video                     |
	| All             | Pre-cache all (icon, images and video) |

3. The next step is to show ad when content is ready. You would need to implement `NativeAdDidLoad` method in `ViewController` file:

	```csharp
	[Export ("nativeAdDidLoad:")]
	public void NativeAdDidLoad (NativeAd nativeAd)
	{
		if (this.nativeAd != null)
			nativeAd.UnregisterView ();

		this.nativeAd = nativeAd;

		// Wire up UIView with the native ad; only call to action button and media view will be clickable.
		nativeAd.RegisterView (AdUIView, this, new UIView [] { BtnAdCallToAction, AdCoverMediaView });

		// Create native UI using the ad metadata.
		AdCoverMediaView.NativeAd = nativeAd;

		// Render native ads onto UIView
		LblAdTitle.Text = this.nativeAd.Title;
		LblAdBody.Text = this.nativeAd.Body;
		LblAdSocialContext.Text = this.nativeAd.SocialContext;
		LblSponsored.Text = "Sponsored";
		BtnAdCallToAction.SetTitle (this.nativeAd.CallToAction, UIControlState.Normal);
		AdChoiceView.NativeAd = nativeAd;
		AdChoiceView.Corner = UIRectCorner.TopRight;

		this.nativeAd.Icon.LoadImageAsync (HandleAdImageCompletion);

		void HandleAdImageCompletion (UIImage imageLoaded) => ImgAdIcon.Image = imageLoaded;
	}
	```

	First, you will need to check if there is an existing `nativeAd` object. If there is, you will need to call `UnregisterView` method. Then you will call `nativeAd.RegisterView` method.

	What `RegisterView` mainly does is register what views will be tappable and what the delegate is to notify when a registered view is tapped. In this case, `BtnAdCallToAction` and `AdCoverMediaView` will be tappable and when the view is tapped, ViewController will be notified through `INativeAdDelegate` interface. 

	`AdCoverMediaView` contains the media content, either picture or video, of the ad. You will need to call `NativeAd` property to set the content of `nativeAd` to the view. 

	You will call `LoadImageAsync` method to asynchronously load the image content of the ad icon.

	### Controlling Clickable Area

	> ![information_icon] _For a better user experience and better results, you should always consider controlling the clickable area of your ad to avoid unintentional clicks. Please refer to [Audience Network SDK Policy][6] page for more details about white space unclickable enforcement._

	For finer control of what is clickable, you can use the `nativeAd.RegisterView (UIView, UIViewController, UIView [])` overload method to register a list of views that can be clicked.

4. Choose your build target to be device and run the above code, you should see something like this:

	<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15186234_216025858806976_1785369809903419392_n.png?oh=9da8d2b4be92b4b2569ec0fceff2c571&oe=5B10EF36" height="500" />

> ![information_icon] _When running ads in the simulator, change the setting to test mode to view test ads. Please go to [How to Use Test Mode][7] for more information._

## Step 3: How to Get the Aspect Ratio of the Content and Apply Natural Width and Height

In the example above, the media content of the ad is shown in `AdCoverMediaView` and its object type is `MediaView`. From previous step, we have shown how to use `MediaView` to load media content from a given `NativeAd` object. This view takes the place of manually loading a cover image. When creating the `MediaView`, its width and height can be either determined by the auto layout constraints set in the storyboard, or they can be hard-coded. However, the width and height of the view may not be fit with the actual cover image of the ad downloaded later. To fix this, the example following shows how to get the aspect ratio of the content and apply natural width and height:

1. In your `ViewController`, declare that `ViewController` implements the `IMediaViewDelegate` interface as follows:

	```csharp
	public partial class ViewController : UIViewController, INativeAdDelegate, IMediaViewDelegate
	```

2. When the native ad is loaded, set the delegate of `MediaView` object to be the controller self as follows:

	```csharp
	[Export ("nativeAdDidLoad:")]
	public void NativeAdDidLoad (NativeAd nativeAd)
	{
		// ...
		
		AdCoverMediaView.NativeAd = nativeAd;
		AdCoverMediaView.Delegate = this;

		// ...
	}
	```

3. Implement `MediaViewDidLoad` method in `ViewController` as follows:

	```csharp
	[Export ("mediaViewDidLoad:")]
	public void MediaViewDidLoad (MediaView mediaView)
	{
		var currentAspect = mediaView.Frame.Width / mediaView.Frame.Height;
		Console.WriteLine ($"Current aspect of media view: {currentAspect}");

		var actualAspect = mediaView.AspectRatio;
		Console.WriteLine ($"Current aspect of media view: {actualAspect}");
	}
	```

	`mediaView.AspectRatio` returns a positive `nfloat`, or `0.0` if no ad is currently loaded. Its value is valid after media view is loaded. There are convenience methods that will set the width and height of the `MediaView` object respecting its apsect ratio of the media content loaded. You can call `ApplyNaturalWidth` or `ApplyNaturalHeight` methods to update the `MediaView` object's width or height to respect the media content's aspect ratio.

## Step 4: Verify Impression and Click Logging

Optionally, you can add the following functions to handle the cases where the native ad is closed or when the user clicks on it:

```csharp
[Export ("nativeAdDidClick:")]
public void NativeAdDidClick (NativeAd nativeAd)
{
	Console.WriteLine ("Native ad was clicked.");
}

[Export ("nativeAdDidFinishHandlingClick:")]
public void NativeAdDidFinishHandlingClick (NativeAd nativeAd)
{
	Console.WriteLine ("Native ad did finish click handling.");
}

[Export ("nativeAdWillLogImpression:")]
public void NativeAdWillLogImpression (NativeAd nativeAd)
{
	Console.WriteLine ("Native ad impression is being captured.");
}
```

## Step 5: How to Debug When Ad Not Shown

Add and implement the following function in your `ViewController` to handle ad loading failures and completions:

```csharp
[Export ("nativeAd:didFailWithError:")]
public void NativeAdDidFail (NativeAd nativeAd, NSError error)
{
	Console.WriteLine ($"Native ad failed to load with error: {error.LocalizedDescription}");
}
```

---

# Native Ads Template

Publishers seeking a more hands off approach when integrating Native Ads can leverage a custom Audience Network Native Ads template. Customize a native ad's size, color, and font to match the look and feel of your app.

## Step 1: Implementation

In your `ViewController`, import the `Facebook.AudienceNetwork` namespace and declare that you implement the `INativeAdDelegate` interface:

```csharp
using Facebook.AudienceNetwork;

namespace YourApp
{
	public partial class ViewController : UIViewController, INativeAdDelegate
	{
		
	}
}
```

Then, add a method in your `ViewController` that initializes a `NativeAd` and request an ad to load:

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	// Perform any additional setup after loading the view, typically from a nib.

	nativeAd = new NativeAd ("Native_Placement_Id") { Delegate = this };
	nativeAd.LoadAd ();
}
```

Replace `Native_Placement_`Id with your own placement id string. If you don't have a placement id or don't know how to get one, you can refer to the [Getting Started Guide][5].

Now that you have added the code to load the ad, add the following functions to construct the ad once it has loaded:

```csharp
[Export ("nativeAdDidLoad:")]
public void NativeAdDidLoad (NativeAd nativeAd)
{
	var adView = NativeAdView.From (nativeAd, NativeAdViewType.GenericHeight300);

	View.AddSubview (adView);

	var size = View.Bounds.Size;
	var xOffset = size.Width / 2 - 160;
	var yOffset = size.Height > size.Width ? 100 : 20;
	adView.Frame = new CGRect (xOffset, yOffset, 320, 300);
}
```

Choose your build target to be device and run the above code, you should see something like this:

<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15615550_191348398002384_5059139155888439296_n.png?oh=083fccb99e1a068be18a49017f05aca8&oe=5B02514F" height="500" />

Custom Ad Formats come in four templates:

| Template View Type                    | Height | Width          | Attributes Included                                              |
|---------------------------------------|--------|----------------|------------------------------------------------------------------|
| **NativeAdViewType.GenericHeight100** | 100dp  | Flexible width | Icon, title, context, and CTA button                             |
| **NativeAdViewType.GenericHeight120** | 120dp  | Flexible width | Icon, title, context, description and CTA button                 |
| **NativeAdViewType.GenericHeight300** | 300dp  | Flexible width | Image, icon, title, context, description and CTA button          |
| **NativeAdViewType.GenericHeight400** | 400dp  | Flexible width | Image, icon, title, subtitle context, description and CTA button |

Native ad templates can also be used in tandem with a Horizontal Scroll View. See [here][8] for details.

## Step 2: Further Customization

With a native custom template, you can customize the following elements:

* Height
* Width
* Background Color
* Title Color
* Title Font
* Description Color
* Description Font
* Button Color
* Button Title Color
* Button Title Font
* Button Border Color

If you want to customize certain elements, then it is recommended to use a design that fits in with your app's layouts and themes.

You will need to build `NativeAdViewAttributes` object and provide a loaded native ad to render these elements:

```csharp
[Export ("nativeAdDidLoad:")]
public void NativeAdDidLoad (NativeAd nativeAd)
{
	var attributes = new NativeAdViewAttributes {
		BackgroundColor = UIColor.FromRGBA (.9f, .9f, .9f, 1),
		ButtonColor = UIColor.FromRGBA (66f / 255, 108f / 255, 173f / 255, 1),
		ButtonTitleColor = UIColor.White
	};

	var adView = NativeAdView.From (nativeAd, NativeAdViewType.GenericHeight300, attributes);

	View.AddSubview (adView);

	var size = View.Bounds.Size;
	var xOffset = size.Width / 2 - 160;
	var yOffset = size.Height > size.Width ? 100 : 20;
	adView.Frame = new CGRect (xOffset, yOffset, 320, 300);
}
```

The above code will render an ad that looks like this:

<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15608930_236949886738452_6903015779097116672_n.png?oh=6abd8269c7fb27a7b6142a043c8364c0&oe=5B3E602E" height="500" />

---

# Adding Interstitial Ad to your iOS app

The Audience Network allows you to monetize your iOS apps with Facebook ads. An interstitial ad is a full screen ad that you can show in your app. Follow this guide to display this type of ad unit.

Let's implement the following interstitial ad placement.

<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15186322_1150921328318322_7119415331189161984_n.png?oh=28bd4905dfb2a6b41043381c6b549718&oe=5B485178" height="500" />

## Step 1: Load and Show Interstitial Ad View

1. In your `ViewController`, import the `Facebook.AudienceNetwork` namespace and declare that `ViewController` implements the `IInterstitialAdDelegate` interface and add an instance variable for the interstitial ad unit:

	```csharp
	using Facebook.AudienceNetwork;

	namespace YourApp
	{
		public partial class ViewController : UIViewController, IInterstitialAdDelegate
		{
			InterstitialAd interstitialAd;
		}
	}
	```

2. Next, implement `ViewDidLoad` method and `InterstitialAdDidLoad` in `ViewController` file.

	```csharp
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		// Perform any additional setup after loading the view, typically from a nib.

		interstitialAd = new InterstitialAd ("Interstitial_Placement_Id") { Delegate = this };
		// For auto play video ads, it's recommended to load the ad 
		// at least 30 seconds before it is shown
		interstitialAd.LoadAd ();
	}

	[Export ("interstitialAdDidLoad:")]
	public void InterstitialAdDidLoad (InterstitialAd interstitialAd)
	{
		Console.WriteLine ("Ad is loaded and ready to be displayed");

		// You can now display the full screen ad using this code:
		interstitialAd.ShowAd (this);
	}
	```

3. Replace `Interstitial_Placement_Id` with your own placement id string. If you don't have a placement id or don't know how to get one, refer to the [Getting Started Guide][5]. Choose your build target to be device and run the above code, you should see something like this:

	<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15186322_1150921328318322_7119415331189161984_n.png?oh=28bd4905dfb2a6b41043381c6b549718&oe=5B485178" height="500" />

> ![information_icon] _When running ads in the simulator, change the setting to test mode to view test ads. Please go to [How to Use Test Mode][7] for more information._

## Step 2: Verify Impression and Click Logging

Optionally, you can add the following functions to handle the cases when the ad is shown, clicked or closed by users:

```csharp
[Export ("interstitialAdWillLogImpression:")]
public void InterstitialAdWillLogImpression (InterstitialAd interstitialAd)
{
	Console.WriteLine ("The user sees the add");
	// Use this function as indication for a user's impression on the ad.
}

[Export ("interstitialAdDidClick:")]
public void InterstitialAdDidClick (InterstitialAd interstitialAd)
{
	Console.WriteLine ("The user clicked on the ad and will be taken to its destination");
	// Use this function as indication for a user's click on the ad.
}

[Export ("interstitialAdWillClose:")]
public void InterstitialAdWillClose (InterstitialAd interstitialAd)
{
	Console.WriteLine ("The user clicked on the close button, the ad is just about to close");
	// Consider to add code here to resume your app's flow
}

[Export ("interstitialAdDidClose:")]
public void InterstitialAdDidClose (InterstitialAd interstitialAd)
{
	Console.WriteLine ("Interstitial had been closed");
	// Consider to add code here to resume your app's flow
}
```

## Step 3: Debugging When Ad Is Not Shown

Add and implement the following function in your `ViewController` to handle ad loading failures and completions:

```csharp
[Export ("interstitialAd:didFailWithError:")]
public void IntersitialDidFail (InterstitialAd interstitialAd, NSError error)
{
	Console.WriteLine ("Ad failed to load");
}
```

> ![information_icon] When there is no ad to show, the `IntersitialDidFail` method will be called with `error.Code` set to `1001`. If you use your own custom reporting or mediation layer you might want to check the code value and detect this case. You can fallback to another ad network in this case, but do not re-request an ad immediately after.

---

# Adding Ad Banners to your iOS app

The Audience Network allows you to monetize your iOS apps with Facebook ads. This guide explains how to create an iOS app that shows banner ads.

Let's implement the following banner ad placement.

<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15186313_179959039133319_5670634952857747456_n.png?oh=f6ede4647e4f71ba2a2a8b1735489152&oe=5B3DA6A2" width="500" />

## Step 1: Load and Show Banner Ad View

> ![information_icon] _When designing native ads and banner ads, ensure you have followed [iOS layout guideline][3] for optimal user experience._

1. In your `ViewController` import the `Facebook.AudienceNetwork` namespace and declare that `ViewController` implements the `IAdViewDelegate` interface:

	```csharp
	using Facebook.AudienceNetwork;

	namespace YourApp
	{
		public partial class ViewController : UIViewController, IAdViewDelegate
		{
			
		}
	}
	```

2. Next, implement `ViewDidLoad` and add the code below to create a new instance of `AdView` and add it to the view. `AdView` is a subclass of `UIView`. You can add it to your view hierarchy just like any other view:

	```csharp
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		// Perform any additional setup after loading the view, typically from a nib.

		var adView = new AdView ("Banner_Placement_Id", AdSizes.BannerHeight50, this) { Delegate = this };
		adView.Frame = new CGRect (0, 20, adView.Bounds.Width, adView.Bounds.Height);
		adView.LoadAd ();
		View.AddSubview (adView);
	}
	```

	Audience Network supports three ad sizes to be used in your `AdView`. The Banner unit's width is flexible with a minimum of 320px, and only the height is defined.

	| Ad Format        | AdSize Reference               | Size    | Recommendation                                                          |
	|------------------|--------------------------------|---------|-------------------------------------------------------------------------|
	| Standard Banner  | **AdSizes.BannerHeight50**     | 320x50  | This banner is best suited to phones                                    |
	| Large Banner     | **AdSizes.BannerHeight90**     | 320x90  | This banner is best suited to tablets and larger devices                |
	| Medium Rectangle | **AdSizes.RectangleHeight250** | 300x250 | This format is best suited for scrollable feeds or end-of-level screens |

3. Replace `Banner_Placement_Id` with your own placement id string. If you don't have a placement id or don't know how to get one, refer to the [Getting Started Guide][5]. Choose your build target to be device and run the above code, you should see something like this:

	<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/15164652_176812106115130_7218854544329932800_n.png?oh=192a01bcb0f5e8a21ef9b201e8b22307&oe=5B3A3DF1" height="500" />

	> ![information_icon] _When running ads in the simulator, change the setting to test mode to view test ads. Please go to [How to Use Test Mode][7] for more information._

## Step 2: Verify Impression and Click Logging

Optionally, you can add the following functions to handle the cases where the banner ad is closed or when the user clicks on it:

```csharp
[Export ("adViewDidClick:")]
public void AdViewDidClick (AdView adView)
{
	Console.WriteLine ("Banner ad was clicked.");
}

[Export ("adViewDidFinishHandlingClick:")]
public void AdViewDidFinishHandlingClick (AdView adView)
{
	Console.WriteLine ("Banner ad did finish click handling.");
}

[Export ("adViewWillLogImpression:")]
public void AdViewWillLogImpression (AdView adView)
{
	Console.WriteLine ("Banner ad impression is being captured.");
}
```

## Step 3: How to Debug When Ad Not Shown

Add and implement the following two functions in your View Controller implementation file to handle ad loading failures and completions:

```csharp
[Export ("adViewDidLoad:")]
public void AdViewDidLoad (AdView adView)
{
	Console.WriteLine ("Ad was loaded and ready to be displayed");
}

[Export ("adView:didFailWithError:")]
public void AdViewDidFail (AdView adView, NSError error)
{
	Console.WriteLine ("Ad failed to load");
}
```

> ![information_icon] _When there is no ad to show, the `AdViewDidFail` method will be called with `error.Code` set to `1001`. If you use your own custom reporting or mediation layer, you may want to check the code value and detect this case. You can fallback to another ad network in this case, but do not re-request an ad immediately after._

---

# Adding In-stream Video Ads to your iOS app

Video publishers can now use Audience Network's In-stream solution to deliver video ads to their global audience across mobile and desktop environments in pre-roll and mid-roll settings. Follow this guide to display this type of ad unit for iOS-based video content.

## Requirements

Please refer to the "In-Stream Video Requirements" section of the [Design Guidelines for Audience Network Ads][9].

## Implementation

This guide will walk you through implementing in-stream video ads on iOS following these steps:

## Step 1: Apply for Audience Network In-stream Video

Go to your app dashboard and from the Audience Network menu on the left side of the screen, select Apps and Websites. Then, go to the "Apply for in-stream video ads" section. Please review the Requirements and, if applicable, click on the Apply button and follow the on screen instructions.

## Step 2: Create Placements

Audience Network offers 4 types of ad units: banner, interstitial (app only), native ads, and In-stream Video. You will see In-stream Video as a Display Format type after you have been approved for In-stream Video. Each ad unit in your app or website is identified using a unique placement ID. Follow this [step][10] to learn how to create this identifier.

## Step 3: Load and Show In-stream Video Ad

Now, in your `ViewController` import the `Facebook.AudienceNetwork` namespace, declare that you implement the `IInstreamAdViewDelegate` protocol and add an instance variable for the interstitial ad unit:

```csharp
using Facebook.AudienceNetwork;

namespace YourApp
{
	public partial class ViewController : UIViewController, IInstreamAdViewDelegate
	{
		InstreamAdView adView;
	}
}
```

Initialize and load an in-stream ad view when it's time to show an ad. This can also be done ahead of time, to pre-cache an ad. In place of `Instream_Placement_Id`, use the id of the in-stream video placement you created earlier.

```csharp
void LoadInstreamAd ()
{
	adView = new InstreamAdView ("Instream_Placement_Id") { Delegate = this };
	adView.LoadAd ();
}
```

Now that you have added the code to load the ad add the necessary delegate implementation to display the ad, and handle failures:

> ![information_icon] _When there is no ad to show, the adView:didFailWithError: will be called with error.code set to 1001. You should detect this and return to the content._

```csharp
public void AdViewDidLoad (InstreamAdView adView)
{
	Console.WriteLine ("Ad is loaded and ready to be displayed");

	// The ad can now be added to the layout and shown
	this.adView.Frame = View.Bounds;
	this.adView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
	View.AddSubview (adView);
	this.adView.ShowAd (this);
}

public void AdViewDidEnd (InstreamAdView adView)
{
	Console.WriteLine ("Ad ended");
	this.adView.RemoveFromSuperview ();
	this.adView.Dispose ();
	this.adView = null;

	// The app should now proceed to content
}

public void AdViewDidFail (InstreamAdView adView, NSError error)
{
	Console.WriteLine ($"Ad failed: {error.LocalizedDescription}");
	this.adView.RemoveFromSuperview ();
	this.adView.Dispose ();
	this.adView = null;

	// The app should now proceed to content
}
```

Once you run the above code and present the in-stream ad, you should see something like this:

<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2365-6/14450068_313494469025108_7214356798742986752_n.png?oh=265c14e6d2927469cc79c526a388e983&oe=5B0E4CCE" width="500" />

## Step 4: Handle Impressions and Clicks

Optionally, you can add the following functions to handle ad clicks and impressions:

```csharp
[Export ("adViewDidClick:")]
public void AdViewDidClick (InstreamAdView adView)
{
	Console.WriteLine ("Ad clicked");
	// Called when the user clicks on the "Learn More" button.
}

[Export ("adViewWillLogImpression:")]
public void AdViewWillLogImpression (InstreamAdView adView)
{
	Console.WriteLine ("Ad impression");
	// Called when the ad logs an impression
}
```

> ![information_icon] _When running ads in the simulator, change the setting to test mode to view test ads. Please go to [How to Use Test Mode][7] for more information._

---

# Rewarded Video for iOS

Rewarded video ads are a full screen experience where users opt-in to view a video ad in exchange for something of value, such as virtual currency, in-app items, exclusive content, and more. The ad experience is 15-30 second non-skippable and contains an end card with a call to action. Upon completion of the full video, you will receive a callback to grant the suggested reward to the user.

> ![information_icon] _Please note, Rewarded Video is only supported for iOS 8 and above._

## Implementation

Now, in your `ViewController` import the `Facebook.AudienceNetwork` namespace, declare that you implement the `IRewardedVideoAdDelegate` interface and add an instance variable for the rewarded video ad unit:

```csharp
using Facebook.AudienceNetwork;

namespace YourApp
{
	public partial class ViewController : UIViewController, IRewardedVideoAdDelegate
	{
		RewardedVideoAd rewardedVideoAd;
	}
}
```

Add a function in your `ViewController` that initializes the rewarded video object and caches the video creative ahead of the time you want to show it.

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();
	// Perform any additional setup after loading the view, typically from a nib.

	LoadRewardedVideoAd ();
}

void LoadRewardedVideoAd ()
{
	rewardedVideoAd = new RewardedVideoAd ("Rewarded_Video_Placement_Id") { Delegate = this };
	rewardedVideoAd.LoadAd ();
}
```

Replace `Rewarded_Video_Placement_Id` with your own placement id string. If you don't have a placement id or don't know how to get one, you can refer to the [Getting Started Guide][5].

Now that you have added the code to load the ad, you can add functions which will handle various events. For example:

* `RewardedVideoAdDidLoad` ensures your app is aware when the ad is cached and ready to be displayed
* `RewardedVideoAdComplete` lets you know when to deliver your reward to the user after a completed video view

```csharp
[Export ("rewardedVideoAdDidLoad:")]
public void RewardedVideoAdDidLoad (RewardedVideoAd rewardedVideoAd)
{
	Console.WriteLine ("Video ad is loaded and ready to be displayed");
}

[Export ("rewardedVideoAd:didFailWithError:")]
public void RewardedVideoAdDidFail (RewardedVideoAd rewardedVideoAd, NSError error)
{
	Console.WriteLine ($"Rewarded video ad failed to load: {error.LocalizedDescription}");
}

[Export ("rewardedVideoAdDidClick:")]
public void RewardedVideoAdDidClick (RewardedVideoAd rewardedVideoAd)
{
	Console.WriteLine ("Video ad clicked");
}

[Export ("rewardedVideoAdComplete:")]
public void RewardedVideoAdComplete (RewardedVideoAd rewardedVideoAd)
{
	Console.WriteLine ("Rewarded Video ad complete - this is called after a full video view, before the ad end card is shown.You can use this event to initialize your reward");
}

[Export ("rewardedVideoAdDidClose:")]
public void RewardedVideoAdDidClose (RewardedVideoAd rewardedVideoAd)
{
	Console.WriteLine ("Rewarded Video ad closed - this can be triggered by closing the application, or closing the video end card");
}
```

Finally, when you are ready to show the rewarded video ad you can call the following code within your own reward function.

```csharp
void ShowRewardedVideoAd ()
{
	rewardedVideoAd.ShowAd (this);
}
```

The method to show a rewarded video ad includes an animated BOOLEAN flag which allows you to animate the presentation. By default it is set to `true`, but this can be overridden with the following.

```csharp
rewardedVideoAd.ShowAd (this, false);
```

> ![information_icon] _When running ads in the simulator, change the setting to test mode to view test ads. Please go to [How to Use Test Mode][7] for more information._

Optionally, you can add the following additional functions to handle the cases where the rewarded video ad will close or when the rewarded video impression is being captured:

```csharp
[Export ("rewardedVideoAdWillClose:")]
public void RewardedVideoAdWillClose (RewardedVideoAd rewardedVideoAd)
{
	Console.WriteLine ("The user clicked on the close button, the ad is just about to close");
}

[Export ("rewardedVideoAdWillLogImpression:")]
public void RewardedVideoAdWillLogImpression (RewardedVideoAd rewardedVideoAd)
{
	Console.WriteLine ("Rewarded Video impression is being captured");
}
```

## Server Side Reward Validation

### Overview

If you manage your user rewards server-side, then Facebook offers a solution for carrying this out securely by using a validation technique. Our server will communicate with a specified endpoint to validate each ad impression and validate whether a reward should be granted.

1. Audience Network SDK requests a rewarded video ad with the following parameters:
	1. Audience Network Placement ID
	2. Unique User ID - an attribute you use to identify a unique user. For example, a numeric identifier
	3. Reward Value - the value of the reward you would like to grant the user. For example, 100Coins specified end point, together with the [App Secret][12].

2. Upon receipt, the server validates the request and responds as follows:
	1. **200 response:** request is valid and the reward should be delivered
	2. **Non 200 response:** request is not valid, and the reward should not be delivered.

3. Once the video is complete, the end card is presented and one of the following events will fire.
	1. onRewardServerSuccess - triggered only if a 200 response was received during step 3.
	2. onRewardServerFailed - triggered if a non 200 response was received during step 3.

> ![information_icon] _An example of the URL which will hit your publisher end point, from Facebook's server._
>
> https://www.your_end_point.com/?**token**=APP_SECRET&**puid**=USER_ID&**pc**=REWARD_ID&**ptid**=UNIQUE_TRANSACTION_ID

> ![information_icon] Please provide your publisher end point to your Facebook representative in order to enable this feature.

<image src="https://scontent.fgdl4-1.fna.fbcdn.net/v/t39.2178-6/17365208_273188216455141_6379479237312643072_n.png?oh=b29c0f693a1b2f5994837540d0b7c49c&oe=5B031DC2" width="500" />

### SDK Implementation

It is possible to set the Reward Data (`USER_ID` and `CURRENCY`) on initialization. This is demonstrated in the code snippet below:

```csharp
void LoadRewardedVideoAd ()
{
	//Set the rewarded ad data
	rewardedVideoAd = new RewardedVideoAd ("Rewarded_Video_Placement_Id", "USER_ID", "CURRENCY") { Delegate = this };
	rewardedVideoAd.LoadAd ();
}
```

In addition to the functions noted above in the `IRewardedVideoAdDelegate`, the following events should be used to hande the granting of rewards in your app. The following can be used alongise the events monetioned above:

```csharp
[Export ("rewardedVideoAdServerRewardDidSucceed:")]
void RewardedVideoAdServerRewardDidSuccess (RewardedVideoAd rewardedVideoAd)
{
	Console.WriteLine ("Rewarded video ad validated by server");
}

[Export ("rewardedVideoAdServerRewardDidFail:")]
void RewardedVideoAdServerRewardDidFail (RewardedVideoAd rewardedVideoAd)
{
	Console.WriteLine ("Rewarded video ad not validated, or no response from server");
}
```

> ![information_icon] _Please note: the server validation callbacks will only occur after the end card has been dismissed by a user. You should not deallocate the rewarded video object until after one of these callbacks._

---

[1]: https://developers.facebook.com/docs/audience-network/getting-started
[2]: https://developers.facebook.com/docs/audience-network/guidelines/native-ads#native
[3]: https://developers.facebook.com/docs/audience-network/ios-layout-guideline
[4]: https://developers.facebook.com/docs/audience-network/ios-native#ui
[5]: https://developers.facebook.com/docs/audience-network/getting-started#placement_ids
[6]: https://developers.facebook.com/docs/audience-network/policy
[7]: https://developers.facebook.com/docs/audience-network/testing#testing-testAd
[8]: https://developers.facebook.com/docs/audience-network/ios/nativescroll
[9]: https://developers.facebook.com/docs/audience-network/guidelines/native-ads/
[10]: https://developers.facebook.com/docs/audience-network/ios/instream-video#step2
[11]: https://developer.apple.com/library/content/documentation/General/Reference/InfoPlistKeyReference/Articles/CocoaKeys.html
[12]: https://developers.facebook.com/docs/facebook-login/security#appsecret
[information_icon]: https://cdn1.iconfinder.com/data/icons/hawcons/32/699299-icon-29-information-20.png
