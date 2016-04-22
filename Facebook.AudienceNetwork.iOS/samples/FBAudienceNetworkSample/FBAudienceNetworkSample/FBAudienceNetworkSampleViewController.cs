using System;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

using Facebook.AudienceNetwork;

namespace FBAudienceNetworkSample
{
	public partial class FBAudienceNetworkSampleViewController : UIViewController, IAdViewDelegate, IInterstitialAdDelegate
	{
		public FBAudienceNetworkSampleViewController (IntPtr handle) : base (handle)
		{
		}

		AdView adView;
		InterstitialAd interstitialAd;
		const string YourPlacementId = "YOUR_PLACEMENT_ID";

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (YourPlacementId == "YOUR_PLACEMENT_ID") {
				ShowMessage ("Please, replace \"YOUR_PLACEMENT_ID\" value with your generated Id");
				btnAudience.Enabled = false;
				btnIntersitial.Enabled = false;
				return;
			}

			try {
				// Create a banner's ad view with a unique placement ID (generate your own on the Facebook app settings).
				// Use different ID for each ad placement in your app.
				adView = new AdView (YourPlacementId, AdSizes.BannerHeight50, this) {
					Delegate = this
				};

				// When testing on a device, add its hashed ID to force test ads.
				// The hash ID is printed to console when running on a device.
				//			FBAdSettings.AddTestDevice ("THE HASHED ID AS PRINTED TO CONSOLE");

				// Initiate a request to load an ad.
				adView.LoadAd ();

				// Reposition the adView to the bottom of the screen
				var viewSize = View.Bounds.Size;
				var bottomAlignedY = viewSize.Height - AdSizes.BannerHeight50.Size.Height;

				adView.Frame = new CGRect (0, bottomAlignedY, viewSize.Width, AdSizes.BannerHeight50.Size.Height);

				// Add adView to the view hierarchy.
				View.AddSubview (adView);

			} catch (Exception ex) {
				ShowMessage ("An error was occurred while the AdView was creating...\nPlease, double check that your PlacementId is correct.");
			}
		}

		partial void btnIntersitial_TouchUpInside (UIButton sender)
		{
			lblInterstitalStatusLabel.Text = "Loading interstitial ad...";

			// Create the interstitial unit with a placement ID (generate your own on the Facebook app settings).
			// Use different ID for each ad placement in your app.
			interstitialAd = new InterstitialAd (YourPlacementId) {
				Delegate = this
			};

			interstitialAd.LoadAd ();
		}

		partial void btnAudience_TouchUpInside (UIButton sender)
		{
			if (interstitialAd == null || !interstitialAd.IsAdValid) {
				// Ad not ready to present.
				lblInterstitalStatusLabel.Text = "Ad not loaded. Click load to request an ad.";
			} else {
				lblInterstitalStatusLabel.Text = string.Empty;

				// Ad is ready, present it!
				interstitialAd.ShowAdFromRootViewController (this);
			}
		}

		#region IFBAdViewDelegate

		[Export ("adViewDidClick:")]
		public void AdViewDidClick (AdView adView)
		{
			ShowMessage ("Ad was clicked.");
		}

		[Export ("adViewDidFinishHandlingClick:")]
		public void AdViewDidFinishHandlingClick (AdView adView)
		{
			ShowMessage ("Ad did finish click handling.");
		}

		[Export ("adViewDidLoad:")]
		public void AdViewDidLoad (AdView adView)
		{
			lblAdViewStatus.Text = string.Empty;
			ShowMessage ("Ad was loaded.");

			// Now that the ad was loaded, show the view in case it was hidden before.
			adView.Hidden = false;
		}

		[Export ("adView:didFailWithError:")]
		public void AdViewDidFail (AdView adView, NSError error)
		{
			lblAdViewStatus.Text = "Ad failed to load.";
			ShowMessage ("Ad failed to load with error: " + error.Description);

			// Hide the unit since no ad is shown.
			adView.Hidden = true;
		}

		#endregion

		#region IFBInterstitialAdDelegate

		[Export ("interstitialAdDidLoad:")]
		public void InterstitialAdDidLoad (InterstitialAd interstitialAd)
		{
			ShowMessage ("Interstitial ad was loaded. Can present now.");
			lblInterstitalStatusLabel.Text = "Ad loaded. Click show to present!";
		}

		[Export ("interstitialAd:didFailWithError:")]
		public void IntersitialDidFail (InterstitialAd interstitialAd, NSError error)
		{
			ShowMessage ("Interstitial failed to load with error: " + error.Description);
			lblInterstitalStatusLabel.Text = "Interstitial ad failed to load.";
		}

		[Export ("interstitialAdDidClick:")]
		public void InterstitialAdDidClick (InterstitialAd interstitialAd)
		{
			ShowMessage ("Interstitial was clicked.");
		}

		[Export ("interstitialAdDidClose:")]
		public void InterstitialAdDidClose (InterstitialAd interstitialAd)
		{
			ShowMessage ("Interstitial closed.");

			// Optional, Cleaning up.
			interstitialAd = null;
		}

		[Export ("interstitialAdWillClose:")]
		public void InterstitialAdWillClose (InterstitialAd interstitialAd)
		{
			ShowMessage ("Interstitial will close.");
		}

		#endregion

		void ShowMessage (string message)
		{
			new UIAlertView ("Hey!", message, null, "Ok", null).Show ();
		}
	}
}

