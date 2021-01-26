using Android.Runtime;
using System;
using System.Linq;

namespace Xamarin.Facebook.GamingServices
{
    public partial class FriendFinderDialog
    {
        protected override global::System.Collections.IList _OrderedModeHandlers()
        {
            return OrderedModeHandlers.ToList();
        }
    }

    public partial class GamingGroupIntegration
    {
        protected override global::System.Collections.IList _OrderedModeHandlers()
        {
            return OrderedModeHandlers.ToList();
        }
    }

    public partial class GameRequestDialog
    {
        protected override global::System.Collections.IList _OrderedModeHandlers()
        {
            return OrderedModeHandlers.ToList();
        }
    }
}
