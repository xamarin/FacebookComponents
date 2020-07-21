using System;

using Foundation;
using ObjCRuntime;

namespace Facebook.LoginKit
{
	public enum LoginAuthType {
		// extern FBSDKLoginAuthType _Nonnull FBSDKLoginAuthTypeRerequest;
		[Field ("FBSDKLoginAuthTypeRerequest", "__Internal")]
		Rerequest,

		// extern FBSDKLoginAuthType _Nonnull FBSDKLoginAuthTypeReauthorize;
		[Field ("FBSDKLoginAuthTypeReauthorize", "__Internal")]
		Reauthorize
	}

	[Native]
	public enum LoginButtonTooltipBehavior : ulong
	{
		Automatic = 0,
		ForceDisplay = 1,
		Disable = 2
	}

	[Native]
	public enum LoginError : long {
		Reserved = 300,
		Unknown,
		PasswordChanged,
		UserCheckpointed,
		UserMismatch,
		UnconfirmedUser,
		SystemAccountAppDisabled,
		SystemAccountUnavailable,
		BadChallengeString
	}

	[Native]
	public enum DeviceLoginError : long {
		ExcessivePolling = 1349172,
		AuthorizationDeclined = 1349173,
		AuthorizationPending = 1349174,
		CodeExpired = 1349152
	}

	[Native]
	public enum DefaultAudience : ulong
	{
		Friends = 0,
		OnlyMe,
		Everyone
	}

	[Native]
	public enum TooltipViewArrowDirection : ulong
	{
		Down = 0,
		Up = 1
	}

	[Native]
	public enum TooltipColorStyle : ulong
	{
		FriendlyBlue = 0,
		NeutralGray = 1
	}
}
