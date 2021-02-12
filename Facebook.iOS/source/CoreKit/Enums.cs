using System;
using Foundation;
using ObjCRuntime;

namespace Facebook.CoreKit
{
    public enum AppEventName
    {
        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameAchievedLevel;
        [Field("FBSDKAppEventNameAchievedLevel", "__Internal")]
        AchievedLevel,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameAddedPaymentInfo;
        [Field("FBSDKAppEventNameAddedPaymentInfo", "__Internal")]
        AddedPaymentInfo,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameAddedToCart;
        [Field("FBSDKAppEventNameAddedToCart", "__Internal")]
        AddedToCart,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameAddedToWishlist;
        [Field("FBSDKAppEventNameAddedToWishlist", "__Internal")]
        AddedToWishlist,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameCompletedRegistration;
        [Field("FBSDKAppEventNameCompletedRegistration", "__Internal")]
        CompletedRegistration,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameCompletedTutorial;
        [Field("FBSDKAppEventNameCompletedTutorial", "__Internal")]
        CompletedTutorial,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameInitiatedCheckout;
        [Field("FBSDKAppEventNameInitiatedCheckout", "__Internal")]
        InitiatedCheckout,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNamePurchased;
        [Field("FBSDKAppEventNamePurchased", "__Internal")]
        Purchased,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameRated;
        [Field("FBSDKAppEventNameRated", "__Internal")]
        Rated,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameSearched;
        [Field("FBSDKAppEventNameSearched", "__Internal")]
        Searched,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameSpentCredits;
        [Field("FBSDKAppEventNameSpentCredits", "__Internal")]
        SpentCredits,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameUnlockedAchievement;
        [Field("FBSDKAppEventNameUnlockedAchievement", "__Internal")]
        UnlockedAchievement,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameViewedContent;
        [Field("FBSDKAppEventNameViewedContent", "__Internal")]
        ViewedContent,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameContact;
        [Field("FBSDKAppEventNameContact", "__Internal")]
        Contact,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameCustomizeProduct;
        [Field("FBSDKAppEventNameCustomizeProduct", "__Internal")]
        CustomizeProduct,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameDonate;
        [Field("FBSDKAppEventNameDonate", "__Internal")]
        Donate,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameFindLocation;
        [Field("FBSDKAppEventNameFindLocation", "__Internal")]
        FindLocation,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameSchedule;
        [Field("FBSDKAppEventNameSchedule", "__Internal")]
        Schedule,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameStartTrial;
        [Field("FBSDKAppEventNameStartTrial", "__Internal")]
        StartTrial,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameSubmitApplication;
        [Field("FBSDKAppEventNameSubmitApplication", "__Internal")]
        SubmitApplication,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameSubscribe;
        [Field("FBSDKAppEventNameSubscribe", "__Internal")]
        Subscribe,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameAdImpression;
        [Field("FBSDKAppEventNameAdImpression", "__Internal")]
        AdImpression,

        // extern FBSDKAppEventName _Nonnull FBSDKAppEventNameAdClick;
        [Field("FBSDKAppEventNameAdClick", "__Internal")]
        AdClick,
    }

    public enum AppEventParameterName
    {
        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameContent;
        [Field("FBSDKAppEventParameterNameContent", "__Internal")]
        Content,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameContentID;
        [Field("FBSDKAppEventParameterNameContentID", "__Internal")]
        ContentId,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameContentType;
        [Field("FBSDKAppEventParameterNameContentType", "__Internal")]
        ContentType,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameCurrency;
        [Field("FBSDKAppEventParameterNameCurrency", "__Internal")]
        Currency,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameDescription;
        [Field("FBSDKAppEventParameterNameDescription", "__Internal")]
        Description,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameLevel;
        [Field("FBSDKAppEventParameterNameLevel", "__Internal")]
        Level,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameMaxRatingValue;
        [Field("FBSDKAppEventParameterNameMaxRatingValue", "__Internal")]
        MaxRatingValue,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameNumItems;
        [Field("FBSDKAppEventParameterNameNumItems", "__Internal")]
        NumItems,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNamePaymentInfoAvailable;
        [Field("FBSDKAppEventParameterNamePaymentInfoAvailable", "__Internal")]
        PaymentInfoAvailable,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameRegistrationMethod;
        [Field("FBSDKAppEventParameterNameRegistrationMethod", "__Internal")]
        RegistrationMethod,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameSearchString;
        [Field("FBSDKAppEventParameterNameSearchString", "__Internal")]
        SearchString,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameSuccess;
        [Field("FBSDKAppEventParameterNameSuccess", "__Internal")]
        Success,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameAdType;
        [Field("FBSDKAppEventParameterNameAdType", "__Internal")]
        AdType,

        // extern FBSDKAppEventParameterName _Nonnull FBSDKAppEventParameterNameOrderID;
        [Field("FBSDKAppEventParameterNameOrderID", "__Internal")]
        OrderId,
    }

    public enum AppEventParameterProduct
    {
        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductCategory;
        [Field("FBSDKAppEventParameterProductCategory", "__Internal")]
        Category,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductCustomLabel0;
        [Field("FBSDKAppEventParameterProductCustomLabel0", "__Internal")]
        CustomLabel0,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductCustomLabel1;
        [Field("FBSDKAppEventParameterProductCustomLabel1", "__Internal")]
        CustomLabel1,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductCustomLabel2;
        [Field("FBSDKAppEventParameterProductCustomLabel2", "__Internal")]
        CustomLabel2,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductCustomLabel3;
        [Field("FBSDKAppEventParameterProductCustomLabel3", "__Internal")]
        CustomLabel3,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductCustomLabel4;
        [Field("FBSDKAppEventParameterProductCustomLabel4", "__Internal")]
        CustomLabel4,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIOSUrl;
        [Field("FBSDKAppEventParameterProductAppLinkIOSUrl", "__Internal")]
        AppLinkIOSUrl,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIOSAppStoreID;
        [Field("FBSDKAppEventParameterProductAppLinkIOSAppStoreID", "__Internal")]
        AppLinkIOSAppStoreID,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIOSAppName;
        [Field("FBSDKAppEventParameterProductAppLinkIOSAppName", "__Internal")]
        AppLinkIOSAppName,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIPhoneUrl;
        [Field("FBSDKAppEventParameterProductAppLinkIPhoneUrl", "__Internal")]
        AppLinkIPhoneUrl,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIPhoneAppStoreID;
        [Field("FBSDKAppEventParameterProductAppLinkIPhoneAppStoreID", "__Internal")]
        AppLinkIPhoneAppStoreID,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIPhoneAppName;
        [Field("FBSDKAppEventParameterProductAppLinkIPhoneAppName", "__Internal")]
        AppLinkIPhoneAppName,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIPadUrl;
        [Field("FBSDKAppEventParameterProductAppLinkIPadUrl", "__Internal")]
        AppLinkIPadUrl,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIPadAppStoreID;
        [Field("FBSDKAppEventParameterProductAppLinkIPadAppStoreID", "__Internal")]
        AppLinkIPadAppStoreID,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkIPadAppName;
        [Field("FBSDKAppEventParameterProductAppLinkIPadAppName", "__Internal")]
        AppLinkIPadAppName,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkAndroidUrl;
        [Field("FBSDKAppEventParameterProductAppLinkAndroidUrl", "__Internal")]
        AppLinkAndroidUrl,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkAndroidPackage;
        [Field("FBSDKAppEventParameterProductAppLinkAndroidPackage", "__Internal")]
        AppLinkAndroidPackage,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkAndroidAppName;
        [Field("FBSDKAppEventParameterProductAppLinkAndroidAppName", "__Internal")]
        AppLinkAndroidAppName,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkWindowsPhoneUrl;
        [Field("FBSDKAppEventParameterProductAppLinkWindowsPhoneUrl", "__Internal")]
        AppLinkWindowsPhoneUrl,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkWindowsPhoneAppID;
        [Field("FBSDKAppEventParameterProductAppLinkWindowsPhoneAppID", "__Internal")]
        AppLinkWindowsPhoneAppID,

        // extern FBSDKAppEventParameterProduct _Nonnull FBSDKAppEventParameterProductAppLinkWindowsPhoneAppName;
        [Field("FBSDKAppEventParameterProductAppLinkWindowsPhoneAppName", "__Internal")]
        AppLinkWindowsPhoneAppName,
    }

    public enum AppEventParameterValue
    {
        // extern FBSDKAppEventParameterValue _Nonnull FBSDKAppEventParameterValueYes;
        [Field("FBSDKAppEventParameterValueYes", "__Internal")]
        Yes,

        // extern FBSDKAppEventParameterValue _Nonnull FBSDKAppEventParameterValueNo;
        [Field("FBSDKAppEventParameterValueNo", "__Internal")]
        No,
    }

    public enum AppEventUserDataType
    {
        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventEmail;
        [Field("FBSDKAppEventEmail", "__Internal")]
        Email,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventFirstName;
        [Field("FBSDKAppEventFirstName", "__Internal")]
        FirstName,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventLastName;
        [Field("FBSDKAppEventLastName", "__Internal")]
        LastName,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventPhone;
        [Field("FBSDKAppEventPhone", "__Internal")]
        Phone,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventDateOfBirth;
        [Field("FBSDKAppEventDateOfBirth", "__Internal")]
        DateOfBirth,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventGender;
        [Field("FBSDKAppEventGender", "__Internal")]
        Gender,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventCity;
        [Field("FBSDKAppEventCity", "__Internal")]
        City,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventState;
        [Field("FBSDKAppEventState", "__Internal")]
        State,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventZip;
        [Field("FBSDKAppEventZip", "__Internal")]
        Zip,

        // extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventCountry;
        [Field("FBSDKAppEventCountry", "__Internal")]
        Country,
    }

    public enum HttpMethod
    {
        // extern NS_SWIFT_NAME(get) FBSDKHTTPMethod FBSDKHTTPMethodGET __attribute__((swift_name("get")));
        [Field("FBSDKHTTPMethodGET", "__Internal")]
        Get,

        // extern NS_SWIFT_NAME(post) FBSDKHTTPMethod FBSDKHTTPMethodPOST __attribute__((swift_name("post")));
        [Field("FBSDKHTTPMethodPOST", "__Internal")]
        Post,

        // extern NS_SWIFT_NAME(delete) FBSDKHTTPMethod FBSDKHTTPMethodDELETE __attribute__((swift_name("delete")));
        [Field("FBSDKHTTPMethodDELETE", "__Internal")]
        Delete,
    }

    public enum LoggingBehavior
    {
        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorAccessTokens;
        [Field("FBSDKLoggingBehaviorAccessTokens", "__Internal")]
        AccessTokens,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorPerformanceCharacteristics;
        [Field("FBSDKLoggingBehaviorPerformanceCharacteristics", "__Internal")]
        PerformanceCharacteristics,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorAppEvents;
        [Field("FBSDKLoggingBehaviorAppEvents", "__Internal")]
        AppEvents,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorInformational;
        [Field("FBSDKLoggingBehaviorInformational", "__Internal")]
        Informational,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorCacheErrors;
        [Field("FBSDKLoggingBehaviorCacheErrors", "__Internal")]
        CacheErrors,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorUIControlErrors;
        [Field("FBSDKLoggingBehaviorUIControlErrors", "__Internal")]
        UIControlErrors,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorGraphAPIDebugWarning;
        [Field("FBSDKLoggingBehaviorGraphAPIDebugWarning", "__Internal")]
        GraphAPIDebugWarning,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorGraphAPIDebugInfo;
        [Field("FBSDKLoggingBehaviorGraphAPIDebugInfo", "__Internal")]
        GraphAPIDebugInfo,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorNetworkRequests;
        [Field("FBSDKLoggingBehaviorNetworkRequests", "__Internal")]
        NetworkRequests,

        // extern FBSDKLoggingBehavior _Nonnull FBSDKLoggingBehaviorDeveloperErrors;
        [Field("FBSDKLoggingBehaviorDeveloperErrors", "__Internal")]
        DeveloperErrors,
    }

    [Native]
    public enum AppEventsFlushBehavior : ulong
    {
        Auto = 0,
        ExplicitOnly
    }

    [Native]
    public enum ProductAvailability : ulong
    {
        InStock = 0,
        OutOfStock,
        PreOrder,
        AvailableForOrder,
        Discontinued
    }

    [Native]
    public enum ProductCondition : ulong
    {
        New = 0,
        Refurbished,
        Used
    }

    [Native]
    public enum AppLinkNavigationType : long
    {
        Failure,
        Browser,
        App
    }

    [Native]
    public enum IncludeStatusBarInSize : ulong
    {
        Never,
        Always
    }

    [Native]
    public enum CoreError : long
    {
        Reserved = 0,
        Encryption,
        InvalidArgument,
        Unknown,
        Network,
        AppEventsFlush,
        GraphRequestNonTextMimeTypeReturned,
        GraphRequestProtocolMismatch,
        GraphRequestGraphAPI,
        DialogUnavailable,
        AccessTokenRequired,
        AppVersionUnsupported,
        BrowserUnavailable,
        BridgeAPIInterruption
    }

    [Native]
    public enum GraphRequestError : ulong
    {
        Other = 0,
        Transient = 1,
        Recoverable = 2
    }

    [Native]
    public enum ProfilePictureMode : ulong
    {
        Square,
        Normal,
        Album,
        Small,
        Large
    }
}
