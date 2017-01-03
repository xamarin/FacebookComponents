
# We need to build the SDK as the prebuilt versions are 
# using CLANG_MODULES_AUTOLINK.  This will cause linker
# errors. We could use native references in the binding
# but then we lose iOS 7 support.  Once the following is
# fixed we can use the prebuilt SDK again.
# https://bugzilla.xamarin.com/show_bug.cgi?id=44635

GIT_REPO_TAG=sdk-version-4.18.0

all: FBSDKCoreKit.a

facebook-ios-sdk/build/package/FBSDKCoreKit.framework/FBSDKCoreKit: facebook-ios-sdk/scripts/build_distribution_xamarin.sh
	cd facebook-ios-sdk/scripts && sh build_distribution_xamarin.sh

FBSDKCoreKit.a: facebook-ios-sdk/build/package/FBSDKCoreKit.framework/FBSDKCoreKit
	cp -R facebook-ios-sdk/build/package/FacebookSDKStrings.bundle .
	cp facebook-ios-sdk/build/package/Bolts.framework/Bolts Bolts.a
	cp facebook-ios-sdk/build/package/FBSDKCoreKit.framework/FBSDKCoreKit FBSDKCoreKit.a
	cp facebook-ios-sdk/build/package/FBSDKLoginKit.framework/FBSDKLoginKit FBSDKLoginKit.a
	cp facebook-ios-sdk/build/package/FBSDKMessengerShareKit.framework/FBSDKMessengerShareKit FBSDKMessengerShareKit.a
	cp facebook-ios-sdk/build/package/FBSDKShareKit.framework/FBSDKShareKit FBSDKShareKit.a

facebook-ios-sdk/README.txt:
	git clone https://github.com/facebook/facebook-ios-sdk.git 
	cd facebook-ios-sdk && git checkout $(GIT_REPO_TAG)
	touch $@

facebook-ios-sdk/scripts/build_distribution_xamarin.sh: facebook-ios-sdk/README.txt
	cp build_distribution_xamarin.sh facebook-ios-sdk/scripts/
	cd facebook-ios-sdk && git apply ../remove-autolink.patch

clean:
	rm -rf facebook-ios-sdk FacebookSDKStrings.bundle Bolts.a FBSDKCoreKit.a FBSDKLoginKit.a \
		   FBSDKMessengerShareKit.a FBSDKShareKit.a