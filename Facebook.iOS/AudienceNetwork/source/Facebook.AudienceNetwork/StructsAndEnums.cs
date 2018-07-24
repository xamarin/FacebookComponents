//
// StructsAndEnums.cs: Bindings to the Facebook iOS SDK.
//
//	Authors:
//		Miguel de Icaza (miguel@xamarin.com)
//		Alex Soto 	(alex.soto@xamarin.com)
//		Israel Soto 	(israel.soto@xamarin.com)
//

using System;
using System.Runtime.InteropServices;

using ObjCRuntime;
using CoreGraphics;

namespace Facebook.AudienceNetwork
{
	[Native]
	public enum AdLogLevel : long
	{
		None,
		Notification,
		Error,
		Warning,
		Log,
		Debug,
		Verbose
	}

	[Native]
	public enum MediaViewRenderingMethod : long
	{
		Default,
		Metal,
		OpenGL,
		Software
	}

	[Native]
	public enum AdTestAdType : long
	{
		Default,
		Img16x9AppInstall,
		Img16x9Link,
		VidHD16x9_46sAppInstall,
		VidHD16x9_46sLink,
		VidHD16x9_15sAppInstall,
		VidHD16x9_15sLink,
		VidHD9x16_39sAppInstall,
		VidHD9x16_39sLink,
		CarouselImgSquareAppInstall,
		CarouselImgSquareLink
	}

	[Flags]
	[Native]
	public enum NativeAdsCachePolicy : long
	{
		None = 1 << 0,
		Icon = 1 << 1,
		CoverImage = 1 << 2,
		Video = 1 << 3,
		AdChoices = 1 << 4,
		All = Icon | CoverImage | Video | AdChoices
	}

	[Native]
	public enum NativeAdViewType : long
	{
		GenericHeight100 = 1,
		GenericHeight120,
		GenericHeight300,
		GenericHeight400,
	}


	[StructLayout (LayoutKind.Sequential)]
	public struct AdStarRating
	{
		public nfloat Value;
		public nint Scale;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct AdSize
	{
		public CGSize Size;
	}
}
