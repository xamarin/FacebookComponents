using System;
using Foundation;
using CoreFoundation;
using System.Threading.Tasks;
namespace Facebook.CoreKit {
	public static partial class Errors {
		[Obsolete ("Use GraphRequestErrors.HttpStatusCodeKey static property instead. This will be removed in future versions.")]
		public static NSString HttpStatusCodeKey { get; } = GraphRequestErrors.HttpStatusCodeKey;

		[Obsolete ("Use GraphRequestErrors.ParsedJsonResponseKey static property instead. This will be removed in future versions.")]
		public static NSString ParsedJSONResponseKey { get; } = GraphRequestErrors.ParsedJsonResponseKey;
	}

	public partial class Settings {
		public static bool AutoLogAppEventsEnabled {
			get { return _AutoLogAppEventsEnabled.Int32Value == 1; }
			set { _AutoLogAppEventsEnabled = NSNumber.FromInt32 (value ? 1 : 0); }
		}

		public static bool CodelessDebugLogEnabled {
			get { return _CodelessDebugLogEnabled.Int32Value == 1; }
			set { _CodelessDebugLogEnabled = NSNumber.FromInt32 (value ? 1 : 0); }
		}

		public static bool AdvertiserIdCollectionEnabled {
			get { return _AdvertiserIdCollectionEnabled.Int32Value == 1; }
			set { _AdvertiserIdCollectionEnabled = NSNumber.FromInt32 (value ? 1 : 0); }
		}
	}

	public partial class TestUsersManager {
		public unsafe virtual System.Threading.Tasks.Task RemoveTestAccountAsync (string userId)
		{
			var tcs = new TaskCompletionSource<bool> ();
			RemoveTestAccount (userId, (error_) => {
				if (error_ != null)
					tcs.SetException (new NSErrorException (error_));
				else
					tcs.SetResult (true);
			});
			return tcs.Task;
		}
	}
}
