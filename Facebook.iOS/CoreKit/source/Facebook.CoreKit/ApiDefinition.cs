using System;

using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using WebKit;

namespace Facebook.CoreKit {
	interface AccessTokenDidChangeEventArgs {
		[Export ("FBSDKAccessTokenChangeNewKey")]
		AccessToken NewToken { get; }

		[Export ("FBSDKAccessTokenDidChangeUserID")]
		bool DidChangeUserIdToken { get; }

		[Export ("FBSDKAccessTokenChangeOldKey")]
		AccessToken OldToken { get; }

		[Export ("FBSDKAccessTokenDidExpire")]
		bool DidExpireKey { get; }
	}

	// @interface FBSDKAccessToken : NSObject <FBSDKCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAccessToken")]
	interface AccessToken : Copying, INSSecureCoding {

		// extern NSString *const FBSDKAccessTokenDidChangeNotification;
		[Notification (typeof (AccessTokenDidChangeEventArgs))]
		[Field ("FBSDKAccessTokenDidChangeNotification", "__Internal")]
		NSString DidChangeNotification { get; }

		[Field ("FBSDKAccessTokenChangeNewKey", "__Internal")]
		NSString NewTokenKey { get; }

		[Field ("FBSDKAccessTokenDidChangeUserID", "__Internal")]
		NSString UserIdKey { get; }

		[Field ("FBSDKAccessTokenChangeOldKey", "__Internal")]
		NSString OldTokenKey { get; }

		// FBSDK_EXTERN NSString *const FBSDKAccessTokenDidExpire;
		[Field ("FBSDKAccessTokenDidExpire", "__Internal")]
		NSString DidExpireKey { get; }

		// @property (readonly, copy, nonatomic) NSString * appID;
		[Export ("appID")]
		string AppId { get; }

		[Obsolete ("Use AppId property instead. This will be removed in future versions.")]
		[Wrap ("AppId")]
		string AppID { get; }

		// @property (readonly, copy, nonatomic) NSDate * dataAccessExpirationDate;
		[Export ("dataAccessExpirationDate", ArgumentSemantic.Copy)]
		NSDate DataAccessExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NSSet * declinedPermissions;
		[Export ("declinedPermissions", ArgumentSemantic.Copy)]
		NSSet DeclinedPermissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NSSet * permissions;
		[Export ("permissions", ArgumentSemantic.Copy)]
		NSSet Permissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * refreshDate;
		[Export ("refreshDate", ArgumentSemantic.Copy)]
		NSDate RefreshDate { get; }

		// @property (readonly, copy, nonatomic) NSString * tokenString;
		[Export ("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * userID;
		[Export ("userID", ArgumentSemantic.Copy)]
		string UserId { get; }

		[Obsolete ("Use UserId property instead. This will be removed in future versions.")]
		[Wrap ("UserID")]
		string UserID { get; }

		// @property (readonly, assign, nonatomic, getter = isExpired) BOOL expired;
		[Export ("isExpired", ArgumentSemantic.Assign)]
		bool IsExpired { get; }

		// @property (readonly, getter = isDataAccessExpired, assign, nonatomic) BOOL dataAccessExpired;
		[Export ("isDataAccessExpired")]
		bool IsDataAccessExpired { get; }

		// -(instancetype)initWithTokenString:(NSString *)tokenString permissions:(NSArray *)permissions declinedPermissions:(NSArray *)declinedPermissions appID:(NSString *)appID userID:(NSString *)userID expirationDate:(NSDate *)expirationDate refreshDate:(NSDate *)refreshDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithTokenString:permissions:declinedPermissions:appID:userID:expirationDate:refreshDate:")]
		IntPtr Constructor (string tokenString, [NullAllowed] string [] permissions, [NullAllowed] string [] declinedPermissions, string appId, string userId, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate);

		// -(instancetype)initWithTokenString:(NSString *)tokenString permissions:(NSArray *)permissions declinedPermissions:(NSArray *)declinedPermissions appID:(NSString *)appID userID:(NSString *)userID expirationDate:(NSDate *)expirationDate refreshDate:(NSDate *)refreshDate dataAccessExpirationDate:(NSDate *)dataAccessExpirationDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithTokenString:permissions:declinedPermissions:appID:userID:expirationDate:refreshDate:dataAccessExpirationDate:")]
		IntPtr Constructor (string tokenString, [NullAllowed] string [] permissions, [NullAllowed] string [] declinedPermissions, string appId, string userId, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate, [NullAllowed] NSDate dataAccessExpirationDate);

		// -(BOOL)hasGranted:(NSString *)permission;
		[Export ("hasGranted:")]
		bool HasGranted (string permission);

		// -(BOOL)isEqualToAccessToken:(FBSDKAccessToken *)token;
		[Export ("isEqualToAccessToken:")]
		bool Equals (AccessToken token);

		[Obsolete ("Use Equals (AccessToken) overload method instead. This will be removed in future version.")]
		[Wrap ("Equals (token)")]
		bool IsEqualToAccessToken (AccessToken token);

		// +(FBSDKAccessToken *)currentAccessToken;
		// +(void)setCurrentAccessToken:(FBSDKAccessToken *)token;
		[Static]
		[Export ("currentAccessToken")]
		AccessToken CurrentAccessToken { get; set; }

		// + (BOOL)currentAccessTokenIsActive;
		[Static]
		[Export ("currentAccessTokenIsActive")]
		bool CurrentAccessTokenIsActive { get; }

		// + (void)refreshCurrentAccessToken:(FBSDKGraphRequestHandler)completionHandler;
		[Static]
		[Export ("refreshCurrentAccessToken:")]
		void RefreshCurrentAccessToken (GraphRequestHandler completionHandler);
	}

	// @interface FBSDKAppEvents : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppEvents")]
	interface AppEvents {

		// extern NSString *const FBSDKAppEventsLoggingResultNotification;
		[Notification]
		[Field ("FBSDKAppEventsLoggingResultNotification", "__Internal")]
		NSString LoggingResultNotification { get; }

		// extern NSString *const FBSDKAppEventsOverrideAppIDBundleKey;
		[Field ("FBSDKAppEventsOverrideAppIDBundleKey", "__Internal")]
		NSString OverrideAppIdBundleKey { get; }

		// extern NSString *const FBSDKAppEventNameAchievedLevel;
		[Field ("FBSDKAppEventNameAchievedLevel", "__Internal")]
		NSString AchievedLevelEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedPaymentInfo;
		[Field ("FBSDKAppEventNameAddedPaymentInfo", "__Internal")]
		NSString AddedPaymentInfoEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedToCart;
		[Field ("FBSDKAppEventNameAddedToCart", "__Internal")]
		NSString AddedToCartEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAddedToWishlist;
		[Field ("FBSDKAppEventNameAddedToWishlist", "__Internal")]
		NSString AddedToWishlistEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameCompletedRegistration;
		[Field ("FBSDKAppEventNameCompletedRegistration", "__Internal")]
		NSString CompletedRegistrationEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameCompletedTutorial;
		[Field ("FBSDKAppEventNameCompletedTutorial", "__Internal")]
		NSString CompletedTutorialEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameInitiatedCheckout;
		[Field ("FBSDKAppEventNameInitiatedCheckout", "__Internal")]
		NSString InitiatedCheckoutEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameRated;
		[Field ("FBSDKAppEventNameRated", "__Internal")]
		NSString RatedEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSearched;
		[Field ("FBSDKAppEventNameSearched", "__Internal")]
		NSString SearchedEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSpentCredits;
		[Field ("FBSDKAppEventNameSpentCredits", "__Internal")]
		NSString SpentCreditsEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameUnlockedAchievement;
		[Field ("FBSDKAppEventNameUnlockedAchievement", "__Internal")]
		NSString UnlockedAchievementEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameViewedContent;
		[Field ("FBSDKAppEventNameViewedContent", "__Internal")]
		NSString ViewedContentEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameContact;
		[Field ("FBSDKAppEventNameContact", "__Internal")]
		NSString NameContactEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameCustomizeProduct;
		[Field ("FBSDKAppEventNameCustomizeProduct", "__Internal")]
		NSString CustomizeProductEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameDonate;
		[Field ("FBSDKAppEventNameDonate", "__Internal")]
		NSString DonateEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameFindLocation;
		[Field ("FBSDKAppEventNameFindLocation", "__Internal")]
		NSString FindLocationEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSchedule;
		[Field ("FBSDKAppEventNameSchedule", "__Internal")]
		NSString ScheduleEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameStartTrial;
		[Field ("FBSDKAppEventNameStartTrial", "__Internal")]
		NSString StartTrialEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSubmitApplication;
		[Field ("FBSDKAppEventNameSubmitApplication", "__Internal")]
		NSString SubmitApplicationEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameSubscribe;
		[Field ("FBSDKAppEventNameSubscribe", "__Internal")]
		NSString NameSubscribeEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAdImpression;
		[Field ("FBSDKAppEventNameAdImpression", "__Internal")]
		NSString AdImpressionEventNameKey { get; }

		// extern NSString *const FBSDKAppEventNameAdClick;
		[Field ("FBSDKAppEventNameAdClick", "__Internal")]
		NSString AdClickEventNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContent;
		[Field ("FBSDKAppEventParameterNameContent", "__Internal")]
		NSString ContentParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContentID;
		[Field ("FBSDKAppEventParameterNameContentID", "__Internal")]
		NSString ContentIdParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameContentType;
		[Field ("FBSDKAppEventParameterNameContentType", "__Internal")]
		NSString ContentTypeParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameCurrency;
		[Field ("FBSDKAppEventParameterNameCurrency", "__Internal")]
		NSString CurrencyParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameDescription;
		[Field ("FBSDKAppEventParameterNameDescription", "__Internal")]
		NSString DescriptionParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameLevel;
		[Field ("FBSDKAppEventParameterNameLevel", "__Internal")]
		NSString LevelParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameMaxRatingValue;
		[Field ("FBSDKAppEventParameterNameMaxRatingValue", "__Internal")]
		NSString MaxRatingValueParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameNumItems;
		[Field ("FBSDKAppEventParameterNameNumItems", "__Internal")]
		NSString NumItemsParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNamePaymentInfoAvailable;
		[Field ("FBSDKAppEventParameterNamePaymentInfoAvailable", "__Internal")]
		NSString PaymentInfoAvailableParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameRegistrationMethod;
		[Field ("FBSDKAppEventParameterNameRegistrationMethod", "__Internal")]
		NSString RegistrationMethodParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameSearchString;
		[Field ("FBSDKAppEventParameterNameSearchString", "__Internal")]
		NSString SearchStringParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameSuccess;
		[Field ("FBSDKAppEventParameterNameSuccess", "__Internal")]
		NSString SuccessParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterValueYes;
		[Field ("FBSDKAppEventParameterValueYes", "__Internal")]
		NSString YesParameterValueKey { get; }

		// extern NSString *const FBSDKAppEventParameterValueNo;
		[Field ("FBSDKAppEventParameterValueNo", "__Internal")]
		NSString NoParameterValueKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameAdType;
		[Field ("FBSDKAppEventParameterNameAdType", "__Internal")]
		NSString AdTypeParameterNameKey { get; }

		// extern NSString *const FBSDKAppEventParameterNameOrderID;
		[Field ("FBSDKAppEventParameterNameOrderID", "__Internal")]
		NSString OrderIdParameterNameKey { get; }

		// +(void)logEvent:(NSString *)eventName;
		[Static]
		[Export ("logEvent:")]
		void LogEvent (string eventName);

		// +(void)logEvent:(NSString *)eventName valueToSum:(double)valueToSum;
		[Static]
		[Export ("logEvent:valueToSum:")]
		void LogEvent (string eventName, double valueToSum);

		// +(void)logEvent:(NSString *)eventName parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logEvent:parameters:")]
		void LogEvent (string eventName, NSDictionary parameters);

		// +(void)logEvent:(NSString *)eventName valueToSum:(double)valueToSum parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logEvent:valueToSum:parameters:")]
		void LogEvent (string eventName, double valueToSum, [NullAllowed] NSDictionary parameters);

		// +(void)logEvent:(NSString *)eventName valueToSum:(NSNumber *)valueToSum parameters:(NSDictionary *)parameters accessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("logEvent:valueToSum:parameters:accessToken:")]
		void LogEvent (string eventName, NSNumber valueToSum, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency;
		[Static]
		[Export ("logPurchase:currency:")]
		void LogPurchase (double purchaseAmount, string currency);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logPurchase:currency:parameters:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary parameters);

		// +(void)logPurchase:(double)purchaseAmount currency:(NSString *)currency parameters:(NSDictionary *)parameters accessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("logPurchase:currency:parameters:accessToken:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		// + (void)logPushNotificationOpen:(NSDictionary *)payload;
		[Static]
		[Export ("logPushNotificationOpen:")]
		void LogPushNotificationOpen (NSDictionary payload);

		// + (void)logPushNotificationOpen:(NSDictionary *)payload action:(NSString *)action;
		[Static]
		[Export ("logPushNotificationOpen:action:")]
		void LogPushNotificationOpen (NSDictionary payload, string action);

		// +(void)logProductItem:(NSString *)itemID availability:(FBSDKProductAvailability)availability condition:(FBSDKProductCondition)condition description:(NSString *)description imageLink:(NSString *)imageLink link:(NSString *)link title:(NSString *)title priceAmount:(double)priceAmount currency:(NSString *)currency gtin:(NSString *)gtin mpn:(NSString *)mpn brand:(NSString *)brand parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("logProductItem:availability:condition:description:imageLink:link:title:priceAmount:currency:gtin:mpn:brand:parameters:")]
		void LogProductItem (string itemId, ProductAvailability availability, ProductCondition condition, string description, string imageLink, string link, string title, double priceAmount, string currency, string gtin, string mpn, string brand, NSDictionary parameters);

		// +(void)activateApp;
		[Static]
		[Export ("activateApp")]
		void ActivateApp ();

		// + (void)setPushNotificationsDeviceToken:(NSData *)deviceToken;
		[Static]
		[Export ("setPushNotificationsDeviceToken:")]
		void SetPushNotificationsDeviceToken (NSData deviceToken);

		// +(FBSDKAppEventsFlushBehavior)flushBehavior;
		// +(void)setFlushBehavior:(FBSDKAppEventsFlushBehavior)flushBehavior;
		[Static]
		[Export ("flushBehavior")]
		AppEventsFlushBehavior FlushBehavior { get; set; }

		// +(NSString *)loggingOverrideAppID;
		// +(void)setLoggingOverrideAppID:(NSString *)appID;
		[Static]
		[Export ("loggingOverrideAppID")]
		string LoggingOverrideAppID { get; set; }

		// +(void)flush;
		[Static]
		[Export ("flush")]
		void Flush ();

		// +(FBSDKGraphRequest *)requestForCustomAudienceThirdPartyIDWithAccessToken:(FBSDKAccessToken *)accessToken;
		[Static]
		[Export ("requestForCustomAudienceThirdPartyIDWithAccessToken:")]
		GraphRequest RequestForCustomAudienceThirdPartyId (AccessToken accessToken);

		// +(void)setUserID:(NSString *)userID;
		// +(NSString *)userID;
		[Static]
		[NullAllowed]
		[Export ("userID")]
		string UserId { get; set; }

		[Obsolete ("Use UserId property instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("UserId")]
		string UserID { get; set; }

		// + (void)clearUserID;
		[Static]
		[Export ("clearUserID")]
		void ClearUserId ();

		// +(void)setUserEmail:(NSString * _Nullable)email firstName:(NSString * _Nullable)firstName lastName:(NSString * _Nullable)lastName phone:(NSString * _Nullable)phone dateOfBirth:(NSString * _Nullable)dateOfBirth gender:(NSString * _Nullable)gender city:(NSString * _Nullable)city state:(NSString * _Nullable)state zip:(NSString * _Nullable)zip country:(NSString * _Nullable)country;
		[Static]
		[Export ("setUserEmail:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:")]
		void SetUserEmail ([NullAllowed] string email, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string phone, [NullAllowed] string dateOfBirth, [NullAllowed] string gender, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string zip, [NullAllowed] string country);

		// +(NSString *)getUserData;
		[Static]
		[NullAllowed]
		[Export ("getUserData")]
		string GetUserData ();

		// +(void)clearUserData;
		[Static]
		[Export ("clearUserData")]
		void ClearUserData ();

		// +(void)updateUserProperties:(NSDictionary *)properties handler:(FBSDKGraphRequestHandler)handler;
		[Static]
		[Export ("updateUserProperties:handler:")]
		void UpdateUserProperties (NSDictionary properties, [NullAllowed]GraphRequestHandler handler);

		// +(void)augmentHybridWKWebView:(WKWebView *)webView;
		[Unavailable (PlatformName.TvOS)]
		[Static]
		[Export ("augmentHybridWKWebView:")]
		void AugmentHybrid (WKWebView webView);

		// +(void)setIsUnityInit:(BOOL)isUnityInit;
		[Static]
		[Export ("setIsUnityInit:")]
		void SetIsUnityInit (bool isUnityInit);

		// +(void)sendEventBindingsToUnity;
		[Static]
		[Export ("sendEventBindingsToUnity")]
		void SendEventBindingsToUnity ();
	}

	// @interface FBSDKApplicationDelegate : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKApplicationDelegate")]
	interface ApplicationDelegate {

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		ApplicationDelegate SharedInstance { get; }

		// -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool OpenUrl ([NullAllowed] UIApplication application, [NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// -(BOOL)application:(UIApplication *)application openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options;
		[Export ("application:openURL:options:")]
		bool OpenUrl (UIApplication application, NSUrl url, NSDictionary options);

		[Obsolete ("This will be removed in future versions, please, use OpenUrl (UIApplication, NSUrl, NSDictionary) overload method instead.")]
		[Wrap ("OpenUrl (application, url, NSDictionary.FromObjectsAndKeys (options.Values, options.Keys, options.Keys.Length))")]
		bool OpenUrl (UIApplication application, NSUrl url, NSDictionary<NSString, NSObject> options);

		// -(BOOL)application:(UIApplication *)application didFinishLaunchingWithOptions:(NSDictionary *)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool FinishedLaunching ([NullAllowed] UIApplication application, [NullAllowed] NSDictionary launchOptions);
	}

	// @interface FBSDKAppLink : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLink")]
	interface AppLink {
		// extern NSString *const _Nonnull FBSDKAppLinkVersion;
		[Field ("FBSDKAppLinkVersion", "__Internal")]
		NSString Version { get; }

		// +(instancetype _Nonnull)appLinkWithSourceURL:(NSURL * _Nonnull)sourceURL targets:(NSArray<FBSDKAppLinkTarget *> * _Nonnull)targets webURL:(NSURL * _Nullable)webURL;
		[Static]
		[Export ("appLinkWithSourceURL:targets:webURL:")]
		AppLink Create (NSUrl sourceUrl, AppLinkTarget [] targets, [NullAllowed] NSUrl webUrl);

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull sourceURL;
		[Export ("sourceURL", ArgumentSemantic.Strong)]
		NSUrl SourceUrl { get; }

		// @property (readonly, copy, nonatomic) NSArray<FBSDKAppLinkTarget *> * _Nonnull targets;
		[Export ("targets", ArgumentSemantic.Copy)]
		AppLinkTarget [] Targets { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nullable webURL;
		[NullAllowed, Export ("webURL", ArgumentSemantic.Strong)]
		NSUrl WebUrl { get; }
	}

	// typedef void (^FBSDKAppLinkNavigationHandler)(FBSDKAppLinkNavigationType, NSError * _Nullable);
	delegate void AppLinkNavigationHandler (AppLinkNavigationType navType, [NullAllowed] NSError error);

	// @interface FBSDKAppLinkNavigation : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkNavigation")]
	interface AppLinkNavigation {
		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull extras;
		[Export ("extras", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Extras { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull appLinkData;
		[Export ("appLinkData", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AppLinkData { get; }

		// @property (readonly, nonatomic, strong) FBSDKAppLink * _Nonnull appLink;
		[Export ("appLink", ArgumentSemantic.Strong)]
		AppLink AppLink { get; }

		// +(instancetype _Nonnull)navigationWithAppLink:(FBSDKAppLink * _Nonnull)appLink extras:(NSDictionary<NSString *,id> * _Nonnull)extras appLinkData:(NSDictionary<NSString *,id> * _Nonnull)appLinkData;
		[Static]
		[Export ("navigationWithAppLink:extras:appLinkData:")]
		AppLinkNavigation Create (AppLink appLink, NSDictionary<NSString, NSObject> extras, NSDictionary<NSString, NSObject> appLinkData);

		// +(NSDictionary<NSString *,NSDictionary<NSString *,NSString *> *> * _Nonnull)callbackAppLinkDataForAppWithName:(NSString * _Nonnull)appName url:(NSString * _Nonnull)url;
		[Static]
		[Export ("callbackAppLinkDataForAppWithName:url:")]
		NSDictionary<NSString, NSDictionary<NSString, NSString>> GetCallbackAppLinkData (string appName, string url);

		// -(FBSDKAppLinkNavigationType)navigate:(NSError * _Nullable * _Nullable)error;
		[Export ("navigate:")]
		AppLinkNavigationType Navigate ([NullAllowed] out NSError error);

		// +(void)resolveAppLink:(NSURL * _Nonnull)destination handler:(FBSDKAppLinkFromURLHandler _Nonnull)handler;
		[Async]
		[Static]
		[Export ("resolveAppLink:handler:")]
		void ResolveAppLink (NSUrl destination, AppLinkFromUrlHandler handler);

		// +(void)resolveAppLink:(NSURL * _Nonnull)destination resolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver handler:(FBSDKAppLinkFromURLHandler _Nonnull)handler;
		[Async]
		[Static]
		[Export ("resolveAppLink:resolver:handler:")]
		void ResolveAppLink (NSUrl destination, IAppLinkResolving resolver, AppLinkFromUrlHandler handler);

		// +(FBSDKAppLinkNavigationType)navigateToAppLink:(FBSDKAppLink * _Nonnull)link error:(NSError * _Nullable * _Nullable)error;
		[Static]
		[Export ("navigateToAppLink:error:")]
		AppLinkNavigationType Navigate (AppLink link, [NullAllowed] out NSError error);

		// +(FBSDKAppLinkNavigationType)navigationTypeForLink:(FBSDKAppLink * _Nonnull)link;
		[Static]
		[Export ("navigationTypeForLink:")]
		AppLinkNavigationType GetNavigationType (AppLink link);

		// -(FBSDKAppLinkNavigationType)navigationType;
		[Export ("navigationType")]
		AppLinkNavigationType GetNavigationType ();

		// +(void)navigateToURL:(NSURL * _Nonnull)destination handler:(FBSDKAppLinkNavigationHandler _Nonnull)handler;
		[Async]
		[Static]
		[Export ("navigateToURL:handler:")]
		void Navigate (NSUrl destination, AppLinkNavigationHandler handler);

		// +(void)navigateToURL:(NSURL * _Nonnull)destination resolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver handler:(FBSDKAppLinkNavigationHandler _Nonnull)handler;
		[Async]
		[Static]
		[Export ("navigateToURL:resolver:handler:")]
		void Navigate (NSUrl destination, IAppLinkResolving resolver, AppLinkNavigationHandler handler);

		// +(id<FBSDKAppLinkResolving> _Nonnull)defaultResolver;
		// +(void)setDefaultResolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver;
		[Static]
		[Export ("defaultResolver")]
		IAppLinkResolving DefaultResolver { get; set; }
	}

	// @interface FBSDKAppLinkResolver : NSObject<BFAppLinkResolving>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkResolver")]
	interface AppLinkResolver : AppLinkResolving, BFAppLinkResolving {

		// - (BFTask *)appLinksFromURLsInBackground:(NSArray *)urls;
		[Obsolete ("Use GetAppLinks method instead.")]
		[Export ("appLinksFromURLsInBackground:")]
		Task AppLinksInBackground (NSUrl [] urls);

		// -(void)appLinksFromURLs:(NSArray<NSURL *> *)urls handler:(FBSDKAppLinksFromURLArrayHandler)handler __attribute__((availability(ios_app_extension, unavailable)));
		[Async]
		[Export ("appLinksFromURLs:handler:")]
		void GetAppLinks (NSUrl [] urls, AppLinksFromUrlArrayHandler handler);

		// + (instancetype)resolver;
		[Static]
		[Export ("resolver")]
		AppLinkResolver Resolver { get; }
	}

	// typedef void (^FBSDKAppLinkFromURLHandler)(FBSDKAppLink * _Nullable, NSError * _Nullable);
	delegate void AppLinkFromUrlHandler ([NullAllowed] AppLink appLink, [NullAllowed] NSError error);

	// typedef void (^FBSDKAppLinksFromURLArrayHandler)(NSDictionary<NSURL *,FBSDKAppLink *> * _Nonnull, NSError * _Nullable);
	delegate void AppLinksFromUrlArrayHandler (NSDictionary<NSUrl, NSObject> appLinks, [NullAllowed] NSError error);

	interface IAppLinkResolving { }

	// @protocol FBSDKAppLinkResolving <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkResolving")]
	interface AppLinkResolving {
		// @required -(void)appLinkFromURL:(NSURL * _Nonnull)url handler:(FBSDKAppLinkFromURLHandler _Nonnull)handler __attribute__((availability(ios_app_extension, unavailable)));
		[Abstract]
		[Export ("appLinkFromURL:handler:")]
		void Handler (NSUrl url, AppLinkFromUrlHandler handler);
	}

	interface IAppLinkReturnToRefererControllerDelegate { }

	// @protocol FBSDKAppLinkReturnToRefererControllerDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkReturnToRefererControllerDelegate")]
	interface AppLinkReturnToRefererControllerDelegate {		// @optional -(void)returnToRefererController:(FBSDKAppLinkReturnToRefererController * _Nonnull)controller willNavigateToAppLink:(FBSDKAppLink * _Nonnull)appLink;
		[EventArgs ("AppLinkReturnToRefererControllerWillNavigateToAppLink")]
		[Export ("returnToRefererController:willNavigateToAppLink:")]
		void WillNavigateToAppLink (AppLinkReturnToRefererController controller, AppLink appLink);

		// @optional -(void)returnToRefererController:(FBSDKAppLinkReturnToRefererController * _Nonnull)controller didNavigateToAppLink:(FBSDKAppLink * _Nonnull)url type:(FBSDKAppLinkNavigationType)type;
		[EventArgs ("AppLinkReturnToRefererControllerNavigatedToAppLink")]
		[EventName ("NavigatedToAppLink")]
		[Export ("returnToRefererController:didNavigateToAppLink:type:")]
		void DidNavigateToAppLink (AppLinkReturnToRefererController controller, AppLink url, AppLinkNavigationType type);
	}

	// @interface FBSDKAppLinkReturnToRefererController : NSObject <FBSDKAppLinkReturnToRefererViewDelegate>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject),
		   Name = "FBSDKAppLinkReturnToRefererController",
		   Delegates = new [] { "Delegate" },
	           Events = new [] { typeof (AppLinkReturnToRefererControllerDelegate) })]
	interface AppLinkReturnToRefererController : AppLinkReturnToRefererViewDelegate {
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAppLinkReturnToRefererControllerDelegate Delegate { get; set; }

		// @property (nonatomic, strong) FBSDKAppLinkReturnToRefererView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		AppLinkReturnToRefererView View { get; set; }

		// -(instancetype _Nonnull)initForDisplayAboveNavController:(UINavigationController * _Nonnull)navController;
		[DesignatedInitializer]
		[Export ("init")]
		IntPtr Constructor ();

		// -(instancetype _Nonnull)initForDisplayAboveNavController:(UINavigationController * _Nonnull)navController;
		[Export ("initForDisplayAboveNavController:")]
		IntPtr Constructor (UINavigationController navController);

		// -(void)removeFromNavController;
		[Export ("removeFromNavController")]
		void RemoveFromNavController ();

		// -(void)showViewForRefererAppLink:(FBSDKAppLink * _Nonnull)refererAppLink;
		[Export ("showViewForRefererAppLink:")]
		void ShowView (AppLink refererAppLink);

		// -(void)showViewForRefererURL:(NSURL * _Nonnull)url;
		[Export ("showViewForRefererURL:")]
		void ShowView (NSUrl url);

		// -(void)closeViewAnimated:(BOOL)animated;
		[Export ("closeViewAnimated:")]
		void CloseView (bool animated);
	}

	interface IAppLinkReturnToRefererViewDelegate { }

	// @protocol FBSDKAppLinkReturnToRefererViewDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkReturnToRefererViewDelegate")]
	interface AppLinkReturnToRefererViewDelegate {
		// @required -(void)returnToRefererViewDidTapInsideCloseButton:(FBSDKAppLinkReturnToRefererView * _Nonnull)view;
		[Abstract]
		[EventArgs ("AppLinkReturnToRefererViewInsideCloseButtonTapped")]
		[EventName ("InsideCloseButtonTapped")]
		[Export ("returnToRefererViewDidTapInsideCloseButton:")]
		void DidTapInsideCloseButton (AppLinkReturnToRefererView view);

		// @required -(void)returnToRefererViewDidTapInsideLink:(FBSDKAppLinkReturnToRefererView * _Nonnull)view link:(FBSDKAppLink * _Nonnull)link;
		[Abstract]
		[EventArgs ("AppLinkReturnToRefererViewInsideLinkTapped")]
		[EventName ("InsideLinkTapped")]
		[Export ("returnToRefererViewDidTapInsideLink:link:")]
		void DidTapInsideLink (AppLinkReturnToRefererView view, AppLink link);
	}

	// @interface FBSDKAppLinkReturnToRefererView : UIView
	[BaseType (typeof (UIView), Name = "FBSDKAppLinkReturnToRefererView")]
	interface AppLinkReturnToRefererView {
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAppLinkReturnToRefererViewDelegate Delegate { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull textColor;
		[Export ("textColor", ArgumentSemantic.Strong)]
		UIColor TextColor { get; set; }

		// @property (nonatomic, strong) FBSDKAppLink * _Nonnull refererAppLink;
		[Export ("refererAppLink", ArgumentSemantic.Strong)]
		AppLink RefererAppLink { get; set; }

		// @property (assign, nonatomic) FBSDKIncludeStatusBarInSize includeStatusBarInSize;
		[Export ("includeStatusBarInSize", ArgumentSemantic.Assign)]
		IncludeStatusBarInSize IncludeStatusBarInSize { get; set; }

		// @property (assign, nonatomic) BOOL closed;
		[Export ("closed")]
		bool Closed { get; set; }
	}

	// @interface FBSDKAppLinkTarget : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkTarget")]
	interface AppLinkTarget {
		// +(instancetype _Nonnull)appLinkTargetWithURL:(NSURL * _Nonnull)url appStoreId:(NSString * _Nullable)appStoreId appName:(NSString * _Nonnull)appName;
		[Static]
		[Export ("appLinkTargetWithURL:appStoreId:appName:")]
		AppLinkTarget Create (NSUrl url, [NullAllowed] string appStoreId, string appName);

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull URL;
		[Export ("URL", ArgumentSemantic.Strong)]
		NSUrl URL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable appStoreId;
		[NullAllowed, Export ("appStoreId")]
		string AppStoreId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appName;
		[Export ("appName")]
		string AppName { get; }
	}

	// typedef void (^FBSDKDeferredAppLinkHandler)(NSURL *, NSError *);
	delegate void DeferredAppLinkHandler (NSUrl url, NSError error);
	// typedef void (^FBSDKDeferredAppInviteHandler)(NSURL *url);
	delegate void DeferredAppInviteHandler (NSUrl url);

	// @interface FBSDKAppLinkUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkUtility")]
	interface AppLinkUtility {

		// +(void)fetchDeferredAppLink:(FBSDKDeferredAppLinkHandler)handler;
		[Static]
		[Async]
		[Export ("fetchDeferredAppLink:")]
		void FetchDeferredAppLink (DeferredAppLinkHandler handler);

		// + (BOOL)fetchDeferredAppInvite:(FBSDKDeferredAppInviteHandler)handler;
		[Static]
		[Export ("fetchDeferredAppInvite:")]
		[Obsolete ("This method is no longer available and will always return NO.")]
		bool FetchDeferredAppInvite (DeferredAppInviteHandler handler);

		// + (NSString*)appInvitePromotionCodeFromURL:(NSURL*)url;
		[Static]
		[Export ("appInvitePromotionCodeFromURL:")]
		string AppInvitePromotionCode (NSUrl url);
	}

	// @interface FBSDKButton : UIButton
	[BaseType (typeof (UIButton), Name = "FBSDKButton")]
	interface Button {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);
	}

	[Static]
	interface Errors {
		// extern NSString *const FBSDKErrorDomain;
		[Field ("FBSDKErrorDomain", "__Internal")]
		NSString DomainKey { get; }

		// extern NSString *const FBSDKErrorArgumentCollectionKey;
		[Field ("FBSDKErrorArgumentCollectionKey", "__Internal")]
		NSString ArgumentCollectionKey { get; }

		// extern NSString *const FBSDKErrorArgumentNameKey;
		[Field ("FBSDKErrorArgumentNameKey", "__Internal")]
		NSString ArgumentNameKey { get; }

		// extern NSString *const FBSDKErrorArgumentValueKey;
		[Field ("FBSDKErrorArgumentValueKey", "__Internal")]
		NSString ArgumentValueKey { get; }

		// extern NSString *const FBSDKErrorDeveloperMessageKey;
		[Field ("FBSDKErrorDeveloperMessageKey", "__Internal")]
		NSString DeveloperMessageKey { get; }

		// extern NSString *const FBSDKErrorLocalizedDescriptionKey;
		[Field ("FBSDKErrorLocalizedDescriptionKey", "__Internal")]
		NSString LocalizedDescriptionKey { get; }

		// extern NSString *const FBSDKErrorLocalizedTitleKey;
		[Field ("FBSDKErrorLocalizedTitleKey", "__Internal")]
		NSString LocalizedTitleKey { get; }

		// extern NSString *const FBSDKGraphRequestErrorCategoryKey;
		[Obsolete ("Use GraphRequestErrors.ErrorKey static property instead.")]
		[Field ("FBSDKGraphRequestErrorCategoryKey", "__Internal")]
		NSString CategoryKey { get; }

		// extern NSString *const FBSDKGraphRequestErrorGraphErrorCode;
		[Obsolete ("Use GraphRequestErrors.GraphErrorCodeKey static property instead.")]
		[Field ("FBSDKGraphRequestErrorGraphErrorCode", "__Internal")]
		NSString GraphErrorCode { get; }

		// extern NSString *const FBSDKGraphRequestErrorGraphErrorSubcode;
		[Obsolete ("Use GraphRequestErrors.GraphErrorSubcodeKey static property instead.")]
		[Field ("FBSDKGraphRequestErrorGraphErrorSubcode", "__Internal")]
		NSString GraphErrorSubcode { get; }
	}

	[Static]
	interface GraphRequestErrors {
		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorKey;
		[Field ("FBSDKGraphRequestErrorKey", "__Internal")]
		NSString ErrorKey { get; }

		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorGraphErrorCodeKey;
		[Field ("FBSDKGraphRequestErrorGraphErrorCodeKey", "__Internal")]
		NSString GraphErrorCodeKey { get; }

		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorGraphErrorSubcodeKey;
		[Field ("FBSDKGraphRequestErrorGraphErrorSubcodeKey", "__Internal")]
		NSString GraphErrorSubcodeKey { get; }

		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorHTTPStatusCodeKey;
		[Field ("FBSDKGraphRequestErrorHTTPStatusCodeKey", "__Internal")]
		NSString HttpStatusCodeKey { get; }

		// extern const NSErrorUserInfoKey FBSDKGraphRequestErrorParsedJSONResponseKey;
		[Field ("FBSDKGraphRequestErrorParsedJSONResponseKey", "__Internal")]
		NSString ParsedJsonResponseKey { get; }
	}

	interface IErrorRecoveryAttempting { }

	// @protocol FBSDKErrorRecoveryAttempting <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKErrorRecoveryAttempting")]
	interface ErrorRecoveryAttempting {
		// @required -(void)attemptRecoveryFromError:(NSError *)error optionIndex:(NSUInteger)recoveryOptionIndex delegate:(id)delegate didRecoverSelector:(SEL)didRecoverSelector contextInfo:(void *)contextInfo;
		[Abstract]
		[Export ("attemptRecoveryFromError:optionIndex:delegate:didRecoverSelector:contextInfo:")]
		void AttemptRecovery (NSError error, nuint recoveryOptionIndex, NSObject aDelegate, Selector didRecoverSelector, IntPtr contextInfo);
	}

	interface ICopying { }

	// @protocol FBSDKCopying <NSCopying, NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKCopying")]
	interface Copying : INSCopying {
		// @required -(id)copy;
		[New]
		[Abstract]
		[Export ("copy")]
		NSObject Copy ();
	}

	interface IGraphErrorRecoveryProcessorDelegate { }

	// @protocol FBSDKGraphErrorRecoveryProcessorDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessorDelegate")]
	interface GraphErrorRecoveryProcessorDelegate {

		// @required -(void)processorDidAttemptRecovery:(FBSDKGraphErrorRecoveryProcessor *)processor didRecover:(BOOL)didRecover error:(NSError *)error;
		[Abstract]
		[Export ("processorDidAttemptRecovery:didRecover:error:")]
		void DidAttemptRecovery (GraphErrorRecoveryProcessor processor, bool didRecover, NSError error);

		// @optional -(BOOL)processorWillProcessError:(FBSDKGraphErrorRecoveryProcessor *)processor error:(NSError *)error;
		[Export ("processorWillProcessError:error:")]
		bool WillProcessError (GraphErrorRecoveryProcessor processor, NSError error);
	}

	// @interface FBSDKGraphErrorRecoveryProcessor : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessor")]
	interface GraphErrorRecoveryProcessor {

		// @property (readonly, nonatomic, strong) id<FBSDKGraphErrorRecoveryProcessorDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.Strong)]
		IGraphErrorRecoveryProcessorDelegate Delegate { get; }

		// -(BOOL)processError:(NSError *)error request:(FBSDKGraphRequest *)request delegate:(id<FBSDKGraphErrorRecoveryProcessorDelegate>)delegate;
		[Export ("processError:request:delegate:")]
		bool ProcessError (NSError error, GraphRequest request, [NullAllowed] IGraphErrorRecoveryProcessorDelegate aDelegate);

		// -(void)didPresentErrorWithRecovery:(BOOL)didRecover contextInfo:(void *)contextInfo;
		[Export ("didPresentErrorWithRecovery:contextInfo:")]
		unsafe void ErrorPresentedWithRecovery (bool didRecover, [NullAllowed] NSObject contextInfo);
	}

	// @interface FBSDKGraphRequest : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequest")]
	interface GraphRequest {

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters;
		[Export ("initWithGraphPath:parameters:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters HTTPMethod:(NSString *)HTTPMethod;
		[Export ("initWithGraphPath:parameters:HTTPMethod:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string httpMethod);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters tokenString:(NSString *)tokenString version:(NSString *)version HTTPMethod:(NSString *)HTTPMethod __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
		IntPtr Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, [NullAllowed] string httpMethod);

		// @property (readonly, nonatomic, strong) NSMutableDictionary * parameters;
		[Export ("parameters", ArgumentSemantic.Strong)]
		NSMutableDictionary Parameters { get; }

		// @property (readonly, copy, nonatomic) NSString * tokenString;
		[Export ("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * graphPath;
		[Export ("graphPath", ArgumentSemantic.Copy)]
		string GraphPath { get; }

		// @property (readonly, copy, nonatomic) NSString * HTTPMethod;
		[Export ("HTTPMethod", ArgumentSemantic.Copy)]
		string HttpMethod { get; }

		[Obsolete ("Use HttpMethod property instead. This will be removed in future versions.")]
		[Wrap ("HttpMethod")]
		string HTTPMethod { get; }

		// @property (readonly, copy, nonatomic) NSString * version;
		[Export ("version", ArgumentSemantic.Copy)]
		string Version { get; }

		// -(void)setGraphErrorRecoveryDisabled:(BOOL)disable;
		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disable);

		// -(FBSDKGraphRequestConnection *)startWithCompletionHandler:(FBSDKGraphRequestHandler)handler;
		[Export ("startWithCompletionHandler:")]
		GraphRequestConnection Start (GraphRequestHandler handler);
	}

	// typedef void (^FBSDKGraphRequestHandler)(FBSDKGraphRequestConnection *id, NSError *);
	delegate void GraphRequestHandler (GraphRequestConnection connection, NSObject result, NSError error);

	interface IGraphRequestConnectionDelegate {

	}

	// @protocol FBSDKGraphRequestConnectionDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestConnectionDelegate")]
	interface GraphRequestConnectionDelegate {

		// @optional -(void)requestConnectionWillBeginLoading:(FBSDKGraphRequestConnection *)connection;
		[EventArgs ("GraphRequestConnectionWillBeginLoading")]
		[Export ("requestConnectionWillBeginLoading:")]
		void WillBeginLoading (GraphRequestConnection connection);

		// @optional -(void)requestConnectionDidFinishLoading:(FBSDKGraphRequestConnection *)connection;
		[EventArgs ("GraphRequestConnectionLoadingFinished")]
		[EventName ("LoadingFinished")]
		[Export ("requestConnectionDidFinishLoading:")]
		void DidFinishLoading (GraphRequestConnection connection);

		// @optional -(void)requestConnection:(FBSDKGraphRequestConnection *)connection didFailWithError:(NSError *)error;
		[EventArgs ("GraphRequestConnectionFailed")]
		[EventName ("Failed")]
		[Export ("requestConnection:didFailWithError:")]
		void DidFail (GraphRequestConnection connection, NSError error);

		// @optional -(void)requestConnection:(FBSDKGraphRequestConnection *)connection didSendBodyData:(NSInteger)bytesWritten totalBytesWritten:(NSInteger)totalBytesWritten totalBytesExpectedToWrite:(NSInteger)totalBytesExpectedToWrite;
		[EventArgs ("GraphRequestConnectionBodyDataSent")]
		[EventName ("BodyDataSent")]
		[Export ("requestConnection:didSendBodyData:totalBytesWritten:totalBytesExpectedToWrite:")]
		void DidSendBodyData (GraphRequestConnection connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);
	}

	// @interface FBSDKGraphRequestConnection : NSObject
	[BaseType (typeof (NSObject),
		Name = "FBSDKGraphRequestConnection",
		Delegates = new [] { "Delegate" },
		Events = new [] { typeof (GraphRequestConnectionDelegate) })]
	interface GraphRequestConnection {

		// extern NSString *const FBSDKNonJSONResponseProperty;
		[Field ("FBSDKNonJSONResponseProperty", "__Internal")]
		NSString NonJsonResponsePropertyKey { get; }

		// @property (assign, nonatomic) id<FBSDKGraphRequestConnectionDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGraphRequestConnectionDelegate Delegate { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timeout;
		[Export ("timeout", ArgumentSemantic.Assign)]
		double Timeout { get; set; }

		// @property (readonly, retain, nonatomic) NSHTTPURLResponse * URLResponse;
		[Export ("URLResponse", ArgumentSemantic.Retain)]
		NSHttpUrlResponse UrlResponse { get; }

		// + (void)setDefaultConnectionTimeout:(NSTimeInterval)defaultConnectionTimeout;
		[Static]
		[Export ("setDefaultConnectionTimeout:")]
		void SetDefaultConnectionTimeout (double defaultConnectionTimeout);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler;
		[Export ("addRequest:completionHandler:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler batchEntryName:(NSString *)name;
		[Export ("addRequest:completionHandler:batchEntryName:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler, string name);

		// -(void)addRequest:(FBSDKGraphRequest *)request completionHandler:(FBSDKGraphRequestHandler)handler batchParameters:(NSDictionary *)batchParameters;
		[Export ("addRequest:completionHandler:batchParameters:")]
		void AddRequest (GraphRequest request, [NullAllowed] GraphRequestHandler handler, [NullAllowed] NSDictionary batchParameters);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)setDelegateQueue:(NSOperationQueue *)queue;
		[Export ("setDelegateQueue:")]
		void SetDelegateQueue (NSOperationQueue queue);

		// -(void)overrideVersionPartWith:(NSString *)version;
		[Export ("overrideVersionPartWith:")]
		void OverrideVersionPart (string version);
	}

	// @interface FBSDKGraphRequestDataAttachment : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestDataAttachment")]
	interface GraphRequestDataAttachment {
		// -(instancetype)initWithData:(NSData *)data filename:(NSString *)filename contentType:(NSString *)contentType __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithData:filename:contentType:")]
		IntPtr Constructor ([NullAllowed] NSData data, string filename, string contentType);

		// @property (readonly, copy, nonatomic) NSString * contentType;
		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; }

		// @property (readonly, nonatomic, strong) NSData * data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; }

		// @property (readonly, copy, nonatomic) NSString * filename;
		[Export ("filename", ArgumentSemantic.Copy)]
		string Filename { get; }
	}

	interface MeasurementEventArgs {
		[Export ("FBSDKMeasurementEventNameKey")]
		string EventName { get; }

		[Export ("FBSDKMeasurementEventArgsKey")]
		NSDictionary EventArgs { get; }
	}

	// @interface FBSDKMeasurementEvent : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKMeasurementEvent")]
	interface MeasurementEvent {
		// extern const NSNotificationName _Nonnull FBSDKMeasurementEventNotification;
		[Notification (typeof (MeasurementEventArgs))]
		[Field ("FBSDKMeasurementEventNotification", "__Internal")]
		NSString EventNotification { get; }

		// extern NSString *const _Nonnull FBSDKMeasurementEventNameKey;
		[Field ("FBSDKMeasurementEventNameKey", "__Internal")]
		NSString EventNameKey { get; }

		// extern NSString *const _Nonnull FBSDKMeasurementEventArgsKey;
		[Field ("FBSDKMeasurementEventArgsKey", "__Internal")]
		NSString EventArgsKey { get; }

		// extern NSString *const _Nonnull FBSDKAppLinkParseEventName;
		[Notification]
		[Field ("FBSDKAppLinkParseEventName", "__Internal")]
		NSString AppLinkParseEventName { get; }

		// extern NSString *const _Nonnull FBSDKAppLinkNavigateInEventName;
		[Notification]
		[Field ("FBSDKAppLinkNavigateInEventName", "__Internal")]
		NSString AppLinkNavigateInEventName { get; }

		// extern NSString *const _Nonnull FBSDKAppLinkNavigateOutEventName;
		[Notification]
		[Field ("FBSDKAppLinkNavigateOutEventName", "__Internal")]
		NSString AppLinkNavigateOutEventName { get; }

		// extern NSString *const _Nonnull FBSDKAppLinkNavigateBackToReferrerEventName;
		[Notification]
		[Field ("FBSDKAppLinkNavigateBackToReferrerEventName", "__Internal")]
		NSString AppLinkNavigateBackToReferrerEventName { get; }
	}

	interface IMutableCopying { }

	// @protocol FBSDKMutableCopying <FBSDKCopying, NSMutableCopying>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKMutableCopying")]
	interface MutableCopying : Copying, INSMutableCopying {

		// @required -(id)mutableCopy;
		[New]
		[Abstract]
		[Export ("mutableCopy")]
		NSObject MutableCopy ();
	}

	interface ProfileDidChangeEventArgs {
		[Export ("FBSDKProfileChangeOldKey")]
		Profile OldProfile { get; }

		[Export ("FBSDKProfileChangeNewKey")]
		Profile NewProfile { get; }
	}

	// void(^)(FBSDKProfile *profile, NSError *error))completion
	delegate void ProfileLoadCurrentProfileHandler (Profile profile, NSError error);

	// @interface FBSDKProfile : NSObject <NSCopying, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKProfile")]
	interface Profile : INSCopying, INSSecureCoding {

		// extern NSString *const FBSDKProfileDidChangeNotification;
		[Notification (typeof (ProfileDidChangeEventArgs))]
		[Field ("FBSDKProfileDidChangeNotification", "__Internal")]
		NSString DidChangeNotification { get; }

		[Field ("FBSDKProfileChangeOldKey", "__Internal")]
		NSString OldProfileKey { get; }

		[Field ("FBSDKProfileChangeNewKey", "__Internal")]
		NSString NewProfileKey { get; }

		// -(instancetype)initWithUserID:(NSString *)userID firstName:(NSString *)firstName middleName:(NSString *)middleName lastName:(NSString *)lastName name:(NSString *)name linkURL:(NSURL *)linkURL refreshDate:(NSDate *)refreshDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:")]
		IntPtr Constructor (string userID, string firstName, string middleName, string lastName, string name, [NullAllowed] NSUrl linkUrl, [NullAllowed] NSDate refreshDate);

		// @property (readonly, nonatomic) NSString * userID;
		[Export ("userID")]
		string UserId { get; }

		[Obsolete ("Use UserId property instead. This will be removed in future versions.")]
		[Wrap ("UserId")]
		string UserID { get; }

		// @property (readonly, nonatomic) NSString * firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * middleName;
		[Export ("middleName")]
		string MiddleName { get; }

		// @property (readonly, nonatomic) NSString * lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSURL * linkURL;
		[Export ("linkURL")]
		NSUrl LinkUrl { get; }

		// @property (readonly, nonatomic) NSDate * refreshDate;
		[Export ("refreshDate")]
		NSDate RefreshDate { get; }

		// +(FBSDKProfile *)currentProfile;
		// +(void)setCurrentProfile:(FBSDKProfile *)profile;
		[Static]
		[Export ("currentProfile")]
		Profile CurrentProfile { get; set; }

		// +(void)enableUpdatesOnAccessTokenChange:(BOOL)enable;
		[Static]
		[Export ("enableUpdatesOnAccessTokenChange:")]
		void EnableUpdatesOnAccessTokenChange (bool enable);

		// + (void)loadCurrentProfileWithCompletion:(void(^)(FBSDKProfile *profile, NSError *error))completion;
		[Static]
		[Export ("loadCurrentProfileWithCompletion:")]
		void LoadCurrentProfile (ProfileLoadCurrentProfileHandler completion);

		// - (NSURL *)imageURLForPictureMode:(FBSDKProfilePictureMode)mode size:(CGSize)size;
		[Export ("imageURLForPictureMode:size:")]
		NSUrl ImageUrl (ProfilePictureMode mode, CGSize size);

		// -(NSString *)imagePathForPictureMode:(FBSDKProfilePictureMode)mode size:(CGSize)size;
		[Obsolete ("Use ImageUrl method instead")]
		[Export ("imagePathForPictureMode:size:")]
		string ImagePath (ProfilePictureMode mode, CGSize size);

		// -(BOOL)isEqualToProfile:(FBSDKProfile *)profile;
		[Export ("isEqualToProfile:")]
		bool Equals (Profile profile);

		[Obsolete ("Use Equals (Profile) overload method instead. This will be removed in future version.")]
		[Wrap ("Equals (profile)")]
		bool IsEqualToProfile (Profile profile);
	}

	// @interface FBSDKProfilePictureView : UIView
	[BaseType (typeof (UIView), Name = "FBSDKProfilePictureView")]
	interface ProfilePictureView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (assign, nonatomic) FBSDKProfilePictureMode pictureMode;
		[Export ("pictureMode", ArgumentSemantic.Assign)]
		ProfilePictureMode PictureMode { get; set; }

		// @property (copy, nonatomic) NSString * profileID;
		[Export ("profileID", ArgumentSemantic.Copy)]
		string ProfileId { get; set; }

		// -(void)setNeedsImageUpdate;
		[Export ("setNeedsImageUpdate")]
		void SetNeedsImageUpdate ();
	}

	[Static]
	interface LoggingBehavior {

		// extern NSString *const FBSDKLoggingBehaviorAccessTokens;
		[Field ("FBSDKLoggingBehaviorAccessTokens", "__Internal")]
		NSString AccessTokensKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorPerformanceCharacteristics;
		[Field ("FBSDKLoggingBehaviorPerformanceCharacteristics", "__Internal")]
		NSString PerformanceCharacteristicsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorAppEvents;
		[Field ("FBSDKLoggingBehaviorAppEvents", "__Internal")]
		NSString AppEventsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorInformational;
		[Field ("FBSDKLoggingBehaviorInformational", "__Internal")]
		NSString InformationalKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorCacheErrors;
		[Field ("FBSDKLoggingBehaviorCacheErrors", "__Internal")]
		NSString CacheErrorsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorUIControlErrors;
		[Field ("FBSDKLoggingBehaviorUIControlErrors", "__Internal")]
		NSString UIControlErrorsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorGraphAPIDebugWarning;
		[Field ("FBSDKLoggingBehaviorGraphAPIDebugWarning", "__Internal")]
		NSString GraphAPIDebugWarningKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorGraphAPIDebugInfo;
		[Field ("FBSDKLoggingBehaviorGraphAPIDebugInfo", "__Internal")]
		NSString GraphAPIDebugInfoKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorNetworkRequests;
		[Field ("FBSDKLoggingBehaviorNetworkRequests", "__Internal")]
		NSString NetworkRequestsKey { get; }

		// extern NSString *const FBSDKLoggingBehaviorDeveloperErrors;
		[Field ("FBSDKLoggingBehaviorDeveloperErrors", "__Internal")]
		NSString DeveloperErrorsKey { get; }
	}

	// @interface FBSDKSettings : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKSettings")]
	interface Settings {

		// +(NSString *)appID;
		// +(void)setAppID:(NSString *)appID;
		[Static]
		[Export ("appID")]
		string AppId { get; set; }

		[Obsolete ("Use AppId property instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("AppId")]
		string AppID { get; set; }

		// +(NSString *)appURLSchemeSuffix;
		// +(void)setAppURLSchemeSuffix:(NSString *)appURLSchemeSuffix;
		[Static]
		[Export ("appURLSchemeSuffix")]
		string AppUrlSchemeSuffix { get; set; }

		// +(NSString *)clientToken;
		// +(void)setClientToken:(NSString *)clientToken;
		[Static]
		[Export ("clientToken")]
		string ClientToken { get; set; }

		// +(void)setGraphErrorRecoveryDisabled:(BOOL)disableGraphErrorRecovery;
		[Static]
		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disableGraphErrorRecovery);

		// +(NSString *)displayName;
		// +(void)setDisplayName:(NSString *)displayName;
		[Static]
		[Export ("displayName")]
		string DisplayName { get; set; }

		// +(NSString *)facebookDomainPart;
		// +(void)setFacebookDomainPart:(NSString *)facebookDomainPart;
		[Static]
		[Export ("facebookDomainPart")]
		string FacebookDomainPart { get; set; }

		// +(CGFloat)JPEGCompressionQuality;
		// +(void)setJPEGCompressionQuality:(CGFloat)JPEGCompressionQuality;
		[Static]
		[Export ("JPEGCompressionQuality")]
		nfloat JpegCompressionQuality { get; set; }

		// + (NSNumber *)autoLogAppEventsEnabled;
		// + (void)setAutoLogAppEventsEnabled:(NSNumber*)AutoLogAppEventsEnabled;
		[Internal]
		[Static]
		[Export ("autoLogAppEventsEnabled")]
		NSNumber _AutoLogAppEventsEnabled { get; set; }

		// + (NSNumber*) codelessDebugLogEnabled;
		// + (void)setCodelessDebugLogEnabled:(NSNumber *)CodelessDebugLogEnabled;
		[Internal]
		[Static]
		[Export ("codelessDebugLogEnabled")]
		NSNumber _CodelessDebugLogEnabled { get; set; }

		// +(BOOL)limitEventAndDataUsage;
		// +(void)setLimitEventAndDataUsage:(BOOL)limitEventAndDataUsage;
		[Static]
		[Export ("limitEventAndDataUsage")]
		bool LimitEventAndDataUsage { get; set; }

		// +(NSString *)sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// +(NSSet *)loggingBehavior;
		// +(void)setLoggingBehavior:(NSSet *)loggingBehavior;
		[Static]
		[Export ("loggingBehavior")]
		NSSet LoggingBehavior { get; set; }

		// +(void)enableLoggingBehavior:(NSString *)loggingBehavior;
		[Static]
		[Export ("enableLoggingBehavior:")]
		void EnableLoggingBehavior (string loggingBehavior);

		// +(void)disableLoggingBehavior:(NSString *)loggingBehavior;
		[Static]
		[Export ("disableLoggingBehavior:")]
		void DisableLoggingBehavior (string loggingBehavior);

		// +(NSString *)legacyUserDefaultTokenInformationKeyName;
		// +(void)setLegacyUserDefaultTokenInformationKeyName:(NSString *)tokenInformationKeyName;
		[Static]
		[Export ("legacyUserDefaultTokenInformationKeyName")]
		string LegacyUserDefaultTokenInformationKeyName { get; set; }

		// +(void)setGraphAPIVersion:(NSString *)version;
		// +(NSString *)graphAPIVersion;
		[Static]
		[Export ("graphAPIVersion")]
		string GraphApiVersion { get; set; }

		[Obsolete ("Use GraphApiVersion property instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("GraphApiVersion")]
		string GraphAPIVersion { get; set; }
	}

	delegate void TestUsersManagerRetrieveTestAccountTokensHandler (AccessToken [] tokens, NSError error);
	delegate void TestUsersManagerRemoveTestAccountHandler (NSError error);

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKTestUsersManager")]
	interface TestUsersManager {

		// +(instancetype)sharedInstanceForAppID:(NSString *)appID appSecret:(NSString *)appSecret;
		[Static]
		[Export ("sharedInstanceForAppID:appSecret:")]
		TestUsersManager SharedInstance (string appID, string appSecret);

		// -(void)requestTestAccountTokensWithArraysOfPermissions:(NSArray *)arraysOfPermissions createIfNotFound:(BOOL)createIfNotFound completionHandler:(FBSDKTestUsersManagerRetrieveTestAccountTokensHandler)handler;
		[Export ("requestTestAccountTokensWithArraysOfPermissions:createIfNotFound:completionHandler:")]
		void RequestTestAccount (string [] arraysOfPermissions, bool createIfNotFound, TestUsersManagerRetrieveTestAccountTokensHandler handler);

		// -(void)addTestAccountWithPermissions:(NSSet *)permissions completionHandler:(FBSDKTestUsersManagerRetrieveTestAccountTokensHandler)handler;
		[Export ("addTestAccountWithPermissions:completionHandler:")]
		void AddTestAccount (NSSet permissions, TestUsersManagerRetrieveTestAccountTokensHandler handler);

		// -(void)removeTestAccount:(NSString *)userId completionHandler:(FBSDKTestUsersManagerRemoveTestAccountHandler)handler;
		[Export ("removeTestAccount:completionHandler:")]
		void RemoveTestAccount (string userId, TestUsersManagerRemoveTestAccountHandler handler);

		// -(void)makeFriendsWithFirst:(FBSDKAccessToken *)first second:(FBSDKAccessToken *)second callback:(void (^)(NSError *))callback;
		[Export ("makeFriendsWithFirst:second:callback:")]
		void MakeFriends (AccessToken first, AccessToken second, TestUsersManagerRemoveTestAccountHandler callback);
	}

	// @interface FBSDKURL : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKURL")]
	interface Url {
		// +(FBSDKURL * _Nonnull)URLWithURL:(NSURL * _Nonnull)url;
		[Static]
		[Export ("URLWithURL:")]
		Url Create (NSUrl url);

		// +(FBSDKURL * _Nonnull)URLWithInboundURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication;
		[Static]
		[Export ("URLWithInboundURL:sourceApplication:")]
		Url Create (NSUrl url, string sourceApplication);

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull targetURL;
		[Export ("targetURL", ArgumentSemantic.Strong)]
		NSUrl TargetUrl { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull targetQueryParameters;
		[Export ("targetQueryParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> TargetQueryParameters { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull appLinkData;
		[Export ("appLinkData", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkData { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull appLinkExtras;
		[Export ("appLinkExtras", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkExtras { get; }

		// @property (readonly, nonatomic, strong) FBSDKAppLink * _Nonnull appLinkReferer;
		[Export ("appLinkReferer", ArgumentSemantic.Strong)]
		AppLink AppLinkReferer { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull inputURL;
		[Export ("inputURL", ArgumentSemantic.Strong)]
		NSUrl InputUrl { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull inputQueryParameters;
		[Export ("inputQueryParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> InputQueryParameters { get; }
	}

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKUtility")]
	interface Utility {

		// +(NSDictionary *)dictionaryWithQueryString:(NSString *)queryString;
		[Static]
		[Export ("dictionaryWithQueryString:")]
		NSDictionary CreateDictionary (string queryString);

		[Obsolete ("Use CreateDictionary method instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("CreateDictionary (queryString)")]
		NSDictionary DictionaryWithQueryString (string queryString);

		// +(NSString *)queryStringWithDictionary:(NSDictionary *)dictionary error:(NSError **)errorRef;
		[Static]
		[Export ("queryStringWithDictionary:error:")]
		string CreateQueryString ([NullAllowed] NSDictionary dictionary, out NSError errorRef);

		[Obsolete ("Use CreateQueryString method instead. This will be removed in future versions.")]
		[Static]
		[Wrap ("CreateQueryString (dictionary, out errorRef)")]
		string QueryStringWithDictionary ([NullAllowed] NSDictionary dictionary, out NSError errorRef);

		// +(NSString *)URLDecode:(NSString *)value;
		[Static]
		[Export ("URLDecode:")]
		string UrlDecode (string value);

		// +(NSString *)URLEncode:(NSString *)value;
		[Static]
		[Export ("URLEncode:")]
		string UrlEncode (string value);

		// +(dispatch_source_t)startGCDTimerWithInterval:(double)interval block:(dispatch_block_t)block;
		[Internal]
		[Static]
		[Export ("startGCDTimerWithInterval:block:")]
		IntPtr _StartGcdTimer (double interval, Action block);

		[Static]
		[Wrap ("new DispatchSource.Timer (_StartGcdTimer (interval, block))")]
		DispatchSource StartGcdTimer (double interval, Action block);

		// +(void)stopGCDTimer:(dispatch_source_t)timer;
		[Internal]
		[Static]
		[Export ("stopGCDTimer:")]
		void _StopGcdTimer (IntPtr timer);

		[Static]
		[Wrap ("_StopGcdTimer (timer.Handle)")]
		void StopGcdTimer (DispatchSource timer);
	}

	// @interface FBSDKWebViewAppLinkResolver : NSObject <FBSDKAppLinkResolving>
	[BaseType (typeof (NSObject), Name = "FBSDKWebViewAppLinkResolver")]
	interface WebViewAppLinkResolver : AppLinkResolving {
		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		WebViewAppLinkResolver SharedInstance { get; }
	}

	// This just binds what is needed to work
	[BaseType (typeof (NSObject), Name = "BFTask")]
	interface Task {

		[Export ("result", ArgumentSemantic.Strong)]
		NSObject Result { get; }

		[Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; }

		[Export ("exception", ArgumentSemantic.Strong)]
		[Obsolete ("Task exception handling is deprecated and will be removed in a future release.")]
		NSException Exception { get; }

		[Export ("isCancelled", ArgumentSemantic.Assign)]
		bool IsCancelled { get; }

		[Export ("isFaulted", ArgumentSemantic.Assign)]
		bool IsFaulted { get; }

		[Export ("isCompleted", ArgumentSemantic.Assign)]
		bool IsCompleted { get; }
	}

	interface IBFAppLinkResolving { }

	[Obsolete ("Use Facebook.CoreKit.IAppLinkResolving interface instead.")]
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "BFAppLinkResolving")]
	interface BFAppLinkResolving {

		// @required -(BFTask *)appLinkFromURLInBackground:(NSURL *)url;
		[Abstract]
		[Export ("appLinkFromURLInBackground:")]
		Task AppLinkInBackground (NSUrl url);
	}
}
