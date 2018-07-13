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
	public enum LikeControlAuxiliaryPosition : ulong
	{
		Inline,
		Top,
		Bottom
	}

	[Native]
	public enum LikeControlHorizontalAlignment : ulong
	{
		Left,
		Center,
		Right
	}

	[Native]
	public enum LikeControlStyle : ulong
	{
		Standard = 0,
		BoxCount
	}

	[Native]
	public enum LikeObjectType : ulong
	{
		Unknown = 0,
		OpenGraph,
		Page
	}

	[Native]
	public enum ShareErrorCode : long
	{
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
}
