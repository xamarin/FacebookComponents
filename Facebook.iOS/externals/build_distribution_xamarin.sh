#!/bin/sh
# Copyright (c) 2014-present, Facebook, Inc. All rights reserved.
#
# You are hereby granted a non-exclusive, worldwide, royalty-free license to use,
# copy, modify, and distribute this software in source code or binary form for use
# in connection with the web services and APIs provided by Facebook.
#
# As with any software that integrates with the Facebook platform, your use of
# this software is subject to the Facebook Developer Principles and Policies
# [http://developers.facebook.com/policy/]. This copyright notice shall be
# included in all copies or substantial portions of the software.
#
# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
# FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
# COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
# IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
# CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

. "${FB_SDK_SCRIPT:-$(dirname $0)}/common.sh"

# option s to skip build
SKIPBUILD=""
while getopts "s" OPTNAME
do
  case "$OPTNAME" in
    s)
      SKIPBUILD="YES"
      ;;
  esac
done

FB_SDK_ZIP=$FB_SDK_BUILD/FacebookSDKs-${FB_SDK_VERSION_SHORT}.zip


FB_SDK_BUILD_PACKAGE=$FB_SDK_BUILD/package
FB_SDK_BUILD_PACKAGE_SAMPLES=$FB_SDK_BUILD_PACKAGE/Samples
FB_SDK_BUILD_PACKAGE_SCRIPTS=$FB_SDK_BUILD/Scripts
FB_SDK_BUILD_PACKAGE_DOCSETS_FOLDER=$FB_SDK_BUILD_PACKAGE/DocSets/

# -----------------------------------------------------------------------------gi
# Build package directory structure
#
progress_message "Building package directory structure."
\rm -rf "$FB_SDK_BUILD_PACKAGE" "$FB_SDK_BUILD_PACKAGE_SCRIPTS"
mkdir -p "$FB_SDK_BUILD_PACKAGE" \
  || die "Could not create directory $FB_SDK_BUILD_PACKAGE"
mkdir -p "$FB_SDK_BUILD_PACKAGE_SAMPLES"
mkdir -p "$FB_SDK_BUILD_PACKAGE_SCRIPTS"
mkdir -p "$FB_SDK_BUILD_PACKAGE_DOCSETS_FOLDER"

# -----------------------------------------------------------------------------
# Call out to build prerequisites.
#
if is_outermost_build; then
  if [ -z $SKIPBUILD ]; then
    . "$FB_SDK_SCRIPT/build_framework.sh" -c Release
  fi
fi
echo Building Distribution.

# -----------------------------------------------------------------------------
# Copy over stuff
#
\cp -R "$FB_SDK_BUILD"/FBSDKCoreKit.framework "$FB_SDK_BUILD_PACKAGE" \
  || die "Could not copy FBSDKCoreKit.framework"
\cp -R "$FB_SDK_BUILD"/FBSDKLoginKit.framework "$FB_SDK_BUILD_PACKAGE" \
  || die "Could not copy FBSDKLoginKit.framework"
\cp -R "$FB_SDK_BUILD"/FBSDKShareKit.framework "$FB_SDK_BUILD_PACKAGE" \
  || die "Could not copy FBSDKShareKit.framework"
\cp -R "$FB_SDK_BUILD"/Bolts.framework "$FB_SDK_BUILD_PACKAGE" \
  || die "Could not copy Bolts.framework"
\cp -R $"$FB_SDK_ROOT"/FacebookSDKStrings.bundle "$FB_SDK_BUILD_PACKAGE" \
  || die "Could not copy FacebookSDKStrings.bundle"
for SAMPLE in Configurations Iconicus RPSSample Scrumptious ShareIt SwitchUserSample; do
  \rsync -avmc --exclude "${SAMPLE}.xcworkspace" "$FB_SDK_SAMPLES/$SAMPLE" "$FB_SDK_BUILD_PACKAGE_SAMPLES" \
    || die "Could not copy $SAMPLE"
done
\cp "$FB_SDK_ROOT/README.txt" "$FB_SDK_BUILD_PACKAGE" \
  || die "Could not copy README"
\cp "$FB_SDK_ROOT/LICENSE" "$FB_SDK_BUILD_PACKAGE"/LICENSE.txt \
  || die "Could not copy LICENSE"


# -----------------------------------------------------------------------------
# Build Messenger Kit
#
if [ -z $SKIPBUILD ]; then
  (xcodebuild -project "${FB_SDK_ROOT}"/FBSDKMessengerShareKit/FBSDKMessengerShareKit.xcodeproj -scheme "FBSDKMessengerShareKit-universal" -configuration Release clean build) || die "Failed to build messenger kit"
fi
\cp -R "$FB_SDK_BUILD"/FBSDKMessengerShareKit.framework "$FB_SDK_BUILD_PACKAGE" \
  || die "Could not copy FBSDKMessengerShareKit.framework"

# -----------------------------------------------------------------------------
# Done
#
progress_message "Successfully built SDK zip: $FB_SDK_ZIP"
common_success
