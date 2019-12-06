using System;

using Foundation;
using ObjCRuntime;

namespace Facebook.CoreKit
{
	public enum AppEventName {
		// extern NSString *const FBSDKAppEventNameAchievedLevel;
		[Field ("FBSDKAppEventNameAchievedLevel", "__Internal")]
		AchievedLevel,

		// extern NSString *const FBSDKAppEventNameAddedPaymentInfo;
		[Field ("FBSDKAppEventNameAddedPaymentInfo", "__Internal")]
		AddedPaymentInfo,

		// extern NSString *const FBSDKAppEventNameAddedToCart;
		[Field ("FBSDKAppEventNameAddedToCart", "__Internal")]
		AddedToCart,

		// extern NSString *const FBSDKAppEventNameAddedToWishlist;
		[Field ("FBSDKAppEventNameAddedToWishlist", "__Internal")]
		AddedToWishlist,

		// extern NSString *const FBSDKAppEventNameCompletedRegistration;
		[Field ("FBSDKAppEventNameCompletedRegistration", "__Internal")]
		CompletedRegistration,

		// extern NSString *const FBSDKAppEventNameCompletedTutorial;
		[Field ("FBSDKAppEventNameCompletedTutorial", "__Internal")]
		CompletedTutorial,

		// extern NSString *const FBSDKAppEventNameInitiatedCheckout;
		[Field ("FBSDKAppEventNameInitiatedCheckout", "__Internal")]
		InitiatedCheckout,

		// extern FBSDKAppEventName _Nonnull FBSDKAppEventNamePurchased;
		[Field ("FBSDKAppEventNamePurchased", "__Internal")]
		Purchased,

		// extern NSString *const FBSDKAppEventNameRated;
		[Field ("FBSDKAppEventNameRated", "__Internal")]
		Rated,

		// extern NSString *const FBSDKAppEventNameSearched;
		[Field ("FBSDKAppEventNameSearched", "__Internal")]
		Searched,

		// extern NSString *const FBSDKAppEventNameSpentCredits;
		[Field ("FBSDKAppEventNameSpentCredits", "__Internal")]
		SpentCredits,

		// extern NSString *const FBSDKAppEventNameUnlockedAchievement;
		[Field ("FBSDKAppEventNameUnlockedAchievement", "__Internal")]
		UnlockedAchievement,

		// extern NSString *const FBSDKAppEventNameViewedContent;
		[Field ("FBSDKAppEventNameViewedContent", "__Internal")]
		ViewedContent,

		// extern NSString *const FBSDKAppEventNameContact;
		[Field ("FBSDKAppEventNameContact", "__Internal")]
		Contact,

		// extern NSString *const FBSDKAppEventNameCustomizeProduct;
		[Field ("FBSDKAppEventNameCustomizeProduct", "__Internal")]
		CustomizeProduct,

		// extern NSString *const FBSDKAppEventNameDonate;
		[Field ("FBSDKAppEventNameDonate", "__Internal")]
		Donate,

		// extern NSString *const FBSDKAppEventNameFindLocation;
		[Field ("FBSDKAppEventNameFindLocation", "__Internal")]
		FindLocation,

		// extern NSString *const FBSDKAppEventNameSchedule;
		[Field ("FBSDKAppEventNameSchedule", "__Internal")]
		Schedule,

		// extern FBSDKAppEventName _Nonnull FBSDKAppEventNameSubscriptionHeartbeat;
		[Obsolete ("This attribute is no longer used.")]
		[Field ("FBSDKAppEventNameSubscriptionHeartbeat", "__Internal")]
		SubscriptionHeartbeat,

		// extern NSString *const FBSDKAppEventNameStartTrial;
		[Field ("FBSDKAppEventNameStartTrial", "__Internal")]
		StartTrial,

		// extern NSString *const FBSDKAppEventNameSubmitApplication;
		[Field ("FBSDKAppEventNameSubmitApplication", "__Internal")]
		SubmitApplication,

		// extern NSString *const FBSDKAppEventNameSubscribe;
		[Field ("FBSDKAppEventNameSubscribe", "__Internal")]
		Subscribe,

		// extern NSString *const FBSDKAppEventNameAdImpression;
		[Field ("FBSDKAppEventNameAdImpression", "__Internal")]
		AdImpression,

		// extern NSString *const FBSDKAppEventNameAdClick;
		[Field ("FBSDKAppEventNameAdClick", "__Internal")]
		AdClick
	}

	public enum AppEventParameterName {
		// extern NSString *const FBSDKAppEventParameterNameContent;
		[Field ("FBSDKAppEventParameterNameContent", "__Internal")]
		Content,

		// extern NSString *const FBSDKAppEventParameterNameContentID;
		[Field ("FBSDKAppEventParameterNameContentID", "__Internal")]
		ContentId,

		[Obsolete ("Use ContentId enum value instead. This will be removed in future versions.")]
		//[Field (null)]
		ContentID = ContentId,

		// extern NSString *const FBSDKAppEventParameterNameContentType;
		[Field ("FBSDKAppEventParameterNameContentType", "__Internal")]
		ContentType,

		// extern NSString *const FBSDKAppEventParameterNameCurrency;
		[Field ("FBSDKAppEventParameterNameCurrency", "__Internal")]
		Currency,

		// extern NSString *const FBSDKAppEventParameterNameDescription;
		[Field ("FBSDKAppEventParameterNameDescription", "__Internal")]
		Description,

		// extern NSString *const FBSDKAppEventParameterNameLevel;
		[Field ("FBSDKAppEventParameterNameLevel", "__Internal")]
		Level,

		// extern NSString *const FBSDKAppEventParameterNameMaxRatingValue;
		[Field ("FBSDKAppEventParameterNameMaxRatingValue", "__Internal")]
		MaxRatingValue,

		// extern NSString *const FBSDKAppEventParameterNameNumItems;
		[Field ("FBSDKAppEventParameterNameNumItems", "__Internal")]
		NumItems,

		// extern NSString *const FBSDKAppEventParameterNamePaymentInfoAvailable;
		[Field ("FBSDKAppEventParameterNamePaymentInfoAvailable", "__Internal")]
		PaymentInfoAvailable,

		// extern NSString *const FBSDKAppEventParameterNameRegistrationMethod;
		[Field ("FBSDKAppEventParameterNameRegistrationMethod", "__Internal")]
		RegistrationMethod,

		// extern NSString *const FBSDKAppEventParameterNameSearchString;
		[Field ("FBSDKAppEventParameterNameSearchString", "__Internal")]
		SearchString,

		// extern NSString *const FBSDKAppEventParameterNameSuccess;
		[Field ("FBSDKAppEventParameterNameSuccess", "__Internal")]
		Success,

		// extern NSString *const FBSDKAppEventParameterNameAdType;
		[Field ("FBSDKAppEventParameterNameAdType", "__Internal")]
		AdType,

		// extern NSString *const FBSDKAppEventParameterNameOrderID;
		[Field ("FBSDKAppEventParameterNameOrderID", "__Internal")]
		OrderId,
	}

	public enum AppEventParameterProduct {
		// extern NSString *const FBSDKAppEventParameterProductCustomLabel0;
		[Field ("FBSDKAppEventParameterProductCustomLabel0", "__Internal")]
		CustomLabel0,

		// extern NSString *const FBSDKAppEventParameterProductCustomLabel1;
		[Field ("FBSDKAppEventParameterProductCustomLabel1", "__Internal")]
		CustomLabel1,

		// extern NSString *const FBSDKAppEventParameterProductCustomLabel2;
		[Field ("FBSDKAppEventParameterProductCustomLabel2", "__Internal")]
		CustomLabel2,

		// extern NSString *const FBSDKAppEventParameterProductCustomLabel3;
		[Field ("FBSDKAppEventParameterProductCustomLabel3", "__Internal")]
		CustomLabel3,

		// extern NSString *const FBSDKAppEventParameterProductCustomLabel4;
		[Field ("FBSDKAppEventParameterProductCustomLabel4", "__Internal")]
		CustomLabel4,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIOSUrl;
		[Field ("FBSDKAppEventParameterProductAppLinkIOSUrl", "__Internal")]
		AppLinkiOSUrl,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIOSAppStoreID;
		[Field ("FBSDKAppEventParameterProductAppLinkIOSAppStoreID", "__Internal")]
		AppLinkiOSAppStoreId,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIOSAppName;
		[Field ("FBSDKAppEventParameterProductAppLinkIOSAppName", "__Internal")]
		AppLinkiOSAppName,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIPhoneUrl;
		[Field ("FBSDKAppEventParameterProductAppLinkIPhoneUrl", "__Internal")]
		AppLinkiPhoneUrl,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIPhoneAppStoreID;
		[Field ("FBSDKAppEventParameterProductAppLinkIPhoneAppStoreID", "__Internal")]
		AppLinkiPhoneAppStoreId,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIPhoneAppName;
		[Field ("FBSDKAppEventParameterProductAppLinkIPhoneAppName", "__Internal")]
		AppLinkiPhoneAppName,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIPadUrl;
		[Field ("FBSDKAppEventParameterProductAppLinkIPadUrl", "__Internal")]
		AppLinkiPadUrl,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIPadAppStoreID;
		[Field ("FBSDKAppEventParameterProductAppLinkIPadAppStoreID", "__Internal")]
		AppLinkiPadAppStoreId,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkIPadAppName;
		[Field ("FBSDKAppEventParameterProductAppLinkIPadAppName", "__Internal")]
		AppLinkiPadAppName,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkAndroidUrl;
		[Field ("FBSDKAppEventParameterProductAppLinkAndroidUrl", "__Internal")]
		AppLinkAndroidUrl,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkAndroidPackage;
		[Field ("FBSDKAppEventParameterProductAppLinkAndroidPackage", "__Internal")]
		AppLinkAndroidPackage,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkAndroidAppName;
		[Field ("FBSDKAppEventParameterProductAppLinkAndroidAppName", "__Internal")]
		AppLinkAndroidAppName,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkWindowsPhoneUrl;
		[Field ("FBSDKAppEventParameterProductAppLinkWindowsPhoneUrl", "__Internal")]
		AppLinkWindowsPhoneUrl,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkWindowsPhoneAppID;
		[Field ("FBSDKAppEventParameterProductAppLinkWindowsPhoneAppID", "__Internal")]
		AppLinkWindowsPhoneAppId,

		// extern NSString *const FBSDKAppEventParameterProductAppLinkWindowsPhoneAppName;
		[Field ("FBSDKAppEventParameterProductAppLinkWindowsPhoneAppName", "__Internal")]
		AppLinkWindowsPhoneAppName
	}

	public enum AppEventParameterValue {
		// extern NSString *const FBSDKAppEventParameterValueYes;
		[Field ("FBSDKAppEventParameterValueYes", "__Internal")]
		Yes,

		// extern NSString *const FBSDKAppEventParameterValueNo;
		[Field ("FBSDKAppEventParameterValueNo", "__Internal")]
		No,
	}

	public enum AppEventUserDataType {
		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventEmail;
		[Field ("FBSDKAppEventEmail", "__Internal")]
		Email,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventFirstName;
		[Field ("FBSDKAppEventFirstName", "__Internal")]
		FirstName,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventLastName;
		[Field ("FBSDKAppEventLastName", "__Internal")]
		LastName,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventPhone;
		[Field ("FBSDKAppEventPhone", "__Internal")]
		Phone,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventDateOfBirth;
		[Field ("FBSDKAppEventDateOfBirth", "__Internal")]
		DateOfBirth,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventGender;
		[Field ("FBSDKAppEventGender", "__Internal")]
		Gender,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventCity;
		[Field ("FBSDKAppEventCity", "__Internal")]
		City,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventState;
		[Field ("FBSDKAppEventState", "__Internal")]
		State,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventZip;
		[Field ("FBSDKAppEventZip", "__Internal")]
		Zip,

		// extern FBSDKAppEventUserDataType _Nonnull FBSDKAppEventCountry;
		[Field ("FBSDKAppEventCountry", "__Internal")]
		Country
	}

	public enum HttpMethod {
		// extern FBSDKHTTPMethod _Nonnull FBSDKHTTPMethodGET;
		[Field ("FBSDKHTTPMethodGET", "__Internal")]
		Get,

		// extern FBSDKHTTPMethod _Nonnull FBSDKHTTPMethodPOST;
		[Field ("FBSDKHTTPMethodPOST", "__Internal")]
		Post,

		// extern FBSDKHTTPMethod _Nonnull FBSDKHTTPMethodDELETE;
		[Field ("FBSDKHTTPMethodDELETE", "__Internal")]
		Delete
	}

	public enum LoggingBehavior {

		// extern NSString *const FBSDKLoggingBehaviorAccessTokens;
		[Field ("FBSDKLoggingBehaviorAccessTokens", "__Internal")]
		AccessTokens,

		// extern NSString *const FBSDKLoggingBehaviorPerformanceCharacteristics;
		[Field ("FBSDKLoggingBehaviorPerformanceCharacteristics", "__Internal")]
		PerformanceCharacteristics,

		// extern NSString *const FBSDKLoggingBehaviorAppEvents;
		[Field ("FBSDKLoggingBehaviorAppEvents", "__Internal")]
		AppEvents,

		// extern NSString *const FBSDKLoggingBehaviorInformational;
		[Field ("FBSDKLoggingBehaviorInformational", "__Internal")]
		Informational,

		// extern NSString *const FBSDKLoggingBehaviorCacheErrors;
		[Field ("FBSDKLoggingBehaviorCacheErrors", "__Internal")]
		CacheErrors,

		// extern NSString *const FBSDKLoggingBehaviorUIControlErrors;
		[Field ("FBSDKLoggingBehaviorUIControlErrors", "__Internal")]
		UIControlErrors,

		// extern NSString *const FBSDKLoggingBehaviorGraphAPIDebugWarning;
		[Field ("FBSDKLoggingBehaviorGraphAPIDebugWarning", "__Internal")]
		GraphAPIDebugWarning,

		// extern NSString *const FBSDKLoggingBehaviorGraphAPIDebugInfo;
		[Field ("FBSDKLoggingBehaviorGraphAPIDebugInfo", "__Internal")]
		GraphAPIDebugInfo,

		// extern NSString *const FBSDKLoggingBehaviorNetworkRequests;
		[Field ("FBSDKLoggingBehaviorNetworkRequests", "__Internal")]
		NetworkRequests,

		// extern NSString *const FBSDKLoggingBehaviorDeveloperErrors;
		[Field ("FBSDKLoggingBehaviorDeveloperErrors", "__Internal")]
		DeveloperErrors
	}

	[Native]
	public enum AppEventsFlushBehavior : ulong
	{
		Auto = 0,
		ExplicitOnly
	}

	[Native]
	public enum ProductAvailability : ulong {
		InStock = 0,
		OutOfStock,
		PreOrder,
		AvailableForOrder,
		Discontinued
	}

	[Native]
	public enum ProductCondition : ulong {
		New = 0,
		Refurbished,
		Used
	}

	[Native]
	public enum AutoAppLinkPresentationStyle : ulong
	{
		Auto = 0,
		Present,
		Push
	}

	[Native]
	public enum AppLinkNavigationType : long {
		Failure,
		Browser,
		App
	}

	[Native]
	public enum IncludeStatusBarInSize : ulong {
		Never,
		Always
	}

	[Native]
	public enum CoreError : long {
		Reserved = 0,
		Encryption,
		InvalidArgument,
		Unknown,
		Network,
		AppEventsFlush,
		GraphRequestNonTextMimeTypeReturned,
		GraphRequestProtocolMismatch,
		GraphRequestGraphApi,
		DialogUnavailable,
		AccessTokenRequired,
		AppVersionUnsupported,
		BrowserUnavailable
	}

	[Native]
	public enum GraphRequestError : ulong {
		Other = 0,
		Transient = 1,
		Recoverable = 2
	}

	[Native]
	public enum ProfilePictureMode : ulong
	{
		Square,
		Normal
	}
}
