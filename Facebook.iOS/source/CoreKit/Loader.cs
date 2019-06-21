using System;

namespace Facebook.CoreKit
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
			Facebook.CoreKit.Loader.ForceLoad ();
		}
	}
}
