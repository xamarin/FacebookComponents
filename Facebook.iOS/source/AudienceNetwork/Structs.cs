using System;
using System.Runtime.InteropServices;

using CoreGraphics;

namespace Facebook.AudienceNetwork {
	[StructLayout (LayoutKind.Sequential)]
	public struct AdSize {
		public CGSize Size;

		public AdSize (CGSize size)
		{
			Size = size;
		}
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct AdStarRating {
		public nfloat Value;
		public nint Scale;

		public AdStarRating (nfloat value, nint scale)
		{
			Value = value;
			Scale = scale;
		}
	}
}
