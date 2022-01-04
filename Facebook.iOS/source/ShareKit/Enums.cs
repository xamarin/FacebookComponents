using System;

using ObjCRuntime;

namespace Facebook.ShareKit
{
	[Native]
	public enum AppGroupPrivacy : ulong
	{
		Open = 0,
		Closed
	}

	[Native]
	public enum AppInviteDestination : ulong
	{
		Facebook = 0,
		Messenger,
	}

	[Native]
	public enum GameRequestActionType : ulong
	{
		None = 0,
		Send,
		AskFor,
		Turn,
		Invite
	}

	[Native]
	public enum GameRequestFilter : ulong
	{
		None = 0,
		AppUsers,
		AppNonUsers,
		Everybody
	}

	[Native]
	public enum ShareError : long {
		Reserved = 200,
		OpenGraph,
		DialogNotAvailable,
		Unknown
	}

	[Native]
	public enum ShareDialogMode : ulong
	{
		Automatic = 0,
		Native,
		ShareSheet,
		Browser,
		Web,
		FeedBrowser,
		FeedWeb
	}

	[Flags]
	[Native]
	public enum ShareBridgeOptions : ulong {
		Default = 0,
		PhotoAsset = 1 << 0,
		PhotoImageURL = 1 << 1,
		VideoAsset = 1 << 2,
		VideoData = 1 << 3,
		WebHashtag = 1 << 4
	}
}
