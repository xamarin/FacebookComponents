using System;

using ObjCRuntime;

namespace Facebook.Notifications {
	[Native]
	public enum NotificationsErrorCode : ulong
	{
		InvalidPayload = 1
	}
}
