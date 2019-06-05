using System;

using ObjCRuntime;

namespace Facebook.CoreKit
{
	[Native]
	public enum AppEventsFlushBehavior : ulong
	{
		Auto = 0,
		ExplicitOnly
	}

	[Native]
	public enum ProductAvailability : ulong {
		InStock = 0,
		OutOfStock,
		PreOrder,
		AvailableForOrder,
		Discontinued
	}

	[Native]
	public enum ProductCondition : ulong {
		New = 0,
		Refurbished,
		Used
	}

	[Native]
	public enum AppLinkNavigationType : long {
		Failure,
		Browser,
		App
	}

	[Native]
	public enum IncludeStatusBarInSize : ulong {
		Never,
		iOS7AndLater,
		Always
	}

	[Native]
	public enum Error : long {
		Reserved = 0,
		Encryption,
		InvalidArgument,
		Unknown,
		Network,
		AppEventsFlush,
		GraphRequestNonTextMimeTypeReturned,
		GraphRequestProtocolMismatch,
		GraphRequestGraphApi,
		DialogUnavailable,
		AccessTokenRequired,
		AppVersionUnsupported,
		BrowserUnavailable
	}

	[Native]
	public enum GraphRequestError : ulong {
		Other = 0,
		Transient = 1,
		Recoverable = 2
	}

	[Obsolete ("Use Error enum instead.")]
	[Native]
	public enum ErrorCode : long
	{
		Reserved = 0,
		Encryption,
		InvalidArgument,
		Unknown,
		Network,
		AppEventsFlush,
		GraphRequestNonTextMimeTypeReturned,
		GraphRequestProtocolMismatch,
		GraphRequestGraphAPI,
		DialogUnavailable,
		AccessTokenRequired,
		AppVersionUnsupported,
		BrowserUnavailable,
		BrowswerUnavailable = BrowserUnavailable
	}

	[Obsolete ("Use GraphRequestError enum instead.")]
	[Native]
	public enum GraphRequestErrorCategory : ulong
	{
		Other = 0,
		Transient = 1,
		Recoverable = 2
	}

	[Native]
	public enum ProfilePictureMode : ulong
	{
		Square,
		Normal
	}
}
