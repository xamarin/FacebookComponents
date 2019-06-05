using System;

using ObjCRuntime;

namespace Facebook.PlacesKit
{
	[Native]
	public enum PlaceLocationConfidence : long
	{
		NotApplicable,
		Low,
		Medium,
		High
	}
}
