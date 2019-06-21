using System;

using Foundation;

namespace Facebook.CoreKit {
	public partial class Settings {
		public static LoggingBehavior [] LoggingBehaviors {
			get {
				var i = 0;
				var loggingBehaviors = new LoggingBehavior [_LoggingBehaviors.Count];

				foreach (NSString loggingBehavior in _LoggingBehaviors)
					loggingBehaviors [i++] = LoggingBehaviorExtensions.GetValue (loggingBehavior);

				return loggingBehaviors;
			}
			set {
				var loggingBehaviors = new NSString [value.Length];

				for (int i = 0; i < value.Length; i++)
					loggingBehaviors [i] = value [i].GetConstant ();

				_LoggingBehaviors = new NSSet (loggingBehaviors);
			}
		}
	}
}
