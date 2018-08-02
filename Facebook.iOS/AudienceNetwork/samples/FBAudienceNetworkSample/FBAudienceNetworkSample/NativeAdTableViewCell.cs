using System;

using Foundation;
using UIKit;

using Facebook.AudienceNetwork;

namespace FBAudienceNetworkSample
{
	public partial class NativeAdTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString (nameof (NativeAdTableViewCell));

		public UIView AdView { get => View; }
		public MediaView CoverMediaViewAd { get => AdCoverMediaView; }
		public AdChoicesView ChoiceViewAd { get => AdChoiceView; }
		public UIButton AdCallToActionButton { get => BtnAdCallToAction; }
		public AdIconView IconViewAd { get => AdIconView; }
		public string AdTitle { 
			get => LblAdTitle.Text; 
			set => LblAdTitle.Text = value; 
		}
		public string Sponsored { 
			get => LblSponsored.Text; 
			set => LblSponsored.Text = value; 
		}
		public string AdSocialContext { 
			get => LblAdSocialContext.Text; 
			set => LblAdSocialContext.Text = value; 
		}
		public string AdBody { 
			get => LblAdBody.Text; 
			set => LblAdBody.Text = value; 
		}

		protected NativeAdTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
