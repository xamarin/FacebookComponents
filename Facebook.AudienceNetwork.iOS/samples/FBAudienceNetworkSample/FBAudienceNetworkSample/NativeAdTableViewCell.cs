using System;

using Foundation;
using UIKit;

namespace FBAudienceNetworkSample
{
	public partial class NativeAdTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("NativeAdTableViewCell");
		public static readonly UINib Nib;

		static NativeAdTableViewCell ()
		{
			Nib = UINib.FromName ("NativeAdTableViewCell", NSBundle.MainBundle);
		}

		protected NativeAdTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
