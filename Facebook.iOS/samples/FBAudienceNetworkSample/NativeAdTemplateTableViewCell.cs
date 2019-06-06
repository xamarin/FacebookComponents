using System;

using Foundation;
using UIKit;

namespace FBAudienceNetworkSample
{
	public partial class NativeAdTemplateTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString (nameof (NativeAdTemplateTableViewCell));

		public UIView AdView { get => View; }

		protected NativeAdTemplateTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
