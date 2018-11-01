//
// ApiDefinition.cs: Bindings to the Facebook iOS SDK.
//
//	Authors:
//		Miguel de Icaza (miguel@xamarin.com)
//		Alex Soto 	(alex.soto@xamarin.com)
//		Israel Soto 	(israel.soto@xamarin.com)
//

using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreLocation;
using Accounts;
using CoreGraphics;
using System.Reflection;
using System.ComponentModel;
using CoreMedia;
using CoreFoundation;

namespace Facebook.AudienceNetwork
{

	// @interface FBAdChoicesView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBAdChoicesView")]
	interface AdChoicesView {
		// @property (readonly, nonatomic, weak) UILabel * label;
		[Export ("label", ArgumentSemantic.Weak)]
		UILabel Label { get; }

		// @property (getter = isBackgroundShown, assign, nonatomic) BOOL backgroundShown;
		[Export ("backgroundShown")]
		bool BackgroundShown { [Bind ("isBackgroundShown")] get; set; }

		// @property (nonatomic, assign, readonly, getter=isExpandable) BOOL expandable;
		[Export ("expandable")]
		bool Expandable { [Bind ("isExpandable")] get; set; }

		// @property (readwrite, nonatomic, weak) FBNativeAdBase * _Nullable nativeAd;
		[NullAllowed]
		[Export ("nativeAd", ArgumentSemantic.Weak)]
		NativeAdBase NativeAd { get; set; }

		// @property (nonatomic, assign, readwrite) UIRectCorner corner;
		[Export ("corner", ArgumentSemantic.Assign)]
		UIRectCorner Corner { get; set; }

		// @property (assign, readwrite, nonatomic) UIEdgeInsets insets;
		[Export ("insets", ArgumentSemantic.Assign)]
		UIEdgeInsets Insets { get; set; }

		// @property (nonatomic, weak, readwrite, nullable) UIViewController *rootViewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// @property (readonly, assign, nonatomic) FBNativeAdViewTag nativeAdViewTag;
		[Export ("nativeAdViewTag", ArgumentSemantic.Assign)]
		NativeAdViewTag NativeAdViewTag { get; }

		// -(instancetype)initWithNativeAd:(FBNativeAd *)nativeAd;
		[Export ("initWithNativeAd:")]
		IntPtr Constructor (NativeAdBase nativeAd);

		// - (nonnull instancetype)initWithNativeAd:(nonnull FBNativeAd *)nativeAd expandable:(BOOL)expandable;
		[Export ("initWithNativeAd:expandable:")]
		IntPtr Constructor (NativeAdBase nativeAd, bool expandable);

		// -(instancetype _Nonnull)initWithNativeAd:(FBNativeAdBase * _Nonnull)nativeAd expandable:(BOOL)expandable attributes:(FBNativeAdViewAttributes * _Nullable)attributes;
		[Export ("initWithNativeAd:expandable:attributes:")]
		IntPtr Constructor (NativeAdBase nativeAd, bool expandable, [NullAllowed] NativeAdViewAttributes attributes);

		// -(void)updateFrameFromSuperview;
		[Export ("updateFrameFromSuperview")]
		void UpdateFrameFromSuperview ();

		// -(void)updateFrameFromSuperview:(UIRectCorner)corner;
		[Export ("updateFrameFromSuperview:")]
		void UpdateFrameFromSuperview (UIRectCorner corner);

		// - (void)updateFrameFromSuperview:(UIRectCorner)corner insets:(UIEdgeInsets)insets;
		[Export ("updateFrameFromSuperview:insets:")]
		void UpdateFrameFromSuperview (UIRectCorner corner, UIEdgeInsets insets);
	}

	[Static]
	interface AdExtraHintKeywords {
		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordAccessories;
		[Field ("FBAdExtraHintKeywordAccessories", "__Internal")]
		NSString Accessories { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordArtHistory;
		[Field ("FBAdExtraHintKeywordArtHistory", "__Internal")]
		NSString ArtHistory { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordAutomotive;
		[Field ("FBAdExtraHintKeywordAutomotive", "__Internal")]
		NSString Automotive { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBeauty;
		[Field ("FBAdExtraHintKeywordBeauty", "__Internal")]
		NSString Beauty { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBiology;
		[Field ("FBAdExtraHintKeywordBiology", "__Internal")]
		NSString Biology { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBoardGames;
		[Field ("FBAdExtraHintKeywordBoardGames", "__Internal")]
		NSString BoardGames { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBusinessSoftware;
		[Field ("FBAdExtraHintKeywordBusinessSoftware", "__Internal")]
		NSString BusinessSoftware { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBuyingSellingHomes;
		[Field ("FBAdExtraHintKeywordBuyingSellingHomes", "__Internal")]
		NSString BuyingSellingHomes { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordCats;
		[Field ("FBAdExtraHintKeywordCats", "__Internal")]
		NSString Cats { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordCelebrities;
		[Field ("FBAdExtraHintKeywordCelebrities", "__Internal")]
		NSString Celebrities { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordClothing;
		[Field ("FBAdExtraHintKeywordClothing", "__Internal")]
		NSString Clothing { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordComicBooks;
		[Field ("FBAdExtraHintKeywordComicBooks", "__Internal")]
		NSString ComicBooks { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordDesktopVideo;
		[Field ("FBAdExtraHintKeywordDesktopVideo", "__Internal")]
		NSString DesktopVideo { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordDogs;
		[Field ("FBAdExtraHintKeywordDogs", "__Internal")]
		NSString Dogs { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordEducation;
		[Field ("FBAdExtraHintKeywordEducation", "__Internal")]
		NSString Education { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordEmail;
		[Field ("FBAdExtraHintKeywordEmail", "__Internal")]
		NSString Email { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordEntertainment;
		[Field ("FBAdExtraHintKeywordEntertainment", "__Internal")]
		NSString Entertainment { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFamilyParenting;
		[Field ("FBAdExtraHintKeywordFamilyParenting", "__Internal")]
		NSString FamilyParenting { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFashion;
		[Field ("FBAdExtraHintKeywordFashion", "__Internal")]
		NSString Fashion { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFineArt;
		[Field ("FBAdExtraHintKeywordFineArt", "__Internal")]
		NSString FineArt { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFoodDrink;
		[Field ("FBAdExtraHintKeywordFoodDrink", "__Internal")]
		NSString FoodDrink { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFrenchCuisine;
		[Field ("FBAdExtraHintKeywordFrenchCuisine", "__Internal")]
		NSString FrenchCuisine { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordGovernment;
		[Field ("FBAdExtraHintKeywordGovernment", "__Internal")]
		NSString Government { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordHealthFitness;
		[Field ("FBAdExtraHintKeywordHealthFitness", "__Internal")]
		NSString HealthFitness { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordHobbies;
		[Field ("FBAdExtraHintKeywordHobbies", "__Internal")]
		NSString Hobbies { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordHomeGarden;
		[Field ("FBAdExtraHintKeywordHomeGarden", "__Internal")]
		NSString HomeGarden { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordHumor;
		[Field ("FBAdExtraHintKeywordHumor", "__Internal")]
		NSString Humor { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordInternetTechnology;
		[Field ("FBAdExtraHintKeywordInternetTechnology", "__Internal")]
		NSString InternetTechnology { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordLargeAnimals;
		[Field ("FBAdExtraHintKeywordLargeAnimals", "__Internal")]
		NSString LargeAnimals { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordLaw;
		[Field ("FBAdExtraHintKeywordLaw", "__Internal")]
		NSString Law { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordLegalIssues;
		[Field ("FBAdExtraHintKeywordLegalIssues", "__Internal")]
		NSString LegalIssues { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordLiterature;
		[Field ("FBAdExtraHintKeywordLiterature", "__Internal")]
		NSString Literature { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordMarketing;
		[Field ("FBAdExtraHintKeywordMarketing", "__Internal")]
		NSString Marketing { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordMovies;
		[Field ("FBAdExtraHintKeywordMovies", "__Internal")]
		NSString Movies { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordMusic;
		[Field ("FBAdExtraHintKeywordMusic", "__Internal")]
		NSString Music { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordNews;
		[Field ("FBAdExtraHintKeywordNews", "__Internal")]
		NSString News { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordPersonalFinance;
		[Field ("FBAdExtraHintKeywordPersonalFinance", "__Internal")]
		NSString PersonalFinance { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordPets;
		[Field ("FBAdExtraHintKeywordPets", "__Internal")]
		NSString Pets { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordPhotography;
		[Field ("FBAdExtraHintKeywordPhotography", "__Internal")]
		NSString Photography { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordPolitics;
		[Field ("FBAdExtraHintKeywordPolitics", "__Internal")]
		NSString Politics { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordRealEstate;
		[Field ("FBAdExtraHintKeywordRealEstate", "__Internal")]
		NSString RealEstate { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordRoleplayingGames;
		[Field ("FBAdExtraHintKeywordRoleplayingGames", "__Internal")]
		NSString RoleplayingGames { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordScience;
		[Field ("FBAdExtraHintKeywordScience", "__Internal")]
		NSString Science { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordShopping;
		[Field ("FBAdExtraHintKeywordShopping", "__Internal")]
		NSString Shopping { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordSociety;
		[Field ("FBAdExtraHintKeywordSociety", "__Internal")]
		NSString Society { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordSports;
		[Field ("FBAdExtraHintKeywordSports", "__Internal")]
		NSString Sports { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordTechnology;
		[Field ("FBAdExtraHintKeywordTechnology", "__Internal")]
		NSString Technology { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordTelevision;
		[Field ("FBAdExtraHintKeywordTelevision", "__Internal")]
		NSString Television { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordTravel;
		[Field ("FBAdExtraHintKeywordTravel", "__Internal")]
		NSString Travel { get; }

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordVideoComputerGames;
		[Field ("FBAdExtraHintKeywordVideoComputerGames", "__Internal")]
		NSString VideoComputerGames { get; }
	}

	// @interface FBAdExtraHint : NSObject
	[BaseType (typeof (NSObject), Name = "FBAdExtraHint")]
	interface AdExtraHint {
		// @property (copy, nonatomic) NSString * _Nullable UISpec;
		[NullAllowed, Export ("UISpec")]
		string UISpec { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentURL;
		[NullAllowed, Export ("contentURL")]
		string ContentUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extraData;
		[NullAllowed, Export ("extraData")]
		string ExtraData { get; set; }

		// -(instancetype _Nonnull)initWithKeywords:(NSArray<FBAdExtraHintKeyword> * _Nonnull)keywords;
		[Export ("initWithKeywords:")]
		IntPtr Constructor (NSString [] keywords);

		// -(void)addKeyword:(FBAdExtraHintKeyword _Nonnull)keyword;
		[Export ("addKeyword:")]
		void AddKeyword (NSString keyword);

		// -(void)removeKeyword:(FBAdExtraHintKeyword _Nonnull)keyword;
		[Export ("removeKeyword:")]
		void RemoveKeyword (NSString keyword);
	}

	// @interface FBAdIconView : UIView
	[BaseType (typeof (UIView), Name = "FBAdIconView")]
	interface AdIconView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (readonly, assign, nonatomic) FBNativeAdViewTag nativeAdViewTag;
		[Export ("nativeAdViewTag", ArgumentSemantic.Assign)]
		NativeAdViewTag NativeAdViewTag { get; }
	}

	delegate void AdImageCompletionHandler ([NullAllowed] UIImage imageLoaded);

	// @interface FBAdImage : NSObject
	[BaseType (typeof (NSObject), Name = "FBAdImage")]
	interface AdImage {
		// @property (readonly, copy, nonatomic) NSURL * url;
		[Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		// @property (readonly, assign, nonatomic) NSInteger width;
		[Export ("width")]
		nint Width { get; }

		// @property (readonly, assign, nonatomic) NSInteger height;
		[Export ("height")]
		nint Height { get; }

		// -(instancetype)initWithURL:(NSURL *)url width:(NSInteger)width height:(NSInteger)height __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithURL:width:height:")]
		IntPtr Constructor (NSUrl url, nint width, nint height);

		// -(void)loadImageAsyncWithBlock:(void (^ _Nullable)(UIImage * _Nullable))block;
		[Export ("loadImageAsyncWithBlock:")]
		void LoadImageAsync ([NullAllowed] AdImageCompletionHandler block);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBAdSettings")]
	interface AdSettings {
		[Field ("FBAudienceNetworkErrorDomain", "__Internal")]
		NSString AdsErrorDomain { get; }

		[Field ("FBAudienceNetworkMediaViewErrorDomain", "__Internal")]
		NSString MediaViewErrorDomain { get; }

		// @property (class, nonatomic, assign, getter=isBackgroundVideoPlaybackAllowed) BOOL backgroundVideoPlaybackAllowed;
		[Static]
		[Export ("backgroundVideoPlaybackAllowed")]
		bool IsBackgroundVideoPlaybackAllowed { [Bind ("isBackgroundVideoPlaybackAllowed")] get; set; }

		// @property (class, nonatomic, assign) FBAdTestAdType testAdType;
		[Static]
		[Export ("testAdType", ArgumentSemantic.Assign)]
		AdTestAdType TestAdType { get; set; }

		// @property (class, nonatomic, weak, nullable) id<FBAdLoggingDelegate> loggingDelegate;
		[Static]
		[NullAllowed]
		[Export ("loggingDelegate", ArgumentSemantic.Weak)]
		IAdLoggingDelegate LoggingDelegate { get; set; }

		// @property (class, nonatomic, copy, readonly) NSString *bidderToken;
		[Static]
		[Export ("bidderToken")]
		string BidderToken { get; }

		// @property (readonly, copy, nonatomic, class) NSString * _Nonnull routingToken;
		[Static]
		[Export ("routingToken")]
		string RoutingToken { get; }

		[Static]
		[Export ("isTestMode")]
		bool IsTestMode { get; }

		[Static]
		[Export ("testDeviceHash")]
		string TestDeviceHash { get; }

		[Static]
		[Export ("addTestDevice:")]
		void AddTestDevice (string deviceHash);

		[Static]
		[Export ("addTestDevices:")]
		void AddTestDevices (string [] devicesHash);

		[Static]
		[Export ("clearTestDevices")]
		void ClearTestDevices ();

		[Static]
		[Export ("clearTestDevice:")]
		void ClearTestDevice (string deviceHash);

		[Static]
		[Export ("setIsChildDirected:")]
		void SetIsChildDirected (bool isChildDirected);

		// + (void)setMediationService:(NSString *)service;
		[Static]
		[Export ("setMediationService:")]
		void SetMediationService (string service);

		// + (NSString *)urlPrefix;
		// + (void)setUrlPrefix:(NSString *)urlPrefix;
		[Advice ("This property should never be used in production.")]
		[Static]
		[NullAllowed]
		[Export ("urlPrefix")]
		string UrlPrefix { get; set; }

		[Obsolete ("Use UrlPrefix property instead. This will be removed in future versions.")]
		[Advice ("This method should never be used in production.")]
		[Static]
		[return: NullAllowed]
		[Wrap ("UrlPrefix")]
		string GetUrlPrefix ();

		[Obsolete ("Use UrlPrefix property instead. This will be removed in future versions.")]
		[Advice ("This method should never be used in production.")]
		[Static]
		[Wrap ("UrlPrefix = urlPrefix")]
		void SetUrlPrefix ([NullAllowed] string urlPrefix);

		// +(FBAdLogLevel)getLogLevel;
		// +(void)setLogLevel:(FBAdLogLevel)level;
		[Static]
		[Export ("logLevel")]
		AdLogLevel LogLevel { [Bind ("getLogLevel")] get; set; }

		// + (FBMediaViewRenderingMethod)mediaViewRenderingMethod;
		// + (void)setMediaViewRenderingMethod:(FBMediaViewRenderingMethod)mediaViewRenderingMethod;
		[Static]
		[Export ("mediaViewRenderingMethod")]
		MediaViewRenderingMethod MediaViewRenderingMethod { get; set; }
	}

	interface IAdLoggingDelegate { }

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBAdLoggingDelegate")]
	interface AdLoggingDelegate {
		// @required -(void)logAtLevel:(FBAdLogLevel)level withFileName:(NSString * _Nonnull)fileName withLineNumber:(int)lineNumber withThreadId:(long)threadId withBody:(NSString * _Nonnull)body;
		[Abstract]
		[Export ("logAtLevel:withFileName:withLineNumber:withThreadId:withBody:")]
		void Log (AdLogLevel level, string fileName, int lineNumber, nint threadId, string body);
	}

	[Static]
	interface AdSizes {
		[Internal]
		[Field ("kFBAdSize320x50", "__Internal")]
		IntPtr _kFBAdSize320x50 { get; }

		[Internal]
		[Field ("kFBAdSizeHeight50Banner", "__Internal")]
		IntPtr _kFBAdSizeHeight50Banner { get; }

		[Internal]
		[Field ("kFBAdSizeHeight90Banner", "__Internal")]
		IntPtr _kFBAdSizeHeight90Banner { get; }

		[Internal]
		[Field ("kFBAdSizeInterstitial", "__Internal")]
		IntPtr _kFBAdSizeInterstitial { get; }

		[Internal]
		[Field ("kFBAdSizeHeight250Rectangle", "__Internal")]
		IntPtr _kFBAdSizeHeight250Rectangle { get; }
	}

	// @interface FBAdStarRatingView : UIView
	[Obsolete]
	[BaseType (typeof (UIView), Name = "FBAdStarRatingView")]
	interface AdStarRatingView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic) struct FBAdStarRating rating;
		[Export ("rating", ArgumentSemantic.Assign)]
		AdStarRating Rating { get; set; }

		// @property (nonatomic, strong) UIColor * primaryColor;
		[Export ("primaryColor", ArgumentSemantic.Strong)]
		UIColor PrimaryColor { get; set; }

		// @property (nonatomic, strong) UIColor * secondaryColor;
		[Export ("secondaryColor", ArgumentSemantic.Strong)]
		UIColor SecondaryColor { get; set; }

		// -(instancetype)initWithFrame:(CGRect)frame withStarRating:(struct FBAdStarRating)starRating __attribute__((objc_designated_initializer));
		[Export ("initWithFrame:withStarRating:")]
		IntPtr Constructor (CGRect frame, AdStarRating starRating);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBAdView")]
	interface AdView {
		[DesignatedInitializer]
		[Export ("initWithPlacementID:adSize:rootViewController:")]
		IntPtr Constructor (string placementId, AdSize adSize, [NullAllowed] UIViewController rootViewController);

		[Export ("loadAd")]
		void LoadAd ();

		// - (void)loadAdWithBidPayload:(NSString *)bidPayload;
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		// -(void)disableAutoRefresh;
		[Obsolete ("Autorefresh is disabled by default.")]
		[Export ("disableAutoRefresh")]
		void DisableAutoRefresh ();

		[Export ("placementID")]
		string PlacementId { get; }

		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; }

		// @property (readonly, getter = isAdValid, nonatomic) BOOL adValid;
		[Export ("isAdValid")]
		bool IsAdValid { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAdViewDelegate Delegate { get; set; }

		// @property (nonatomic, strong) FBAdExtraHint * _Nullable extraHint;
		[NullAllowed]
		[Export ("extraHint", ArgumentSemantic.Strong)]
		AdExtraHint ExtraHint { get; set; }
	}

	interface IAdViewDelegate { }

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBAdViewDelegate")]
	interface AdViewDelegate {
		[Export ("adViewDidClick:")]
		void AdViewDidClick (AdView adView);

		[Export ("adViewDidFinishHandlingClick:")]
		void AdViewDidFinishHandlingClick (AdView adView);

		[Export ("adViewDidLoad:")]
		void AdViewDidLoad (AdView adView);

		[Export ("adView:didFailWithError:")]
		void AdViewDidFail (AdView adView, NSError error);

		// @optional -(void)adViewWillLogImpression:(FBAdView * _Nonnull)adView;
		[Export ("adViewWillLogImpression:")]
		void AdViewWillLogImpression (AdView adView);

		[Export ("viewControllerForPresentingModalView", ArgumentSemantic.Strong)]
		UIViewController GetViewControllerForPresentingModalView ();
	}

	// @interface FBInstreamAdView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBInstreamAdView")]
	interface InstreamAdView {
		// @property (readonly, getter = isAdValid, nonatomic) BOOL adValid;
		[Export ("adValid")]
		bool IsAdValid { [Bind ("isAdValid")] get; }

		// @property (nonatomic, weak) id<FBInstreamAdViewDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IInstreamAdViewDelegate Delegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull placementID;
		[NullAllowed]
		[Export ("placementID")]
		string PlacementId { get; }

		[Obsolete ("Use PlacementId property instead. This will be removed in future versions.")]
		[Wrap ("PlacementId")]
		string PlacementID { get; }

		// @property (nonatomic, strong) FBAdExtraHint * _Nullable extraHint;
		[NullAllowed]
		[Export ("extraHint", ArgumentSemantic.Strong)]
		AdExtraHint ExtraHint { get; set; }

		// -(instancetype _Nullable)initWithPlacementID:(NSString * _Nonnull)placementID __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithPlacementID:")]
		IntPtr Constructor (string placementId);

		// -(void)loadAd;
		[PostGet ("IsAdValid")]
		[Export ("loadAd")]
		void LoadAd ();

		// - (void) loadAdWithBidPayload:(NSString*) bidPayload;
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		// -(BOOL)showAdFromRootViewController:(UIViewController * _Nullable)rootViewController;
		[Export ("showAdFromRootViewController:")]
		bool ShowAd ([NullAllowed] UIViewController rootViewController);
	}

	interface IInstreamAdViewDelegate { }

	// @protocol FBInstreamAdViewDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBInstreamAdViewDelegate")]
	interface InstreamAdViewDelegate {
		// @required -(void)adViewDidLoad:(FBInstreamAdView * _Nonnull)adView;
		[Abstract]
		[Export ("adViewDidLoad:")]
		void AdViewDidLoad ([NullAllowed] InstreamAdView adView);

		// @required -(void)adViewDidEnd:(FBInstreamAdView * _Nonnull)adView;
		[Abstract]
		[Export ("adViewDidEnd:")]
		void AdViewDidEnd ([NullAllowed] InstreamAdView adView);

		// @required -(void)adView:(FBInstreamAdView * _Nonnull)adView didFailWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("adView:didFailWithError:")]
		void AdViewDidFail ([NullAllowed] InstreamAdView adView, [NullAllowed] NSError error);

		// @optional -(void)adViewDidClick:(FBInstreamAdView * _Nonnull)adView;
		[Export ("adViewDidClick:")]
		void AdViewDidClick ([NullAllowed] InstreamAdView adView);

		// @optional -(void)adViewWillLogImpression:(FBInstreamAdView * _Nonnull)adView;
		[Export ("adViewWillLogImpression:")]
		void AdViewWillLogImpression ([NullAllowed] InstreamAdView adView);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBInterstitialAd")]
	interface InterstitialAd {
		[Export ("placementID")]
		string PlacementId { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IInterstitialAdDelegate Delegate { get; set; }

		// @property (nonatomic, strong) FBAdExtraHint * _Nullable extraHint;
		[NullAllowed]
		[Export ("extraHint", ArgumentSemantic.Strong)]
		AdExtraHint ExtraHint { get; set; }

		[Export ("initWithPlacementID:")]
		[DesignatedInitializer]
		IntPtr Constructor (string placementId);

		[Export ("isAdValid")]
		bool IsAdValid { get; }

		[PostGet ("IsAdValid")]
		[Export ("loadAd")]
		void LoadAd ();

		// - (void) loadAdWithBidPayload:(NSString*) bidPayload;
		[PostGet ("IsAdValid")]
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		[Export ("showAdFromRootViewController:")]
		bool ShowAd ([NullAllowed] UIViewController rootViewController);

		[Obsolete ("Use ShowAd method instead. This will be removed in future versions.")]
		[Wrap ("ShowAd (rootViewController)")]
		bool ShowAdFromRootViewController (UIViewController rootViewController);
	}

	interface IInterstitialAdDelegate { }

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBInterstitialAdDelegate")]
	interface InterstitialAdDelegate {
		[Export ("interstitialAdDidClick:")]
		void InterstitialAdDidClick (InterstitialAd interstitialAd);

		[Export ("interstitialAdDidClose:")]
		void InterstitialAdDidClose (InterstitialAd interstitialAd);

		[Export ("interstitialAdWillClose:")]
		void InterstitialAdWillClose (InterstitialAd interstitialAd);

		[Export ("interstitialAdDidLoad:")]
		void InterstitialAdDidLoad (InterstitialAd interstitialAd);

		[Export ("interstitialAd:didFailWithError:")]
		void IntersitialDidFail (InterstitialAd interstitialAd, NSError error);

		// @optional -(void)interstitialAdWillLogImpression:(FBInterstitialAd * _Nonnull)interstitialAd;
		[Export ("interstitialAdWillLogImpression:")]
		void InterstitialAdWillLogImpression (InterstitialAd interstitialAd);
	}

	// @interface FBMediaView : UIView
	[BaseType (typeof (AdIconView), Name = "FBMediaView")]
	interface MediaView {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, weak) id<FBMediaViewDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IMediaViewDelegate Delegate { get; set; }

		// @property (nonatomic, strong, nonnull) FBMediaViewVideoRenderer *videoRenderer;
		[Export ("videoRenderer", ArgumentSemantic.Strong)]
		MediaViewVideoRenderer VideoRenderer { get; set; }

		// @property (readonly, assign, nonatomic) float volume;
		[Export ("volume")]
		float Volume { get; }

		// @property (nonatomic, readonly, getter=isAutoplayEnabled) BOOL autoplayEnabled;
		[Export ("isAutoplayEnabled")]
		bool IsAutoplayEnabled { get; }

		[Obsolete ("Use IsAutoplayEnabled property instead. This will be removed in future versions.")]
		[Wrap ("IsAutoplayEnabled")]
		bool AutoplayEnabled { get; }

		// @property (readonly, assign, nonatomic) CGFloat aspectRatio;
		[Export ("aspectRatio")]
		nfloat AspectRatio { get; }

		// @property (readonly, assign, nonatomic) FBNativeAdViewTag nativeAdViewTag;
		[New]
		[Export ("nativeAdViewTag", ArgumentSemantic.Assign)]
		NativeAdViewTag NativeAdViewTag { get; }

		// -(void)applyNaturalWidth;
		[Export ("applyNaturalWidth")]
		void ApplyNaturalWidth ();

		// -(void)applyNaturalHeight;
		[Export ("applyNaturalHeight")]
		void ApplyNaturalHeight ();
	}

	interface IMediaViewDelegate { }

	// @protocol FBMediaViewDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBMediaViewDelegate")]
	interface MediaViewDelegate {
		// @optional -(void)mediaViewDidLoad:(FBMediaView *)mediaView;
		[Export ("mediaViewDidLoad:")]
		void MediaViewDidLoad (MediaView mediaView);

		// @optional -(void)mediaViewWillEnterFullscreen:(FBMediaView * _Nonnull)mediaView;
		[Export ("mediaViewWillEnterFullscreen:")]
		void MediaViewWillEnterFullscreen (MediaView mediaView);

		// @optional -(void)mediaViewDidExitFullscreen:(FBMediaView * _Nonnull)mediaView;
		[Export ("mediaViewDidExitFullscreen:")]
		void MediaViewDidExitFullscreen (MediaView mediaView);

		// @optional -(void)mediaView:(FBMediaView * _Nonnull)mediaView videoVolumeDidChange:(float)volume;
		[Export ("mediaView:videoVolumeDidChange:")]
		void MediaViewVideoVolumeDidChange (MediaView mediaView, float volume);

		// @optional -(void)mediaViewVideoDidPause:(FBMediaView * _Nonnull)mediaView;
		[Export ("mediaViewVideoDidPause:")]
		void MediaViewVideoDidPause (MediaView mediaView);

		// @optional -(void)mediaViewVideoDidPlay:(FBMediaView * _Nonnull)mediaView;
		[Export ("mediaViewVideoDidPlay:")]
		void MediaViewVideoDidPlay (MediaView mediaView);

		// @optional -(void)mediaViewVideoDidComplete:(MediaView * _Nonnull)mediaView;
		[Export ("mediaViewVideoDidComplete:")]
		void MediaViewVideoDidComplete (MediaView mediaView);
	}

	// @interface FBMediaViewVideoRenderer : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBMediaViewVideoRenderer")]
	interface MediaViewVideoRenderer {
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, assign, readonly) CGFloat aspectRatio;
		[Export ("aspectRatio", ArgumentSemantic.Assign)]
		nfloat AspectRatio { get; }

		// @property (nonatomic, assign, readonly) CMTime currentTime;
		[Export ("currentTime", ArgumentSemantic.Assign)]
		CMTime CurrentTime { get; }

		// @property (nonatomic, assign, readonly) CMTime duration;
		[Export ("duration", ArgumentSemantic.Assign)]
		CMTime Duration { get; }

		// @property (nonatomic, assign, readonly, getter=isPlaying) BOOL playing;
		[Export ("isPlaying", ArgumentSemantic.Assign)]
		bool IsPlaying { get; }

		// @property (nonatomic, assign) float volume;
		[Export ("volume", ArgumentSemantic.Assign)]
		float Volume { get; set; }

		// - (void)playVideo;
		[Export ("playVideo")]
		void PlayVideo ();

		// - (void)pauseVideo;
		[Export ("pauseVideo")]
		void PauseVideo ();

		// - (void)engageVideoSeek;
		[Export ("engageVideoSeek")]
		void EngageVideoSeek ();

		// - (void)disengageVideoSeek;
		[Export ("disengageVideoSeek")]
		void DisengageVideoSeek ();

		// - (void)seekVideoToTime:(CMTime)time;
		[Export ("seekVideoToTime:")]
		void SeekVideoToTime (CMTime time);

		// - (nullable id)addPeriodicTimeObserverForInterval:(CMTime)interval queue:(dispatch_queue_t) queue usingBlock:(void (^)(CMTime time))block;
		[return: NullAllowed]
		[Export ("addPeriodicTimeObserverForInterval:queue:usingBlock:")]
		NSObject AddPeriodicTimeObserver (CMTime interval, DispatchQueue queue, Action<CMTime> block);

		// - (void)removeTimeObserver:(id)observer;
		[Export ("removeTimeObserver:")]
		void RemoveTimeObserver (NSObject observer);

		// - (void)videoDidChangeVolume;
		[Export ("videoDidChangeVolume")]
		void VideoDidChangeVolume ();

		// - (void)videoDidLoad;
		[Export ("videoDidLoad")]
		void VideoDidLoad ();

		// - (void)videoDidPause;
		[Export ("videoDidPause")]
		void VideoDidPause ();

		// - (void)videoDidPlay;
		[Export ("videoDidPlay")]
		void VideoDidPlay ();

		// - (void)videoDidEngageSeek;
		[Export ("videoDidEngageSeek")]
		void VideoDidEngageSeek ();

		// - (void)videoDidSeek;
		[Export ("videoDidSeek")]
		void VideoDidSeek ();

		// - (void)videoDidDisengageSeek;
		[Export ("videoDidDisengageSeek")]
		void VideoDidDisengageSeek ();

		// - (void)videoDidEnd;
		[Export ("videoDidEnd")]
		void VideoDidEnd ();

		// - (void)videoDidFailWithError:(NSError *)error;
		[Export ("videoDidFailWithError:")]
		void VideoDidFail (NSError error);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NativeAdBase), Name = "FBNativeAd")]
	interface NativeAd {
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		[Export ("initWithPlacementID:")]
		IntPtr Constructor (string placementId);

		// - (void)registerViewForInteraction:(UIView *)view mediaView:(FBMediaView*) mediaView iconView:(nullable FBAdIconView *)iconView viewController:(nullable UIViewController *)viewController;
		[Export ("registerViewForInteraction:mediaView:iconView:viewController:")]
		void RegisterView (UIView view, MediaView mediaView, [NullAllowed] AdIconView iconView, [NullAllowed] UIViewController viewController);

		// - (void)registerViewForInteraction:(UIView *)view mediaView:(FBMediaView*) mediaView iconView:(nullable FBAdIconView *)iconView viewController:(nullable UIViewController *)viewController clickableViews:(nullable NSArray<UIView*> *)clickableViews;
		[Export ("registerViewForInteraction:mediaView:iconView:viewController:clickableViews:")]
		void RegisterView (UIView view, MediaView mediaView, [NullAllowed] AdIconView iconView, [NullAllowed] UIViewController viewController, [NullAllowed] UIView [] clickableViews);

		// -(void)registerViewForInteraction:(UIView * _Nonnull)view mediaView:(FBMediaView * _Nonnull)mediaView iconImageView:(UIImageView * _Nullable)iconImageView viewController:(UIViewController * _Nullable)viewController;
		[Export ("registerViewForInteraction:mediaView:iconImageView:viewController:")]
		void RegisterView (UIView view, MediaView mediaView, [NullAllowed] UIImageView iconImageView, [NullAllowed] UIViewController viewController);

		// -(void)registerViewForInteraction:(UIView * _Nonnull)view mediaView:(FBMediaView * _Nonnull)mediaView iconImageView:(UIImageView * _Nullable)iconImageView viewController:(UIViewController * _Nullable)viewController clickableViews:(NSArray<UIView *> * _Nullable)clickableViews;
		[Export ("registerViewForInteraction:mediaView:iconImageView:viewController:clickableViews:")]
		void RegisterView (UIView view, MediaView mediaView, [NullAllowed] UIImageView iconImageView, [NullAllowed] UIViewController viewController, [NullAllowed] UIView [] clickableViews);

		// -(void)downloadMedia;
		[Export ("downloadMedia")]
		void DownloadMedia ();
	}

	interface INativeAdDelegate { }

	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBNativeAdDelegate")]
	interface NativeAdDelegate
	{
		[Export ("nativeAdDidLoad:")]
		void NativeAdDidLoad (NativeAd nativeAd);

		// @optional -(void)nativeAdDidDownloadMedia:(FBNativeAd * _Nonnull)nativeAd;
		[Export ("nativeAdDidDownloadMedia:")]
		void NativeAdDidDownloadMedia (NativeAd nativeAd);

		[Export ("nativeAd:didFailWithError:")]
		void NativeAdDidFail (NativeAd nativeAd, NSError error);

		[Export ("nativeAdDidClick:")]
		void NativeAdDidClick (NativeAd nativeAd);

		[Export ("nativeAdDidFinishHandlingClick:")]
		void NativeAdDidFinishHandlingClick (NativeAd nativeAd);

		[Export("nativeAdWillLogImpression:")]
		void NativeAdWillLogImpression(NativeAd nativeAd);
	}

	// @interface FBNativeAdBase : NSObject
	[BaseType (typeof (NSObject), Name = "FBNativeAdBase")]
	interface NativeAdBase {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull placementID;
		[Export ("placementID")]
		string PlacementId { get; }

		// @property (readonly, assign, nonatomic) struct FBAdStarRating starRating __attribute__((deprecated("")));
		[Export ("starRating", ArgumentSemantic.Assign)]
		AdStarRating StarRating { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable headline;
		[NullAllowed]
		[Export ("headline")]
		string Headline { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable linkDescription;
		[NullAllowed]
		[Export ("linkDescription")]
		string LinkDescription { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable advertiserName;
		[NullAllowed]
		[Export ("advertiserName")]
		string AdvertiserName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable socialContext;
		[NullAllowed]
		[Export ("socialContext")]
		string SocialContext { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable callToAction;
		[NullAllowed]
		[Export ("callToAction")]
		string CallToAction { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable rawBodyText;
		[NullAllowed]
		[Export ("rawBodyText")]
		string RawBodyText { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable bodyText;
		[NullAllowed]
		[Export ("bodyText")]
		string BodyText { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sponsoredTranslation;
		[NullAllowed]
		[Export ("sponsoredTranslation")]
		string SponsoredTranslation { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable adTranslation;
		[NullAllowed]
		[Export ("adTranslation")]
		string AdTranslation { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable promotedTranslation;
		[NullAllowed]
		[Export ("promotedTranslation")]
		string PromotedTranslation { get; }

		// @property (readonly, nonatomic, strong) FBAdImage * _Nullable adChoicesIcon;
		[NullAllowed]
		[Export ("adChoicesIcon", ArgumentSemantic.Strong)]
		AdImage AdChoicesIcon { get; }

		// @property (readonly, assign, nonatomic) CGFloat aspectRatio;
		[Export ("aspectRatio")]
		nfloat AspectRatio { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable adChoicesLinkURL;
		[NullAllowed]
		[Export ("adChoicesLinkURL", ArgumentSemantic.Copy)]
		NSUrl AdChoicesLinkUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable adChoicesText;
		[NullAllowed]
		[Export ("adChoicesText")]
		string AdChoicesText { get; }

		// @property (readonly, assign, nonatomic) FBAdFormatType adFormatType;
		[Export ("adFormatType", ArgumentSemantic.Assign)]
		AdFormatType AdFormatType { get; }

		// @property (readonly, nonatomic) FBNativeAdsCachePolicy mediaCachePolicy;
		[Export ("mediaCachePolicy")]
		NativeAdsCachePolicy MediaCachePolicy { get; }

		// @property (readonly, getter = isAdValid, nonatomic) BOOL adValid;
		[Export ("isAdValid")]
		bool IsAdValid { get; }

		// @property (readonly, getter = getAdNetwork, copy, nonatomic) NSString * _Nullable adNetwork;
		[NullAllowed]
		[Export ("getAdNetwork")]
		string AdNetwork { get; }

		// @property (readonly, getter = isRegistered, nonatomic) BOOL registered;
		[Export ("isRegistered")]
		bool IsRegistered { get; }

		// @property (nonatomic, strong) FBAdExtraHint * _Nullable extraHint;
		[NullAllowed]
		[Export ("extraHint", ArgumentSemantic.Strong)]
		AdExtraHint ExtraHint { get; set; }

		// -(void)unregisterView;
		[Export ("unregisterView")]
		void UnregisterView ();

		// -(void)loadAd;
		[Export ("loadAd")]
		void LoadAd ();

		// -(void)loadAdWithMediaCachePolicy:(FBNativeAdsCachePolicy)mediaCachePolicy;
		[Export ("loadAdWithMediaCachePolicy:")]
		void LoadAd (NativeAdsCachePolicy mediaCachePolicy);

		// -(void)loadAdWithBidPayload:(NSString * _Nonnull)bidPayload;
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		// -(void)loadAdWithBidPayload:(NSString * _Nonnull)bidPayload mediaCachePolicy:(FBNativeAdsCachePolicy)mediaCachePolicy;
		[Export ("loadAdWithBidPayload:mediaCachePolicy:")]
		void LoadAd (string bidPayload, NativeAdsCachePolicy mediaCachePolicy);
	}

	// @interface FBNativeAdBaseView : UIView
	[BaseType (typeof (UIView), Name = "FBNativeAdBaseView")]
	interface NativeAdBaseView {
		// @property (nonatomic, weak) UIViewController * _Nullable rootViewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }
	}

	// @interface FBNativeAdCollectionViewAdProvider : NSObject
	[BaseType (typeof (NSObject), Name = "FBNativeAdCollectionViewAdProvider")]
	interface NativeAdCollectionViewAdProvider {
		// @property (nonatomic, weak) id<FBNativeAdDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		// @property (nonatomic, strong) FBAdExtraHint * _Nullable extraHint;
		[NullAllowed]
		[Export ("extraHint", ArgumentSemantic.Strong)]
		AdExtraHint ExtraHint { get; set; }

		// -(instancetype _Nonnull)initWithManager:(FBNativeAdsManager * _Nonnull)manager __attribute__((objc_designated_initializer));
		[Export ("initWithManager:")]
		[DesignatedInitializer]
		IntPtr Constructor (NativeAdsManager manager);

		// -(FBNativeAd * _Nonnull)collectionView:(UICollectionView * _Nonnull)collectionView nativeAdForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("collectionView:nativeAdForRowAtIndexPath:")]
		NativeAd GetNativeAdForRow (UICollectionView collectionView, NSIndexPath indexPath);

		// -(BOOL)isAdCellAtIndexPath:(NSIndexPath * _Nonnull)indexPath forStride:(NSUInteger)stride;
		[Export ("isAdCellAtIndexPath:forStride:")]
		bool IsAdCellAtIndexPath (NSIndexPath indexPath, nuint stride);

		// -(NSIndexPath * _Nonnull)adjustNonAdCellIndexPath:(NSIndexPath * _Nonnull)indexPath forStride:(NSUInteger)stride;
		[return: NullAllowed]
		[Export ("adjustNonAdCellIndexPath:forStride:")]
		NSIndexPath AdjustNonAdCellIndexPath (NSIndexPath indexPath, nuint stride);

		// -(NSUInteger)adjustCount:(NSUInteger)count forStride:(NSUInteger)stride;
		[Export ("adjustCount:forStride:")]
		nuint AdjustCount (nuint count, nuint stride);
	}

	// @interface FBNativeAdCollectionViewCellProvider : FBNativeAdCollectionViewAdProvider
	[BaseType (typeof (NativeAdCollectionViewAdProvider), Name = "FBNativeAdCollectionViewCellProvider")]
	interface NativeAdCollectionViewCellProvider {
		// -(instancetype _Nonnull)initWithManager:(FBNativeAdsManager * _Nonnull)manager forType:(FBNativeAdViewType)type;
		[Export ("initWithManager:forType:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type);

		// -(instancetype _Nonnull)initWithManager:(FBNativeAdsManager * _Nonnull)manager forType:(FBNativeAdViewType)type forAttributes:(FBNativeAdViewAttributes * _Nonnull)attributes __attribute__((objc_designated_initializer));
		[Export ("initWithManager:forType:forAttributes:")]
		[DesignatedInitializer]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type, NativeAdViewAttributes attributes);

		// -(UICollectionViewCell * _Nonnull)collectionView:(UICollectionView * _Nonnull)collectionView cellForItemAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("collectionView:cellForItemAtIndexPath:")]
		UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath);

		// -(CGFloat)collectionView:(UICollectionView * _Nonnull)collectionView heightForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
		[Export ("collectionView:heightForRowAtIndexPath:")]
		nfloat GetHeightForRow (UICollectionView collectionView, NSIndexPath indexPath);
	}

	delegate UIView NativeAdScrollViewViewProviderHandler (NativeAd nativeAd, nuint position);

	// @interface FBNativeAdScrollView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBNativeAdScrollView")]
	interface NativeAdScrollView {
		// @property (readonly, assign, nonatomic) NSUInteger maximumNativeAdCount;
		[Export ("maximumNativeAdCount", ArgumentSemantic.Assign)]
		nuint MaximumNativeAdCount { get; }

		// @property (getter = isAnimationEnabled, assign, nonatomic) BOOL animationEnabled;
		[Export ("animationEnabled")]
		bool AnimationEnabled { [Bind ("isAnimationEnabled")] get; set; }

		// @property (assign, nonatomic) CGFloat xInset;
		[Export ("xInset", ArgumentSemantic.Assign)]
		nfloat XInset { get; set; }

		// @property (getter = isAdPersistenceEnabled, assign, nonatomic) BOOL adPersistenceEnabled;
		[Export ("adPersistenceEnabled")]
		bool AdPersistenceEnabled { [Bind ("isAdPersistenceEnabled")] get; set; }

		// @property (nonatomic, weak) UIViewController * viewController;
		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; set; }

		// @property (nonatomic, weak) id<FBNativeAdDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withType:(FBNativeAdViewType)type;
		[Export ("initWithNativeAdsManager:withType:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type);

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withType:(FBNativeAdViewType)type withAttributes:(FBNativeAdViewAttributes *)attributes;
		[Export ("initWithNativeAdsManager:withType:withAttributes:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type, NativeAdViewAttributes attributes);

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withType:(FBNativeAdViewType)type withAttributes:(FBNativeAdViewAttributes *)attributes withMaximum:(NSUInteger)maximumNativeAdCount;
		[Export ("initWithNativeAdsManager:withType:withAttributes:withMaximum:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type, NativeAdViewAttributes attributes, nuint maximumNativeAdCount);

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withViewProvider:(UIView *(^)(FBNativeAd *, NSUInteger))childViewProvider;
		[Export ("initWithNativeAdsManager:withViewProvider:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdScrollViewViewProviderHandler childViewProviderHandler);

		// -(instancetype)initWithNativeAdsManager:(FBNativeAdsManager *)manager withViewProvider:(UIView *(^)(FBNativeAd *, NSUInteger))childViewProvider withMaximum:(NSUInteger)maximumNativeAdCount;
		[DesignatedInitializer]
		[Export ("initWithNativeAdsManager:withViewProvider:withMaximum:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdScrollViewViewProviderHandler childViewProviderHandler, nuint maximumNativeAdCount);
	}

	interface INativeAdsManagerDelegate { }

	// @protocol FBNativeAdsManagerDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBNativeAdsManagerDelegate")]
	interface NativeAdsManagerDelegate {
		// @required -(void)nativeAdsLoaded;
		[Abstract]
		[Export ("nativeAdsLoaded")]
		void NativeAdsLoaded ();

		// @required -(void)nativeAdsFailedToLoadWithError:(NSError *)error;
		[Abstract]
		[Export ("nativeAdsFailedToLoadWithError:")]
		void NativeAdsFailedToLoad (NSError error);
	}

	// @interface FBNativeAdsManager : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBNativeAdsManager")]
	interface NativeAdsManager
	{
		// @property (nonatomic, weak) id<FBNativeAdsManagerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdsManagerDelegate Delegate { get; set; }

		// @property (assign, nonatomic) FBNativeAdsCachePolicy mediaCachePolicy;
		[Export ("mediaCachePolicy", ArgumentSemantic.Assign)]
		NativeAdsCachePolicy MediaCachePolicy { get; set; }

		// @property (readonly, assign, nonatomic) NSUInteger uniqueNativeAdCount;
		[Export ("uniqueNativeAdCount", ArgumentSemantic.Assign)]
		nuint UniqueNativeAdCount { get; }

		// @property (readonly, getter = isValid, assign, nonatomic) BOOL valid;
		[Export ("valid")]
		bool Valid { [Bind ("isValid")] get; }

		// @property (nonatomic, strong) FBAdExtraHint * _Nullable extraHint;
		[NullAllowed]
		[Export ("extraHint", ArgumentSemantic.Strong)]
		AdExtraHint ExtraHint { get; set; }

		// -(instancetype)initWithPlacementID:(NSString *)placementID forNumAdsRequested:(NSUInteger)numAdsRequested;
		[DesignatedInitializer]
		[Export ("initWithPlacementID:forNumAdsRequested:")]
		IntPtr Constructor (string placementId, nuint numAdsRequested);

		// -(void)loadAds;
		[Export ("loadAds")]
		void LoadAds ();

		// -(void)disableAutoRefresh;
		[Export ("disableAutoRefresh")]
		void DisableAutoRefresh ();

		// -(FBNativeAd *)nextNativeAd;
		[Export ("nextNativeAd", ArgumentSemantic.Strong)]
		[NullAllowed]
		NativeAd NextNativeAd { get; }
	}

	// @interface FBNativeAdTableViewAdProvider : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBNativeAdTableViewAdProvider")]
	interface NativeAdTableViewAdProvider {
		// @property (nonatomic, weak) id<FBNativeAdDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		// @property (nonatomic, strong) FBAdExtraHint * _Nullable extraHint;
		[NullAllowed]
		[Export ("extraHint", ArgumentSemantic.Strong)]
		AdExtraHint ExtraHint { get; set; }

		// -(instancetype)initWithManager:(FBNativeAdsManager *)manager;
		[DesignatedInitializer]
		[Export ("initWithManager:")]
		IntPtr Constructor (NativeAdsManager manager);

		// -(FBNativeAd *)tableView:(UITableView *)tableView nativeAdForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:nativeAdForRowAtIndexPath:")]
		NativeAd GetNativeAd (UITableView tableView, NSIndexPath indexPath);

		// -(BOOL)isAdCellAtIndexPath:(NSIndexPath *)indexPath forStride:(NSUInteger)stride;
		[Export ("isAdCellAtIndexPath:forStride:")]
		bool IsAdCell (NSIndexPath indexPath, nuint stride);

		// -(NSIndexPath *)adjustNonAdCellIndexPath:(NSIndexPath *)indexPath forStride:(NSUInteger)stride;
		[return: NullAllowed]
		[Export ("adjustNonAdCellIndexPath:forStride:")]
		NSIndexPath AdjustNonAdCell (NSIndexPath indexPath, nuint stride);

		// -(NSUInteger)adjustCount:(NSUInteger)count forStride:(NSUInteger)stride;
		[Export ("adjustCount:forStride:")]
		nuint AdjustCount (nuint count, nuint stride);
	}

	// @interface FBNativeAdTableViewCellProvider : FBNativeAdTableViewAdProvider
	[DisableDefaultCtor]
	[BaseType (typeof (NativeAdTableViewAdProvider), Name = "FBNativeAdTableViewCellProvider")]
	interface NativeAdTableViewCellProvider : IUITableViewDataSource
	{

		// -(instancetype)initWithManager:(FBNativeAdsManager *)manager forType:(FBNativeAdViewType)type;
		[Export ("initWithManager:forType:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type);

		// -(instancetype)initWithManager:(FBNativeAdsManager *)manager forType:(FBNativeAdViewType)type forAttributes:(FBNativeAdViewAttributes *)attributes;
		[DesignatedInitializer]
		[Export ("initWithManager:forType:forAttributes:")]
		IntPtr Constructor (NativeAdsManager manager, NativeAdViewType type, NativeAdViewAttributes attributes);

		// -(UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:cellForRowAtIndexPath:")]
		new UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath);

		// -(CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:heightForRowAtIndexPath:")]
		nfloat GetHeight (UITableView tableView, NSIndexPath indexPath);

		// -(CGFloat)tableView:(UITableView *)tableView estimatedHeightForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:estimatedHeightForRowAtIndexPath:")]
		nfloat GetEstimateHeight (UITableView tableView, NSIndexPath indexPath);
	}

	// @interface FBNativeAdView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (NativeAdBaseView), Name = "FBNativeAdView")]
	interface NativeAdView
	{
		// @property (readonly, assign, nonatomic) FBNativeAdViewType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NativeAdViewType Type { get; }

		// +(instancetype)nativeAdViewWithNativeAd:(FBNativeAd *)nativeAd withType:(FBNativeAdViewType)type;
		[Static]
		[Export ("nativeAdViewWithNativeAd:withType:")]
		NativeAdView From (NativeAd nativeAd, NativeAdViewType type);

		// +(instancetype)nativeAdViewWithNativeAd:(FBNativeAd *)nativeAd withType:(FBNativeAdViewType)type withAttributes:(FBNativeAdViewAttributes *)attributes;
		[Static]
		[Export ("nativeAdViewWithNativeAd:withType:withAttributes:")]
		NativeAdView From (NativeAd nativeAd, NativeAdViewType type, NativeAdViewAttributes attributes);
	}

	// @interface FBNativeAdViewAttributes : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "FBNativeAdViewAttributes")]
	interface NativeAdViewAttributes : INSCopying
	{
		// - (nonnull instancetype)initWithDictionary:(nonnull NSDictionary *) dict;
		[Export ("initWithDictionary:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (copy, nonatomic) UIColor * backgroundColor;
		[NullAllowed]
		[Export ("backgroundColor", ArgumentSemantic.Copy)]
		UIColor BackgroundColor { get; set; }

		// @property (copy, nonatomic) UIColor * titleColor;
		[NullAllowed]
		[Export ("titleColor", ArgumentSemantic.Copy)]
		UIColor TitleColor { get; set; }

		// @property (copy, nonatomic) UIFont * titleFont;
		[NullAllowed]
		[Export ("titleFont", ArgumentSemantic.Copy)]
		UIFont TitleFont { get; set; }

		// @property (copy, nonatomic) UIColor * descriptionColor;
		[NullAllowed]
		[Export ("descriptionColor", ArgumentSemantic.Copy)]
		UIColor DescriptionColor { get; set; }

		// @property (copy, nonatomic) UIFont * descriptionFont;
		[NullAllowed]
		[Export ("descriptionFont", ArgumentSemantic.Copy)]
		UIFont DescriptionFont { get; set; }

		// @property (copy, nonatomic) UIColor * buttonColor;
		[NullAllowed]
		[Export ("buttonColor", ArgumentSemantic.Copy)]
		UIColor ButtonColor { get; set; }

		// @property (copy, nonatomic) UIColor * buttonTitleColor;
		[NullAllowed]
		[Export ("buttonTitleColor", ArgumentSemantic.Copy)]
		UIColor ButtonTitleColor { get; set; }

		// @property (copy, nonatomic) UIFont * buttonTitleFont;
		[NullAllowed]
		[Export ("buttonTitleFont", ArgumentSemantic.Copy)]
		UIFont ButtonTitleFont { get; set; }

		// @property (copy, nonatomic) UIColor * buttonBorderColor;
		[Export ("buttonBorderColor", ArgumentSemantic.Copy)]
		UIColor ButtonBorderColor { get; set; }

		// @property (nonatomic, assign, getter=isAutoplayEnabled) BOOL autoplayEnabled;
		[Export ("autoplayEnabled")]
		bool AutoplayEnabled { [Bind ("isAutoplayEnabled")] get; set; }

		////////////////////////////////////////////////////////////////////////
		// From @interface FBNativeAdView (FBNativeAdViewAttributes) Category //
		////////////////////////////////////////////////////////////////////////

		// +(instancetype)defaultAttributesForType:(FBNativeAdViewType)type;
		[Static]
		[Export ("defaultAttributesForType:")]
		NativeAdViewAttributes DefaultAttributes (NativeAdViewType type);
	}

	// @interface FBNativeBannerAd : FBNativeAdBase
	[BaseType (typeof (NativeAdBase), Name = "FBNativeBannerAd")]
	interface NativeBannerAd {
		// @property (nonatomic, weak) id<FBNativeBannerAdDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeBannerAdDelegate Delegate { get; set; }

		// -(instancetype _Nonnull)initWithPlacementID:(NSString * _Nonnull)placementID;
		[Export ("initWithPlacementID:")]
		IntPtr Constructor (string placementId);

		// -(void)registerViewForInteraction:(UIView * _Nonnull)view iconView:(FBAdIconView * _Nonnull)iconView viewController:(UIViewController * _Nullable)viewController;
		[Export ("registerViewForInteraction:iconView:viewController:")]
		void RegisterView (UIView view, AdIconView iconView, [NullAllowed] UIViewController viewController);

		// -(void)registerViewForInteraction:(UIView * _Nonnull)view iconView:(FBAdIconView * _Nonnull)iconView viewController:(UIViewController * _Nullable)viewController clickableViews:(NSArray<UIView *> * _Nullable)clickableViews;
		[Export ("registerViewForInteraction:iconView:viewController:clickableViews:")]
		void RegisterView (UIView view, AdIconView iconView, [NullAllowed] UIViewController viewController, [NullAllowed] UIView [] clickableViews);

		// -(void)downloadMedia;
		[Export ("downloadMedia")]
		void DownloadMedia ();
	}

	interface INativeBannerAdDelegate { }

	// @protocol FBNativeBannerAdDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBNativeBannerAdDelegate")]
	interface NativeBannerAdDelegate {
		// @optional -(void)nativeBannerAdDidLoad:(FBNativeBannerAd * _Nonnull)nativeBannerAd;
		[Export ("nativeBannerAdDidLoad:")]
		void NativeBannerAdDidLoad (NativeBannerAd nativeBannerAd);

		// @optional -(void)nativeBannerAdDidDownloadMedia:(FBNativeBannerAd * _Nonnull)nativeBannerAd;
		[Export ("nativeBannerAdDidDownloadMedia:")]
		void NativeBannerAdDidDownloadMedia (NativeBannerAd nativeBannerAd);

		// @optional -(void)nativeBannerAdWillLogImpression:(FBNativeBannerAd * _Nonnull)nativeBannerAd;
		[Export ("nativeBannerAdWillLogImpression:")]
		void NativeBannerAdWillLogImpression (NativeBannerAd nativeBannerAd);

		// @optional -(void)nativeBannerAd:(FBNativeBannerAd * _Nonnull)nativeBannerAd didFailWithError:(NSError * _Nonnull)error;
		[Export ("nativeBannerAd:didFailWithError:")]
		void NativeBannerAdDidFail (NativeBannerAd nativeBannerAd, NSError error);

		// @optional -(void)nativeBannerAdDidClick:(FBNativeBannerAd * _Nonnull)nativeBannerAd;
		[Export ("nativeBannerAdDidClick:")]
		void NativeBannerAdDidClick (NativeBannerAd nativeBannerAd);

		// @optional -(void)nativeBannerAdDidFinishHandlingClick:(FBNativeBannerAd * _Nonnull)nativeBannerAd;
		[Export ("nativeBannerAdDidFinishHandlingClick:")]
		void NativeBannerAdDidFinishHandlingClick (NativeBannerAd nativeBannerAd);
	}

	// @interface FBNativeBannerAdView : FBNativeAdBaseView
	[BaseType (typeof (NativeAdBaseView), Name = "FBNativeBannerAdView")]
	[DisableDefaultCtor]
	interface NativeBannerAdView {
		// @property (readonly, assign, nonatomic) FBNativeBannerAdViewType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NativeBannerAdViewType Type { get; }

		// +(instancetype _Nonnull)nativeBannerAdViewWithNativeBannerAd:(FBNativeBannerAd * _Nonnull)nativeBannerAd withType:(FBNativeBannerAdViewType)type;
		[Static]
		[Export ("nativeBannerAdViewWithNativeBannerAd:withType:")]
		NativeBannerAdView From (NativeBannerAd nativeBannerAd, NativeBannerAdViewType type);

		// +(instancetype _Nonnull)nativeBannerAdViewWithNativeBannerAd:(FBNativeBannerAd * _Nonnull)nativeBannerAd withType:(FBNativeBannerAdViewType)type withAttributes:(FBNativeAdViewAttributes * _Nonnull)attributes;
		[Static]
		[Export ("nativeBannerAdViewWithNativeBannerAd:withType:withAttributes:")]
		NativeBannerAdView From (NativeBannerAd nativeBannerAd, NativeBannerAdViewType type, NativeAdViewAttributes attributes);

		//////////////////////////////////////////////////////////////////////////////
		// From @interface FBNativeBannerAdView (FBNativeAdViewAttributes) Category //
		//////////////////////////////////////////////////////////////////////////////

		// +(instancetype _Nonnull)defaultAttributesForBannerType:(FBNativeBannerAdViewType)type;
		[Static]
		[Export ("defaultAttributesForBannerType:")]
		NativeAdViewAttributes Create (NativeBannerAdViewType type);
	}

	// @interface FBRewardedVideoAd : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBRewardedVideoAd")]
	interface RewardedVideoAd
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull placementID;
		[Export ("placementID")]
		string PlacementId { get; }

		[Obsolete ("Use PlacementId property instead. This will be removed in future versions.")]
		[Wrap ("PlacementId")]
		string PlacementID { get; }

		// @property (readonly, assign, nonatomic) CMTime duration;
		[Export ("duration", ArgumentSemantic.Assign)]
		CMTime Duration { get; }

		// @property (nonatomic, weak) id<FBRewardedVideoAdDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IRewardedVideoAdDelegate Delegate { get; set; }

		// @property (readonly, getter = isAdValid, nonatomic) BOOL adValid;
		[Export ("adValid")]
		bool AdValid { [Bind ("isAdValid")] get; }

		// @property (nonatomic, strong) FBAdExtraHint * _Nullable extraHint;
		[NullAllowed]
		[Export ("extraHint", ArgumentSemantic.Strong)]
		AdExtraHint ExtraHint { get; set; }

		// -(instancetype _Nonnull)initWithPlacementID:(NSString * _Nonnull)placementID;
		[Export ("initWithPlacementID:")]
		IntPtr Constructor (string placementId);

		// -(instancetype _Nonnull)initWithPlacementID:(NSString * _Nonnull)placementID withUserID:(NSString * _Nullable)userID withCurrency:(NSString * _Nullable)currency;
		[Export ("initWithPlacementID:withUserID:withCurrency:")]
		IntPtr Constructor (string placementId, [NullAllowed] string userId, [NullAllowed] string currency);

		// -(void)loadAd;
		[Export ("loadAd")]
		void LoadAd ();

		// - (void) loadAdWithBidPayload:(NSString*) bidPayload;
		[Export ("loadAdWithBidPayload:")]
		void LoadAd (string bidPayload);

		// - (BOOL)setRewardDataWithUserID:(NSString *)userID withCurrency:(NSString*) currency;
		[Export ("setRewardDataWithUserID:withCurrency:")]
		bool SetRewardData (string userId, string currency);

		// -(BOOL)showAdFromRootViewController:(UIViewController * _Nonnull)rootViewController;
		[Export ("showAdFromRootViewController:")]
		bool ShowAd (UIViewController rootViewController);

		// -(BOOL)showAdFromRootViewController:(UIViewController * _Nonnull)rootViewController animated:(BOOL)flag;
		[Export ("showAdFromRootViewController:animated:")]
		bool ShowAd (UIViewController rootViewController, bool flag);
	}

	interface IRewardedVideoAdDelegate { }

	// @protocol FBRewardedVideoAdDelegate <NSObject>
	[Model (AutoGeneratedName = true)]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBRewardedVideoAdDelegate")]
	interface RewardedVideoAdDelegate
	{
		// @optional -(void)rewardedVideoAdDidClick:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdDidClick:")]
		void RewardedVideoAdDidClick (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdDidLoad:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdDidLoad:")]
		void RewardedVideoAdDidLoad (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdDidClose:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdDidClose:")]
		void RewardedVideoAdDidClose (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdWillClose:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdWillClose:")]
		void RewardedVideoAdWillClose (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAd:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd didFailWithError:(NSError * _Nonnull)error;
		[Export ("rewardedVideoAd:didFailWithError:")]
		void RewardedVideoAdDidFail (RewardedVideoAd rewardedVideoAd, NSError error);

		// @optional -(void)rewardedVideoAdVideoComplete:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdVideoComplete:")]
		void RewardedVideoAdVideoComplete (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdWillLogImpression:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdWillLogImpression:")]
		void RewardedVideoAdWillLogImpression (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdServerSuccess:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdServerRewardDidSucceed:")]
		void RewardedVideoAdServerRewardDidSuccess (RewardedVideoAd rewardedVideoAd);

		// @optional -(void)rewardedVideoAdServerFailed:(FBRewardedVideoAd * _Nonnull)rewardedVideoAd;
		[Export ("rewardedVideoAdServerRewardDidFail:")]
		void RewardedVideoAdServerRewardDidFail (RewardedVideoAd rewardedVideoAd);
	}

	// @interface FBNativeAdViewTag (UIView)
	[Category]
	[BaseType (typeof (UIView))]
	interface UIView_NativeAdViewTag {
		// @property (assign, nonatomic) FBNativeAdViewTag nativeAdViewTag;
		[Export ("nativeAdViewTag")]
		NativeAdViewTag GetNativeAdViewTag ();

		[Export ("setNativeAdViewTag:")]
		void SetNativeAdViewTag (NativeAdViewTag nativeAdViewTag);
	}
}
