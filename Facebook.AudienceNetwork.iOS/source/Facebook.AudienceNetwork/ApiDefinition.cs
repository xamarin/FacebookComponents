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

namespace Facebook.AudienceNetwork
{

	// @interface FBAdChoicesView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBAdChoicesView")]
	interface AdChoicesView
	{

		// @property (readonly, nonatomic, weak) UILabel * label;
		[Export ("label", ArgumentSemantic.Weak)]
		UILabel Label { get; }

		// @property (getter = isBackgroundShown, assign, nonatomic) BOOL backgroundShown;
		[Export ("backgroundShown")]
		bool BackgroundShown { [Bind ("isBackgroundShown")] get; set; }

		// @property (nonatomic, assign, readonly, getter=isExpandable) BOOL expandable;
		[Export ("expandable")]
		bool Expandable { [Bind ("isExpandable")] get; set; }

		// @property (nonatomic, weak, readwrite) FBNativeAd *nativeAd;
		[Export ("nativeAd", ArgumentSemantic.Weak)]
		[NullAllowed]
		NativeAd NativeAd { get; set; }

		// @property (nonatomic, assign, readwrite) UIRectCorner corner;
		[Export ("corner", ArgumentSemantic.Assign)]
		UIRectCorner Corner { get; set; }

		// @property (nonatomic, weak, readwrite, nullable) UIViewController *viewController;
		[NullAllowed]
		[Export ("viewController", ArgumentSemantic.Weak)]
		UIViewController ViewController { get; set; }

		// -(instancetype)initWithNativeAd:(FBNativeAd *)nativeAd;
		[Export ("initWithNativeAd:")]
		IntPtr Constructor (NativeAd nativeAd);

		// - (nonnull instancetype)initWithNativeAd:(nonnull FBNativeAd *)nativeAd expandable:(BOOL)expandable;
		[Export ("initWithNativeAd:expandable:")]
		IntPtr Constructor (NativeAd nativeAd, bool expandable);

		// -(instancetype)initWithViewController:(UIViewController *)viewController adChoicesIcon:(FBAdImage *)adChoicesIcon adChoicesLinkURL:(NSURL *)adChoicesLinkURL attributes:(FBNativeAdViewAttributes *)attributes __attribute__((objc_designated_initializer));
		[Export ("initWithViewController:adChoicesIcon:adChoicesLinkURL:attributes:")]
		IntPtr Constructor ([NullAllowed] UIViewController viewController, AdImage adChoicesIcon, NSUrl adChoicesLinkURL, [NullAllowed] NativeAdViewAttributes attributes);

		// -(instancetype)initWithViewController:(UIViewController *)viewController adChoicesIcon:(FBAdImage *)adChoicesIcon adChoicesLinkURL:(NSURL *)adChoicesLinkURL attributes:(FBNativeAdViewAttributes *)attributes expandable:(BOOL)expandable __attribute__((objc_designated_initializer));
		[Export ("initWithViewController:adChoicesIcon:adChoicesLinkURL:attributes:expandable:")]
		IntPtr Constructor ([NullAllowed] UIViewController viewController, AdImage adChoicesIcon, NSUrl adChoicesLinkURL, [NullAllowed] NativeAdViewAttributes attributes, bool expandable);

		// -(instancetype)initWithViewController:(UIViewController *)viewController adChoicesIcon:(FBAdImage *)adChoicesIcon adChoicesLinkURL:(NSURL *)adChoicesLinkURL adChoicesText:(nullable NSString*)adChoicesText attributes:(FBNativeAdViewAttributes *)attributes expandable:(BOOL)expandable __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithViewController:adChoicesIcon:adChoicesLinkURL:adChoicesText:attributes:expandable:")]
		IntPtr Constructor ([NullAllowed] UIViewController viewController, AdImage adChoicesIcon, NSUrl adChoicesLinkURL, [NullAllowed] string adChoicesText, [NullAllowed] NativeAdViewAttributes attributes, bool expandable);

		// -(void)updateFrameFromSuperview;
		[Export ("updateFrameFromSuperview")]
		void UpdateFrameFromSuperview ();

		// -(void)updateFrameFromSuperview:(UIRectCorner)corner;
		[Export ("updateFrameFromSuperview:")]
		void UpdateFrameFromSuperview (UIRectCorner corner);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBAdSettings")]
	interface AdSettings
	{

		[Field ("FBAudienceNetworkErrorDomain", "__Internal")]
		NSString AdsErrorDomain { get; }

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
		[Export ("setIsChildDirected:")]
		void SetIsChildDirected (bool isChildDirected);

		[Static]
		[Export ("setUrlPrefix:")]
		void SetUrlPrefix (string urlPrefix);

		// + (void)setMediationService:(NSString *)service;
		[Static]
		[Export ("setMediationService:")]
		void SetMediationService (string service);

		// +(FBAdLogLevel)getLogLevel;
		// +(void)setLogLevel:(FBAdLogLevel)level;
		[Static]
		[Export ("logLevel")]
		AdLogLevel LogLevel { [Bind ("getLogLevel")] get; set; }
	}

	[Static]
	interface AdSizes
	{
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

	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBAdView")]
	interface AdView
	{

		[DesignatedInitializer]
		[Export ("initWithPlacementID:adSize:rootViewController:")]
		IntPtr Constructor (string placementID, AdSize adSize, [NullAllowed] UIViewController viewController);

		[Export ("loadAd")]
		void LoadAd ();

		[Export ("placementID")]
		string PlacementId { get; }

		[NullAllowed]
		[Export ("rootViewController", ArgumentSemantic.Weak)]
		UIViewController RootViewController { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAdViewDelegate Delegate { get; set; }

	}

	interface IAdViewDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "FBAdViewDelegate")]
	interface AdViewDelegate
	{

		[Export ("adViewDidClick:")]
		void AdViewDidClick (AdView adView);

		[Export ("adViewDidFinishHandlingClick:")]
		void AdViewDidFinishHandlingClick (AdView adView);

		[Export ("adViewDidLoad:")]
		void AdViewDidLoad (AdView adView);

		[Export ("adView:didFailWithError:")]
		void AdViewDidFail (AdView adView, NSError error);

		[Export ("viewControllerForPresentingModalView", ArgumentSemantic.Strong)]
		UIViewController ViewControllerForPresentingModalView { get; }
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBInterstitialAd")]
	interface InterstitialAd
	{

		[Export ("placementID")]
		string PlacementId { get; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IInterstitialAdDelegate Delegate { get; set; }

		[Export ("initWithPlacementID:")]
		[DesignatedInitializer]
		IntPtr Constructor (string placementId);

		[Export ("isAdValid")]
		bool IsAdValid { get; }

		[PostGet ("IsAdValid")]
		[Export ("loadAd")]
		void LoadAd ();

		[Export ("showAdFromRootViewController:")]
		bool ShowAdFromRootViewController ([NullAllowed] UIViewController rootViewController);
	}

	interface IInterstitialAdDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "FBInterstitialAdDelegate")]
	interface InterstitialAdDelegate
	{

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
	}

	// @interface FBMediaView : UIView
	[BaseType (typeof (UIView), Name = "FBMediaView")]
	interface MediaView
	{
		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		// @property (nonatomic, weak) id<FBMediaViewDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IMediaViewDelegate Delegate { get; set; }

		// -(instancetype)initWithNativeAd:(FBNativeAd *)nativeAd;
		[Export ("initWithNativeAd:")]
		IntPtr Constructor (NativeAd nativeAd);

		// @property (nonatomic, strong) FBNativeAd * nativeAd;
		[Export ("nativeAd", ArgumentSemantic.Strong)]
		NativeAd NativeAd { get; set; }

		// @property (nonatomic, assign, getter=isAutoplayEnabled) BOOL autoplayEnabled;
		[Export ("autoplayEnabled")]
		bool AutoplayEnabled { [Bind ("isAutoplayEnabled")] get; set; }
	}

	interface IMediaViewDelegate
	{

	}

	// @protocol FBMediaViewDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBMediaViewDelegate")]
	interface MediaViewDelegate
	{
		// @optional -(void)mediaViewDidLoad:(FBMediaView *)mediaView;
		[Export ("mediaViewDidLoad:")]
		void MediaViewDidLoad (MediaView mediaView);
	}

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBNativeAd")]
	interface NativeAd
	{

		[Export ("placementID")]
		string PlacementId { get; }

		[Obsolete]
		[Export ("starRating", ArgumentSemantic.Assign)]
		AdStarRating StarRating { get; }

		[Export ("title")]
		string Title { get; }

		[Export ("subtitle")]
		string Subtitle { get; }

		[Export ("socialContext")]
		string SocialContext { get; }

		[Export ("callToAction")]
		string CallToAction { get; }

		[Export ("icon", ArgumentSemantic.Retain)]
		AdImage Icon { get; }

		[Export ("coverImage", ArgumentSemantic.Retain)]
		AdImage CoverImage { get; }

		[Export ("body")]
		string Body { get; }

		[Export ("mediaCachePolicy", ArgumentSemantic.Assign)]
		NativeAdsCachePolicy MediaCachePolicy { get; set; }

		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

		[DesignatedInitializer]
		[Export ("initWithPlacementID:")]
		IntPtr Constructor (string placementId);

		[Export ("registerViewForInteraction:withViewController:")]
		void RegisterView (UIView view, [NullAllowed] UIViewController viewController);

		[Export ("registerViewForInteraction:withViewController:withClickableViews:")]
		void RegisterView (UIView view, [NullAllowed] UIViewController viewController, UIView [] clickableViews);

		[Export ("unregisterView")]
		void UnregisterView ();

		[PostGet ("IsAdValid")]
		[Export ("loadAd")]
		void LoadAd ();

		[Export ("isAdValid")]
		bool IsAdValid { get; }

		[Export ("getAdNetwork", ArgumentSemantic.Copy)]
		[NullAllowed]
		string AdNetwork { get; }
	}

	interface INativeAdDelegate
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof (NSObject), Name = "FBNativeAdDelegate")]
	interface NativeAdDelegate
	{

		[Export ("nativeAdDidLoad:")]
		[Abstract]
		void NativeAdDidLoad (NativeAd nativeAd);

		[Export ("nativeAd:didFailWithError:")]
		[Abstract]
		void NativeAdDidFail (NativeAd nativeAd, NSError error);

		[Export ("nativeAdDidClick:")]
		[Abstract]
		void NativeAdDidClick (NativeAd nativeAd);

		[Export ("nativeAdDidFinishHandlingClick:")]
		[Abstract]
		void NativeAdDidFinishHandlingClick (NativeAd nativeAd);

		[Export("nativeAdWillLogImpression:")]
		[Abstract]
		void NativeAdWillLogImpression(NativeAd nativeAd);
	}

	delegate void AdImageCompletionHandler ([NullAllowed] UIImage imageLoaded);

	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBAdImage")]
	interface AdImage
	{

		[Export ("url", ArgumentSemantic.Copy)]
		NSUrl Url { get; }

		[Export ("width", ArgumentSemantic.Assign)]
		nint Width { get; }

		[Export ("height", ArgumentSemantic.Assign)]
		nint Height { get; }

		[Export ("initWithURL:width:height:")]
		IntPtr Constructor (NSUrl url, nint width, nint height);

		// -(void)loadImageAsyncWithBlock:(void (^)(UIImage *))block;
		[Export ("loadImageAsyncWithBlock:")]
		void LoadImageAsync (AdImageCompletionHandler completionHandler);
	}

	// @interface FBAdStarRatingView : UIView
	[Obsolete]
	[BaseType (typeof (UIView), Name = "FBAdStarRatingView")]
	interface AdStarRatingView
	{

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

	delegate UIView NativeAdScrollViewViewProviderHandler (NativeAd nativeAd, nuint position);

	// @interface FBNativeAdScrollView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBNativeAdScrollView")]
	interface NativeAdScrollView
	{
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
		[Export ("viewController", ArgumentSemantic.Weak)]
		UIViewController ViewController { get; set; }

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

	interface INativeAdsManagerDelegate
	{

	}

	// @protocol FBNativeAdsManagerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBNativeAdsManagerDelegate")]
	interface NativeAdsManagerDelegate
	{
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

		// -(instancetype)initWithPlacementID:(NSString *)placementID forNumAdsRequested:(NSUInteger)numAdsRequested;
		[DesignatedInitializer]
		[Export ("initWithPlacementID:forNumAdsRequested:")]
		IntPtr Constructor (string placementID, nuint numAdsRequested);

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
	interface NativeAdTableViewAdProvider
	{
		// @property (nonatomic, weak) id<FBNativeAdDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

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
		UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath);

		// -(CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:heightForRowAtIndexPath:")]
		nfloat GetHeight (UITableView tableView, NSIndexPath indexPath);

		// -(CGFloat)tableView:(UITableView *)tableView estimatedHeightForRowAtIndexPath:(NSIndexPath *)indexPath;
		[Export ("tableView:estimatedHeightForRowAtIndexPath:")]
		nfloat GetEstimateHeight (UITableView tableView, NSIndexPath indexPath);
	}

	// @interface FBNativeAdView : UIView
	[DisableDefaultCtor]
	[BaseType (typeof (UIView), Name = "FBNativeAdView")]
	interface NativeAdView
	{
		// @property (readonly, assign, nonatomic) FBNativeAdViewType type;
		[Export ("type", ArgumentSemantic.Assign)]
		NativeAdViewType Type { get; }

		// +(instancetype)nativeAdViewWithNativeAd:(FBNativeAd *)nativeAd withType:(FBNativeAdViewType)type;
		[Static]
		[Export ("nativeAdViewWithNativeAd:withType:")]
		NativeAdView From (NativeAd nativeAd, NativeAdViewType type);

		// @property (nonatomic, weak) UIViewController * viewController;
		[NullAllowed]
		[Export ("viewController", ArgumentSemantic.Weak)]
		UIViewController ViewController { get; set; }

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

		// +(instancetype)defaultAttributesForType:(FBNativeAdViewType)type;
		[Static]
		[Export ("defaultAttributesForType:")]
		NativeAdViewAttributes DefaultAttributes (NativeAdViewType type);
	}

	// @interface FBNativeAdCollectionViewAdProvider : NSObject
	[BaseType (typeof (NSObject), Name = "FBNativeAdCollectionViewAdProvider")]
	interface NativeAdCollectionViewAdProvider
	{
		// @property (nonatomic, weak) id<FBNativeAdDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		INativeAdDelegate Delegate { get; set; }

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
		[Export ("adjustNonAdCellIndexPath:forStride:")]
		NSIndexPath AdjustNonAdCellIndexPath (NSIndexPath indexPath, nuint stride);

		// -(NSUInteger)adjustCount:(NSUInteger)count forStride:(NSUInteger)stride;
		[Export ("adjustCount:forStride:")]
		nuint AdjustCount (nuint count, nuint stride);
	}

	// @interface FBNativeAdCollectionViewCellProvider : FBNativeAdCollectionViewAdProvider
	[BaseType (typeof (NativeAdCollectionViewAdProvider), Name = "FBNativeAdCollectionViewCellProvider")]
	interface NativeAdCollectionViewCellProvider
	{
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
}