//
// StructsAndEnums.cs: Bindings to the Facebook iOS SDK.
//
//	Authors:
//		Miguel de Icaza (miguel@xamarin.com)
//		Alex Soto 	(alex.soto@xamarin.com)
//		Israel Soto 	(israel.soto@xamarin.com)
//

using ObjCRuntime;
using Foundation;

namespace Facebook.AudienceNetwork
{
	public enum AdExtraHintKeyword {
		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordAccessories;
		[Field ("FBAdExtraHintKeywordAccessories", "__Internal")]
		Accessories,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordArtHistory;
		[Field ("FBAdExtraHintKeywordArtHistory", "__Internal")]
		ArtHistory,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordAutomotive;
		[Field ("FBAdExtraHintKeywordAutomotive", "__Internal")]
		Automotive,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBeauty;
		[Field ("FBAdExtraHintKeywordBeauty", "__Internal")]
		Beauty,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBiology;
		[Field ("FBAdExtraHintKeywordBiology", "__Internal")]
		Biology,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBoardGames;
		[Field ("FBAdExtraHintKeywordBoardGames", "__Internal")]
		BoardGames,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBusinessSoftware;
		[Field ("FBAdExtraHintKeywordBusinessSoftware", "__Internal")]
		BusinessSoftware,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordBuyingSellingHomes;
		[Field ("FBAdExtraHintKeywordBuyingSellingHomes", "__Internal")]
		BuyingSellingHomes,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordCats;
		[Field ("FBAdExtraHintKeywordCats", "__Internal")]
		Cats,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordCelebrities;
		[Field ("FBAdExtraHintKeywordCelebrities", "__Internal")]
		Celebrities,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordClothing;
		[Field ("FBAdExtraHintKeywordClothing", "__Internal")]
		Clothing,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordComicBooks;
		[Field ("FBAdExtraHintKeywordComicBooks", "__Internal")]
		ComicBooks,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordDesktopVideo;
		[Field ("FBAdExtraHintKeywordDesktopVideo", "__Internal")]
		DesktopVideo,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordDogs;
		[Field ("FBAdExtraHintKeywordDogs", "__Internal")]
		Dogs,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordEducation;
		[Field ("FBAdExtraHintKeywordEducation", "__Internal")]
		Education,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordEmail;
		[Field ("FBAdExtraHintKeywordEmail", "__Internal")]
		Email,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordEntertainment;
		[Field ("FBAdExtraHintKeywordEntertainment", "__Internal")]
		Entertainment,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFamilyParenting;
		[Field ("FBAdExtraHintKeywordFamilyParenting", "__Internal")]
		FamilyParenting,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFashion;
		[Field ("FBAdExtraHintKeywordFashion", "__Internal")]
		Fashion,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFineArt;
		[Field ("FBAdExtraHintKeywordFineArt", "__Internal")]
		FineArt,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFoodDrink;
		[Field ("FBAdExtraHintKeywordFoodDrink", "__Internal")]
		FoodDrink,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordFrenchCuisine;
		[Field ("FBAdExtraHintKeywordFrenchCuisine", "__Internal")]
		FrenchCuisine,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordGovernment;
		[Field ("FBAdExtraHintKeywordGovernment", "__Internal")]
		Government,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordHealthFitness;
		[Field ("FBAdExtraHintKeywordHealthFitness", "__Internal")]
		HealthFitness,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordHobbies;
		[Field ("FBAdExtraHintKeywordHobbies", "__Internal")]
		Hobbies,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordHomeGarden;
		[Field ("FBAdExtraHintKeywordHomeGarden", "__Internal")]
		HomeGarden,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordHumor;
		[Field ("FBAdExtraHintKeywordHumor", "__Internal")]
		Humor,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordInternetTechnology;
		[Field ("FBAdExtraHintKeywordInternetTechnology", "__Internal")]
		InternetTechnology,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordLargeAnimals;
		[Field ("FBAdExtraHintKeywordLargeAnimals", "__Internal")]
		LargeAnimals,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordLaw;
		[Field ("FBAdExtraHintKeywordLaw", "__Internal")]
		Law,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordLegalIssues;
		[Field ("FBAdExtraHintKeywordLegalIssues", "__Internal")]
		LegalIssues,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordLiterature;
		[Field ("FBAdExtraHintKeywordLiterature", "__Internal")]
		Literature,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordMarketing;
		[Field ("FBAdExtraHintKeywordMarketing", "__Internal")]
		Marketing,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordMovies;
		[Field ("FBAdExtraHintKeywordMovies", "__Internal")]
		Movies,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordMusic;
		[Field ("FBAdExtraHintKeywordMusic", "__Internal")]
		Music,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordNews;
		[Field ("FBAdExtraHintKeywordNews", "__Internal")]
		News,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordPersonalFinance;
		[Field ("FBAdExtraHintKeywordPersonalFinance", "__Internal")]
		PersonalFinance,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordPets;
		[Field ("FBAdExtraHintKeywordPets", "__Internal")]
		Pets,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordPhotography;
		[Field ("FBAdExtraHintKeywordPhotography", "__Internal")]
		Photography,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordPolitics;
		[Field ("FBAdExtraHintKeywordPolitics", "__Internal")]
		Politics,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordRealEstate;
		[Field ("FBAdExtraHintKeywordRealEstate", "__Internal")]
		RealEstate,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordRoleplayingGames;
		[Field ("FBAdExtraHintKeywordRoleplayingGames", "__Internal")]
		RoleplayingGames,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordScience;
		[Field ("FBAdExtraHintKeywordScience", "__Internal")]
		Science,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordShopping;
		[Field ("FBAdExtraHintKeywordShopping", "__Internal")]
		Shopping,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordSociety;
		[Field ("FBAdExtraHintKeywordSociety", "__Internal")]
		Society,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordSports;
		[Field ("FBAdExtraHintKeywordSports", "__Internal")]
		Sports,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordTechnology;
		[Field ("FBAdExtraHintKeywordTechnology", "__Internal")]
		Technology,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordTelevision;
		[Field ("FBAdExtraHintKeywordTelevision", "__Internal")]
		Television,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordTravel;
		[Field ("FBAdExtraHintKeywordTravel", "__Internal")]
		Travel,

		// extern const FBAdExtraHintKeyword _Nonnull FBAdExtraHintKeywordVideoComputerGames;
		[Field ("FBAdExtraHintKeywordVideoComputerGames", "__Internal")]
		VideoComputerGames
	}

	[Native]
	public enum AdLogLevel : long
	{
		None,
		Notification,
		Error,
		Warning,
		Log,
		Debug,
		Verbose
	}

	[Native]
	public enum MediaViewRenderingMethod : long
	{
		Default,
		Metal,
		OpenGL,
		Software
	}

	[Native]
	public enum AdTestAdType : long
	{
		Default,
		Img16x9AppInstall,
		Img16x9Link,
		VidHD16x9_46sAppInstall,
		VidHD16x9_46sLink,
		VidHD16x9_15sAppInstall,
		VidHD16x9_15sLink,
		VidHD9x16_39sAppInstall,
		VidHD9x16_39sLink,
		CarouselImgSquareAppInstall,
		CarouselImgSquareLink
	}

	[Native]
	public enum AdFormatTypeName : long {
		Unknown = 0,
		Banner,
		Interstitial,
		Instream,
		Native,
		NativeBanner,
		RewardedVideo
	}

	[Native]
	public enum AdFormatType : long {
		Unknown = 0,
		Image,
		Video,
		Carousel
	}

	[Native]
	public enum NativeAdsCachePolicy : long
	{
		None,
		All
	}

	[Native]
	public enum NativeAdViewType : long
	{
		GenericHeight300 = 3,
		GenericHeight400 = 4,
		Dynamic = 6
	}

	[Native]
	public enum NativeBannerAdViewType : long
	{
		GenericHeight100 = 1,
		GenericHeight120 = 2,
		GenericHeight50 = 5
	}

	[Native]
	public enum NativeAdViewTag : ulong
	{
		Icon = 5,
		Title,
		CoverImage,
		Subtitle,
		Body,
		CallToAction,
		SocialContext,
		ChoicesIcon,
		Media
	}
}
