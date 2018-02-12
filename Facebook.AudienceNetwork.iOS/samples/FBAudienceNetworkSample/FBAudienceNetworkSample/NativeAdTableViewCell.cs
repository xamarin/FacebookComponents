using System;

using Foundation;
using UIKit;

namespace FBAudienceNetworkSample
{
	public partial class NativeAdTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("NativeAdTableViewCell");

		public UIView AdView { get => View; }

		protected NativeAdTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
