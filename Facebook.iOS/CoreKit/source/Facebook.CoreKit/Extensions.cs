using System;
using Foundation;
using CoreFoundation;
namespace Facebook.CoreKit
{
	public static partial class Errors {
		[Obsolete ("Use GraphRequestErrors.HttpStatusCodeKey static property instead. This will be removed in future versions.")]
		public static NSString HttpStatusCodeKey { get; } = GraphRequestErrors.HttpStatusCodeKey;

		[Obsolete ("Use GraphRequestErrors.ParsedJsonResponseKey static property instead. This will be removed in future versions.")]
		public static NSString ParsedJSONResponseKey { get; } = GraphRequestErrors.ParsedJsonResponseKey;
	}

	public partial class Settings
	{
		public static bool AutoLogAppEventsEnabled {
			get { return _AutoLogAppEventsEnabled.Int32Value == 1; }
			set { _AutoLogAppEventsEnabled = NSNumber.FromInt32 (value ? 1 : 0); }
		}

		public static bool CodelessDebugLogEnabled {
			get { return _CodelessDebugLogEnabled.Int32Value == 1; }
			set { _CodelessDebugLogEnabled = NSNumber.FromInt32 (value ? 1 : 0); }
		}
	}
}
