using System;

using Foundation;
using ObjCRuntime;

namespace Facebook.PlacesKit
{
	public enum PlacesFieldKey {
		// extern NSString *const FBSDKPlacesFieldKeyAbout;
		[Field ("FBSDKPlacesFieldKeyAbout", "__Internal")]
		About,

		// extern NSString *const FBSDKPlacesFieldKeyAppLinks;
		[Field ("FBSDKPlacesFieldKeyAppLinks", "__Internal")]
		AppLinks,

		// extern NSString *const FBSDKPlacesFieldKeyCategories;
		[Field ("FBSDKPlacesFieldKeyCategories", "__Internal")]
		Categories,

		// extern NSString *const FBSDKPlacesFieldKeyCheckins;
		[Field ("FBSDKPlacesFieldKeyCheckins", "__Internal")]
		Checkins,

		// extern NSString *const FBSDKPlacesFieldKeyConfidence;
		[Field ("FBSDKPlacesFieldKeyConfidence", "__Internal")]
		Confidence,

		// extern NSString *const FBSDKPlacesFieldKeyCoverPhoto;
		[Field ("FBSDKPlacesFieldKeyCoverPhoto", "__Internal")]
		CoverPhoto,

		// extern NSString *const FBSDKPlacesFieldKeyDescription;
		[Field ("FBSDKPlacesFieldKeyDescription", "__Internal")]
		Description,

		// extern NSString *const FBSDKPlacesFieldKeyEngagement;
		[Field ("FBSDKPlacesFieldKeyEngagement", "__Internal")]
		Engagement,

		// extern NSString *const FBSDKPlacesFieldKeyHours;
		[Field ("FBSDKPlacesFieldKeyHours", "__Internal")]
		Hours,

		// extern NSString *const FBSDKPlacesFieldKeyIsAlwaysOpen;
		[Field ("FBSDKPlacesFieldKeyIsAlwaysOpen", "__Internal")]
		IsAlwaysOpen,

		// extern NSString *const FBSDKPlacesFieldKeyIsPermanentlyClosed;
		[Field ("FBSDKPlacesFieldKeyIsPermanentlyClosed", "__Internal")]
		IsPermanentlyClosed,

		// extern NSString *const FBSDKPlacesFieldKeyIsVerified;
		[Field ("FBSDKPlacesFieldKeyIsVerified", "__Internal")]
		IsVerified,

		// extern NSString *const FBSDKPlacesFieldKeyLocation;
		[Field ("FBSDKPlacesFieldKeyLocation", "__Internal")]
		Location,

		// extern NSString *const FBSDKPlacesFieldKeyLink;
		[Field ("FBSDKPlacesFieldKeyLink", "__Internal")]
		Link,

		// extern NSString *const FBSDKPlacesFieldKeyName;
		[Field ("FBSDKPlacesFieldKeyName", "__Internal")]
		Name,

		// extern NSString *const FBSDKPlacesFieldKeyOverallStarRating;
		[Field ("FBSDKPlacesFieldKeyOverallStarRating", "__Internal")]
		OverallStarRating,

		// extern NSString *const FBSDKPlacesFieldKeyPage;
		[Field ("FBSDKPlacesFieldKeyPage", "__Internal")]
		Page,

		// extern NSString *const FBSDKPlacesFieldKeyParking;
		[Field ("FBSDKPlacesFieldKeyParking", "__Internal")]
		Parking,

		// extern NSString *const FBSDKPlacesFieldKeyPaymentOptions;
		[Field ("FBSDKPlacesFieldKeyPaymentOptions", "__Internal")]
		PaymentOptions,

		// extern NSString *const FBSDKPlacesFieldKeyPlaceID;
		[Field ("FBSDKPlacesFieldKeyPlaceID", "__Internal")]
		PlaceId,

		// extern NSString *const FBSDKPlacesFieldKeyPhone;
		[Field ("FBSDKPlacesFieldKeyPhone", "__Internal")]
		Phone,

		// extern NSString *const FBSDKPlacesFieldKeyPhotos;
		[Field ("FBSDKPlacesFieldKeyPhotos", "__Internal")]
		Photos,

		// extern NSString *const FBSDKPlacesFieldKeyPriceRange;
		[Field ("FBSDKPlacesFieldKeyPriceRange", "__Internal")]
		PriceRange,

		// extern NSString *const FBSDKPlacesFieldKeyProfilePhoto;
		[Field ("FBSDKPlacesFieldKeyProfilePhoto", "__Internal")]
		ProfilePhoto,

		// extern NSString *const FBSDKPlacesFieldKeyRatingCount;
		[Field ("FBSDKPlacesFieldKeyRatingCount", "__Internal")]
		RatingCount,

		// extern NSString *const FBSDKPlacesFieldKeyRestaurantServices;
		[Field ("FBSDKPlacesFieldKeyRestaurantServices", "__Internal")]
		RestaurantServices,

		// extern NSString *const FBSDKPlacesFieldKeyRestaurantSpecialties;
		[Field ("FBSDKPlacesFieldKeyRestaurantSpecialties", "__Internal")]
		RestaurantSpecialties,

		// extern NSString *const FBSDKPlacesFieldKeySingleLineAddress;
		[Field ("FBSDKPlacesFieldKeySingleLineAddress", "__Internal")]
		SingleLineAddress,

		// extern NSString *const FBSDKPlacesFieldKeyWebsite;
		[Field ("FBSDKPlacesFieldKeyWebsite", "__Internal")]
		Website,

		// extern NSString *const FBSDKPlacesFieldKeyWorkflows;
		[Field ("FBSDKPlacesFieldKeyWorkflows", "__Internal")]
		Workflows
	}

	public enum PlacesResponseKey {
		// extern NSString *const FBSDKPlacesResponseKeyCity;
		[Field ("FBSDKPlacesResponseKeyCity", "__Internal")]
		City,

		// extern NSString *const FBSDKPlacesResponseKeyCityID;
		[Field ("FBSDKPlacesResponseKeyCityID", "__Internal")]
		CityId,

		// extern NSString *const FBSDKPlacesResponseKeyCountry;
		[Field ("FBSDKPlacesResponseKeyCountry", "__Internal")]
		Country,

		// extern NSString *const FBSDKPlacesResponseKeyCountryCode;
		[Field ("FBSDKPlacesResponseKeyCountryCode", "__Internal")]
		CountryCode,

		// extern NSString *const FBSDKPlacesResponseKeyLatitude;
		[Field ("FBSDKPlacesResponseKeyLatitude", "__Internal")]
		Latitude,

		// extern NSString *const FBSDKPlacesResponseKeyLongitude;
		[Field ("FBSDKPlacesResponseKeyLongitude", "__Internal")]
		Longitude,

		// extern NSString *const FBSDKPlacesResponseKeyRegion;
		[Field ("FBSDKPlacesResponseKeyRegion", "__Internal")]
		Region,

		// extern NSString *const FBSDKPlacesResponseKeyRegionID;
		[Field ("FBSDKPlacesResponseKeyRegionID", "__Internal")]
		RegionId,

		// extern NSString *const FBSDKPlacesResponseKeyState;
		[Field ("FBSDKPlacesResponseKeyState", "__Internal")]
		State,

		// extern NSString *const FBSDKPlacesResponseKeyStreet;
		[Field ("FBSDKPlacesResponseKeyStreet", "__Internal")]
		Street,

		// extern NSString *const FBSDKPlacesResponseKeyZip;
		[Field ("FBSDKPlacesResponseKeyZip", "__Internal")]
		Zip,

		// extern NSString *const FBSDKPlacesResponseKeyMatchedCategories;
		[Field ("FBSDKPlacesResponseKeyMatchedCategories", "__Internal")]
		MatchedCategories,

		// extern NSString *const FBSDKPlacesResponseKeyPhotoSource;
		[Field ("FBSDKPlacesResponseKeyPhotoSource", "__Internal")]
		PhotoSource,

		// extern NSString *const FBSDKPlacesResponseKeyData;
		[Field ("FBSDKPlacesResponseKeyData", "__Internal")]
		Data,

		// extern NSString *const FBSDKPlacesResponseKeyUrl;
		[Field ("FBSDKPlacesResponseKeyUrl", "__Internal")]
		Url
	}

	public enum PlacesParameterKey {
		// extern NSString *const FBSDKPlacesParameterKeySummary;
		[Field ("FBSDKPlacesParameterKeySummary", "__Internal")]
		Summary
	}

	public enum PlacesSummaryKey {
		// extern NSString *const FBSDKPlacesSummaryKeyTracking;
		[Field ("FBSDKPlacesSummaryKeyTracking", "__Internal")]
		Tracking
	}

	[Native]
	public enum PlaceLocationConfidence : long
	{
		NotApplicable,
		Low,
		Medium,
		High
	}
}
