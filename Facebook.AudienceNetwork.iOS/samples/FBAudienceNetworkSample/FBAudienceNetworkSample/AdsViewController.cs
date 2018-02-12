using System;

using UIKit;
using Foundation;

using Facebook.AudienceNetwork;
using CoreGraphics;
using System.Collections.Generic;

namespace FBAudienceNetworkSample
{
	public partial class AdsViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate,
	INativeAdDelegate, IAdViewDelegate, IInterstitialAdDelegate, IRewardedVideoAdDelegate
	{
		const string bannerPlacementId = "Banner_Placement_Id";
		const string interstitialPlacementId = "Interstitial_Placement_Id";
		const string nativePlacementId = "Native_Placement_Id";
		const string rewardedVideoPlacementId = "Rewarded_Video_Placement_Id";

		List<NativeAdView> nativeAdViews;
		AdView bannerAdView;
		InterstitialAd interstitialAd;
		RewardedVideoAd rewardedVideoAd;

		public AdsViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			nativeAdViews = new List<NativeAdView> ();
		}

		partial void BtnShow_Click (NSObject sender)
		{
			var actionSheet = UIAlertController.Create (null, null, UIAlertControllerStyle.ActionSheet);
			actionSheet.AddAction (UIAlertAction.Create ("Cancel", UIAlertActionStyle.Cancel, null));
			actionSheet.AddAction (UIAlertAction.Create ("Add Native ad to Table", UIAlertActionStyle.Default, AddNativeAd));
			actionSheet.AddAction (UIAlertAction.Create ("Show Banner ad", UIAlertActionStyle.Default, ShowBannerAd));
			actionSheet.AddAction (UIAlertAction.Create ("Show Interstitial ad", UIAlertActionStyle.Default, ShowInterstitialAd));
			actionSheet.AddAction (UIAlertAction.Create ("Show Rewarded Video Ad", UIAlertActionStyle.Default, ShowRewardedVideoAd));
			PresentViewController (actionSheet, true, null);
		}

		void AddNativeAd (UIAlertAction obj)
		{
			var nativeAd = new NativeAd (nativePlacementId) { Delegate = this };
			nativeAd.LoadAd ();
		}

		void ShowBannerAd (UIAlertAction obj)
		{
			bannerAdView?.RemoveFromSuperview ();
			bannerAdView?.Dispose ();
			bannerAdView = null;

			bannerAdView = new AdView (bannerPlacementId, AdSizes.BannerHeight50, this) { Delegate = this };
			bannerAdView.Frame = new CGRect (0, 0, bannerAdView.Bounds.Width, bannerAdView.Bounds.Height);
			bannerAdView.LoadAd ();
			BannerView.AddSubview (bannerAdView);
		}

		void ShowInterstitialAd (UIAlertAction obj)
		{
			interstitialAd?.Dispose ();
			interstitialAd = null;

			interstitialAd = new InterstitialAd (interstitialPlacementId) { Delegate = this };
			interstitialAd.LoadAd ();
		}

		void ShowRewardedVideoAd (UIAlertAction obj)
		{
			rewardedVideoAd?.Dispose ();
			rewardedVideoAd = null;

			rewardedVideoAd = new RewardedVideoAd (rewardedVideoPlacementId) { Delegate = this };
			rewardedVideoAd.LoadAd ();
		}

		#region UITableView Data Source

		[Export ("numberOfSectionsInTableView:")]
		public nint NumberOfSections (UITableView tableView) => 1;
		public nint RowsInSection (UITableView tableView, nint section) => nativeAdViews.Count;

		public UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var nativeAdView = nativeAdViews [indexPath.Row];
			var cell = tableView.DequeueReusableCell (NativeAdTableViewCell.Key, indexPath) as NativeAdTableViewCell;

			nativeAdView.Frame = new CGRect (0, 0, cell.AdView.Frame.Width, 300);
			cell.AdView.AddSubview (nativeAdView);

			return cell;
		}

		#endregion

		#region UITableView Delegate

		[Export ("tableView:canEditRowAtIndexPath:")]
		public bool CanEditRow (UITableView tableView, NSIndexPath indexPath) => true;

		[Export ("tableView:commitEditingStyle:forRowAtIndexPath:")]
		public void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			switch (editingStyle) {
			case UITableViewCellEditingStyle.Delete:
				var nativeAdView = nativeAdViews [indexPath.Row];
				nativeAdView.Dispose ();
				nativeAdView = null;
				nativeAdViews.RemoveAt (indexPath.Row);
				tableView.DeleteRows (new [] { indexPath }, UITableViewRowAnimation.Automatic);

				break;
			}
		}

		#endregion

		#region NativeAd Delegate

		[Export ("nativeAdDidLoad:")]
		public void NativeAdDidLoad (NativeAd nativeAd)
		{
			var nativeAdView = NativeAdView.From (nativeAd, NativeAdViewType.GenericHeight300);
			nativeAdViews.Add (nativeAdView);

			// Register the native ad view and its view controller with the native ad instance
			nativeAd.RegisterView (nativeAdView, this);

			var newIndexPath = NSIndexPath.FromRowSection (nativeAdViews.Count - 1, 0);
			AdsTableView.InsertRows (new [] { newIndexPath }, UITableViewRowAnimation.Automatic);
			AdsTableView.ScrollToRow (newIndexPath, UITableViewScrollPosition.Bottom, true);
		}

		[Export ("nativeAd:didFailWithError:")]
		public void NativeAdDidFail (NativeAd nativeAd, NSError error) =>
		Console.WriteLine ($"{nameof (NativeAdDidFail)} - Native ad failed to load with error: {error.LocalizedDescription}");

		[Export ("nativeAdDidClick:")]
		public void NativeAdDidClick (NativeAd nativeAd) =>
		Console.WriteLine ($"{nameof (NativeAdDidClick)} - Native ad was clicked.");

		[Export ("nativeAdDidFinishHandlingClick:")]
		public void NativeAdDidFinishHandlingClick (NativeAd nativeAd) =>
		Console.WriteLine ($"{nameof (NativeAdDidFinishHandlingClick)} - Native ad did finish click handling.");

		[Export ("nativeAdWillLogImpression:")]
		public void NativeAdWillLogImpression (NativeAd nativeAd) =>
		Console.WriteLine ($"{nameof (NativeAdWillLogImpression)} - Native ad impression is being captured.");

		#endregion

		#region AdView Delegate

		[Export ("adViewDidLoad:")]
		public void AdViewDidLoad (AdView adView) =>
		Console.WriteLine ($"{nameof (AdViewDidLoad)} - Ad was loaded and ready to be displayed");

		[Export ("adView:didFailWithError:")]
		public void AdViewDidFail (AdView adView, NSError error) =>
		Console.WriteLine ($"{nameof (AdViewDidFail)} - Ad failed to load: {error.LocalizedDescription}");

		[Export ("adViewDidClick:")]
		public void AdViewDidClick (AdView adView) =>
		Console.WriteLine ($"{nameof (AdViewDidClick)} - Banner ad was clicked.");

		[Export ("adViewDidFinishHandlingClick:")]
		public void AdViewDidFinishHandlingClick (AdView adView) =>
		Console.WriteLine ($"{nameof (AdViewDidFinishHandlingClick)} - Banner ad did finish click handling.");

		[Export ("adViewWillLogImpression:")]
		public void AdViewWillLogImpression (AdView adView) =>
		Console.WriteLine ($"{nameof (AdViewWillLogImpression)} - Banner ad impression is being captured.");

		#endregion

		#region InterstitialAd Delegate

		[Export ("interstitialAdDidLoad:")]
		public void InterstitialAdDidLoad (InterstitialAd interstitialAd)
		{
			Console.WriteLine ($"{nameof (InterstitialAdDidLoad)} - Ad is loaded and ready to be displayed");

			// You can now display the full screen ad using this code:
			interstitialAd.ShowAd (this);
		}

		[Export ("interstitialAd:didFailWithError:")]
		public void IntersitialDidFail (InterstitialAd interstitialAd, NSError error) =>
		Console.WriteLine ($"{nameof (IntersitialDidFail)} - Ad failed to load: {error.LocalizedDescription}");

		[Export ("interstitialAdWillLogImpression:")]
		public void InterstitialAdWillLogImpression (InterstitialAd interstitialAd) =>
		Console.WriteLine ($"{nameof (InterstitialAdWillLogImpression)} - The user sees the add");

		[Export ("interstitialAdDidClick:")]
		public void InterstitialAdDidClick (InterstitialAd interstitialAd) =>
		Console.WriteLine ($"{nameof (InterstitialAdDidClick)} - The user clicked on the ad and will be taken to its destination");

		[Export ("interstitialAdWillClose:")]
		public void InterstitialAdWillClose (InterstitialAd interstitialAd) =>
		Console.WriteLine ($"{nameof (InterstitialAdWillClose)} - The user clicked on the close button, the ad is just about to close");

		[Export ("interstitialAdDidClose:")]
		public void InterstitialAdDidClose (InterstitialAd interstitialAd) =>
		Console.WriteLine ($"{nameof (InterstitialAdDidClose)} - Interstitial had been closed");

		#endregion

		#region RewardedVideoAd Delegate

		[Export ("rewardedVideoAdDidLoad:")]
		public void RewardedVideoAdDidLoad (RewardedVideoAd rewardedVideoAd)
		{
			Console.WriteLine ($"{nameof (RewardedVideoAdDidLoad)} - Video ad is loaded and ready to be displayed");

			rewardedVideoAd.ShowAd (this);
		}

		[Export ("rewardedVideoAd:didFailWithError:")]
		public void RewardedVideoAdDidFail (RewardedVideoAd rewardedVideoAd, NSError error) =>
		Console.WriteLine ($"{nameof (RewardedVideoAdDidFail)} - Rewarded video ad failed to load: {error.LocalizedDescription}");

		[Export ("rewardedVideoAdDidClick:")]
		public void RewardedVideoAdDidClick (RewardedVideoAd rewardedVideoAd) =>
		Console.WriteLine ($"{nameof (RewardedVideoAdDidClick)} - Video ad clicked");

		[Export ("rewardedVideoAdComplete:")]
		public void RewardedVideoAdComplete (RewardedVideoAd rewardedVideoAd) =>
		Console.WriteLine ($"{nameof (RewardedVideoAdComplete)} - Rewarded Video ad complete - this is called after a full video view, before the ad end card is shown.You can use this event to initialize your reward");

		[Export ("rewardedVideoAdDidClose:")]
		public void RewardedVideoAdDidClose (RewardedVideoAd rewardedVideoAd) =>
		Console.WriteLine ($"{nameof (RewardedVideoAdDidClose)} - Rewarded Video ad closed - this can be triggered by closing the application, or closing the video end card");

		[Export ("rewardedVideoAdWillClose:")]
		public void RewardedVideoAdWillClose (RewardedVideoAd rewardedVideoAd) =>
		Console.WriteLine ($"{nameof (RewardedVideoAdWillClose)} - The user clicked on the close button, the ad is just about to close");

		[Export ("rewardedVideoAdWillLogImpression:")]
		public void RewardedVideoAdWillLogImpression (RewardedVideoAd rewardedVideoAd) =>
		Console.WriteLine ($"{nameof (RewardedVideoAdWillLogImpression)} - Rewarded Video impression is being captured");

		#endregion
	}
}
