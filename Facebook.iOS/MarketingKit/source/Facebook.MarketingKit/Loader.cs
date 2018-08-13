using System;

namespace Facebook.MarketingKit
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
			Facebook.MarketingKit.Loader.ForceLoad ();
		}
	}
}
