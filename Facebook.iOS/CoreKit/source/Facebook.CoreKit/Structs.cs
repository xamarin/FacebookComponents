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
