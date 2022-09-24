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

    public partial class ContextChooseDialog
    {
        protected override global::System.Collections.IList _OrderedModeHandlers()
        {
            return OrderedModeHandlers.ToList();
        }
    }

    public partial class ContextCreateDialog
    {
        protected override global::System.Collections.IList _OrderedModeHandlers()
        {
            return OrderedModeHandlers.ToList();
        }
    }

    public partial class ContextSwitchDialog
    {
        protected override global::System.Collections.IList _OrderedModeHandlers()
        {
            return OrderedModeHandlers.ToList();
        }
    }

    public partial class TournamentShareDialog
    {
        protected override global::System.Collections.IList _OrderedModeHandlers()
        {
            return OrderedModeHandlers.ToList();
        }
    }

    public partial class TournamentConfig
    {
        public partial class Builder
        {
            public global::Java.Lang.Object ReadFrom(global::Java.Lang.Object model)
            {
                if (model is global::Xamarin.Facebook.GamingServices.TournamentConfig typedModel)
                {
                    return ReadFrom(typedModel);
                }

                return null;
            }
        }
    }
}

namespace Com.Facebook.Gamingservices.Model
{
    public partial class ContextChooseContent
    {
        public partial class Builder
        {
            public global::Java.Lang.Object ReadFrom(global::Java.Lang.Object model)
            {
                if (model is global::Com.Facebook.Gamingservices.Model.ContextChooseContent typedModel)
                {
                    return ReadFrom(typedModel);
                }

                return null;
            }
        }
    }

    public partial class ContextSwitchContent
    {
        public partial class Builder
        {
            public global::Java.Lang.Object ReadFrom(global::Java.Lang.Object model)
            {
                if (model is global::Com.Facebook.Gamingservices.Model.ContextSwitchContent typedModel)
                {
                    return ReadFrom(typedModel);
                }

                return null;
            }
        }
    }

    public partial class ContextCreateContent
    {
        public partial class Builder
        {
            public global::Java.Lang.Object ReadFrom(global::Java.Lang.Object model)
            {
                if (model is global::Com.Facebook.Gamingservices.Model.ContextCreateContent typedModel)
                {
                    return ReadFrom(typedModel);
                }

                return null;
            }
        }
    }
}
