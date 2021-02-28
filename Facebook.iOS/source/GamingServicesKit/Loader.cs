using System;

namespace Facebook.GamingServicesKit
{
	public class Loader
	{
		static Loader ()
		{
			Facebook.CoreKit.Loader.ForceLoad ();
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
			Facebook.GamingServicesKit.Loader.ForceLoad ();
		}
	}
}
