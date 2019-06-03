using System;

namespace Facebook.Notifications
{
	public class Loader
	{
		static Loader ()
		{
		}

		public static void ForceLoad () { }
	}
}

namespace ApiDefinition
{
	partial class Messaging
	{
		static Messaging ()
		{
			Facebook.Notifications.Loader.ForceLoad ();
		}
	}
}
