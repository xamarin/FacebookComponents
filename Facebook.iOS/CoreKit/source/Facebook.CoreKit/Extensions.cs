using System;
using Foundation;
using CoreFoundation;
namespace Facebook.CoreKit
{
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
