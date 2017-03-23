POD=pod
XCODEBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild

PROJECT_ROOT=./Pods
PROJECT=$(PROJECT_ROOT)/Pods.xcodeproj
TARGETS=Bolts FBSDKCoreKit FBSDKShareKit FBSDKLoginKit FBSDKMessengerShareKit

all: Podfile.lock FacebookSDKStrings.bundle $(TARGETS)

Podfile.lock:
	$(POD) install

FacebookSDKStrings.bundle:
	cp -r ./Pods/FBSDKCoreKit/FacebookSDKStrings.bundle $@

$(TARGETS):
	$(MAKE) $@-iphoneos.a
	$(MAKE) $@-iphonesimulator.a
	lipo -create -output $@.a $@-iphoneos.a $@-iphonesimulator.a

%-iphoneos.a:
	$(eval currentTarget=$(subst -iphoneos.a,,$@))
	$(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphoneos -arch armv7 -arch arm64 -configuration Release clean build
	-mv ./build/Release-iphoneos/$(currentTarget)/lib$(currentTarget).a $@

%-iphonesimulator.a:
	$(eval currentTarget=$(subst -iphonesimulator.a,,$@))
	$(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphonesimulator -arch i386 -arch x86_64 -configuration Release clean build
	-mv ./build/Release-iphonesimulator/$(currentTarget)/lib$(currentTarget).a $@

clean:
	rm -rf Podfile.lock Pods build *.a *.bundle

.PHONY: all clean
