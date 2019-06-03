using System;

using ObjCRuntime;

namespace Facebook.MessengerShareKit
{
	[Native]
	public enum MessengerShareButtonStyle : ulong
	{
		Blue = 0,
		White = 1,
		WhiteBordered = 2
	}

	[Flags]
	[Native]
	public enum MessengerPlatformCapability : ulong
	{
		None = 0,
		Open = 1 << 0,
		Image = 1 << 1,
		AnimatedGIF = 1 << 2,
		AnimatedWebP = 1 << 3,
		Video = 1 << 4,
		Audio = 1 << 5,
		RenderAsSticker = 1 << 6
	}
}
