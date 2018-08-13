using System;

namespace Facebook.MessengerShareKit
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
			Facebook.MessengerShareKit.Loader.ForceLoad ();
		}
	}
}
