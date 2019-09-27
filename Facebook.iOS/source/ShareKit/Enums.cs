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
		Turn
	}

	[Native]
	public enum GameRequestFilter : ulong
	{
		None = 0,
		AppUsers,
		AppNonUsers
	}

	[Native]
	public enum LikeObjectType : ulong
	{
		Unknown = 0,
		OpenGraph,
		Page
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

	[Obsolete ("Sharing to Messenger via the SDK is unsupported. https://developers.facebook.com/docs/messenger-platform/changelog/#20190610. Sharing should be performed by the native share sheet.")]
	[Native]
	public enum ShareMessengerGenericTemplateImageAspectRatio : ulong
	{
		Horizontal = 0,
		Square
	}

	[Native]
	public enum ShareMessengerMediaTemplateMediaType : ulong
	{
		Image = 0,
		Video
	}

	[Native]
	public enum ShareMessengerURLActionButtonWebviewHeightRatio : ulong
	{
		Full = 0,
		Tall,
		Compact
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
