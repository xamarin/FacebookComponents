using System;

using ObjCRuntime;

namespace Facebook.MarketingKit {
	[Native]
	public enum FBSDKAppEventsFlushBehavior : ulong
	{
		Auto = 0,
		ExplicitOnly
	}
}
