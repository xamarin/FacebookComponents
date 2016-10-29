## Info.plist

### Whitelist Facebook Servers for Network Requests

If you compile your app with iOS SDK 9.0 or higher, you will be affected by App Transport Security. Currently, you will need to whitelist Facebook domains in your app by adding the following to your application's plist:

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

## Placement IDs

So you can use this API, you will need to create one or more Placements IDs in your Facebook app setting. Follow this [guide][gettingstarted] to know how to do it.

[gettingstarted]: https://developers.facebook.com/docs/audience-network/getting-started

## Banner Ads

This is a simple way to add a Banner Ad to your app:

```csharp

using Facebook.AudienceNetwork;

...

public partial class FBAudienceNetworkSampleViewController : UIViewController, IAdViewDelegate
{
	// Generate your own Placement ID on the Facebook app settings
	const string YourPlacementId = "YOUR_PLACEMENT_ID";
	AdView adView;
		
	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		// Create a banner's ad view with a unique placement ID (generate your own on the Facebook app settings).
		// Use different ID for each ad placement in your app.
		adView = new AdView (YourPlacementId, AdSizes.BannerHeight50, this) {
			Delegate = this
		};

		// When testing on a device, add its hashed ID to force test ads.
		// The hash ID is printed to console when running on a device.
		//AdSettings.AddTestDevice ("THE HASHED ID AS PRINTED TO CONSOLE");
	
		// Initiate a request to load an ad.
		adView.LoadAd ();

		// Reposition the adView to the bottom of the screen
		var viewSize = View.Bounds.Size;
		var bottomAlignedY = viewSize.Height - AdSizes.BannerHeight50.Size.Height;

		adView.Frame = new CGRect (0, bottomAlignedY, viewSize.Width, AdSizes.BannerHeight50.Size.Height);

		// Add adView to the view hierarchy.
		View.AddSubview (adView);
	}

	#region IAdViewDelegate

	[Export ("adViewDidClick:")]
	public void AdViewDidClick (AdView adView)
	{
		// Handle when the banner is clicked
	}

	[Export ("adViewDidFinishHandlingClick:")]
	public void AdViewDidFinishHandlingClick (AdView adView)
	{
		// Handle when the window that is opened by the click is closed);
	}

	[Export ("adViewDidLoad:")]
	public void AdViewDidLoad (AdView adView)
	{
		// Handle when the ad on the banner is loaded
	}

	[Export ("adView:didFailWithError:")]
	public void AdViewDidFail (AdView adView, NSError error)
	{
		// Handle if the ad is not loaded correctly
	}

	#endregion
}

```

### Banner Ads on iPad
If you are building your app for iPad, consider using the AdSizes.Height90Banner size instead. In all cases, the banner width is flexible with a minimum of 320px.


### 300x250 Banner Ad Size
The Audience Network also support 300x250 ad size. Configure the AdView with the following ad size: AdSizes.HeightRectangle;

```csharp
public override void ViewDidLoad ()
{
	base.ViewDidLoad ();

	// Create a banner's ad view with a unique placement ID (generate your own on the Facebook app settings).
	// Use different ID for each ad placement in your app.#
	adView = new AdView (YourPlacementId, AdSizes.RectangleHeight250, this) {
		Delegate = this
	};
	adView.LoadAd ();

	// Reposition the adView to the bottom of the screen
	var viewSize = View.Bounds.Size;
	var bottomAlignedY = viewSize.Height - AdSizes.RectangleHeight250.Size.Height;
	var bottomAlignedX = viewSize.Width / 2 - 150;
	adView.Frame = new CGRect (bottomAlignedX, bottomAlignedY, AdSizes.RectagleHeight250.Size.Width, AdSizes.RectangleHeight250.Size.Height);
	
	// Add adView to the view hierarchy.
	View.AddSubview (adView);
}
```

## Interstitial Ad

This is a simple way to add a Interstitial Ad to your app:

```csharp

using Facebook.AudienceNetwork;

...

public partial class FBAudienceNetworkSampleViewController : UIViewController, IInterstitialAdDelegate
{
	// Generate your own Placement ID on the Facebook app settings
	const string YourPlacementId = "YOUR_PLACEMENT_ID";
	InterstitialAd interstitialAd;

	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();

		// Create a banner's ad view with a unique placement ID (generate your own on the Facebook app settings).
		// Use different ID for each ad placement in your app.
		interstitialAd = new InterstitialAd (YourPlacementId) {
			Delegate = this
		};

		// When testing on a device, add its hashed ID to force test ads.
		// The hash ID is printed to console when running on a device.
		//AdSettings.AddTestDevice ("THE HASHED ID AS PRINTED TO CONSOLE");

		// Initiate a request to load an ad.
		interstitialAd.LoadAd ();

		// Verify if the ad is ready to be shown, if not, you will need to check later somehow (with a button, timer, delegate, etc.)
		if (interstitialAd.IsAdValid) {
			// Ad is ready, present it!
			interstitialAd.ShowAdFromRootViewController (this);
		}
	}

	#region IInterstitialAdDelegate

	[Export ("interstitialAdDidLoad:")]
	public void InterstitialAdDidLoad (InterstitialAd interstitialAd)
	{
		// Handle when the ad is loaded and ready to be shown
		if (interstitialAd.IsAdValid) {
			// Ad is ready, present it!
			interstitialAd.ShowAdFromRootViewController (this);
		}
	}

	[Export ("interstitialAd:didFailWithError:")]
	public void IntersitialDidFail (InterstitialAd interstitialAd, NSError error)
	{
		// Handle if the ad is not loaded correctly
	}

	[Export ("interstitialAdDidClick:")]
	public void InterstitialAdDidClick (InterstitialAd interstitialAd)
	{
		// Handle when the user tap the ad
	}

	[Export ("interstitialAdDidClose:")]
	public void InterstitialAdDidClose (InterstitialAd interstitialAd)
	{
		// Handle when the user close the ad
	}

	[Export ("interstitialAdWillClose:")]
	public void InterstitialAdWillClose (InterstitialAd interstitialAd)
	{
		// Handle before the ad is closed
	}

	#endregion
}

```

### Running Ads on Test Device
When running on the simulator, test ads will be shown by default. To enable test ads on a device, add the following line of code before loading an ad: AdSettings.AddTestDevice("HASHED ID");. Use the hashed ID that is printed to the console when you first make a request to load an ad on a device. To see ads on your test device, you must have the Facebook app installed and have logged in within the last 30 days. Also check to make sure you haven't opted out of ads on your device.
