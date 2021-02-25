using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Facebook.AudienceNetwork;

namespace FBAudienceNetworkSample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		
		public override UIWindow Window {
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;

			AdPlacementIds.AddTestDevices ();

			return true;
		}

		public static void ShowMessage (string title, string message, UIViewController fromViewController)
		{
			var alertController = UIAlertController.Create (title, message, UIAlertControllerStyle.Alert);
			alertController.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Cancel, null));
			fromViewController.PresentViewController (alertController, true, null);
		}
	}
}

