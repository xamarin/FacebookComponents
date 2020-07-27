#!/bin/bash

BASEDIR=$(dirname "$0")

dotnet run -p $BASEDIR -- -o $BASEDIR/../facebook-core/transforms/Metadata-Names.xml -i $BASEDIR/../../externals/facebook-core-docs/com
dotnet run -p $BASEDIR -- -o $BASEDIR/../facebook-applinks/transforms/Metadata-Names.xml -i $BASEDIR/../../externals/facebook-applinks-docs/com
dotnet run -p $BASEDIR -- -o $BASEDIR/../facebook-places/transforms/Metadata-Names.xml -i $BASEDIR/../../externals/facebook-places-docs/com
dotnet run -p $BASEDIR -- -o $BASEDIR/../facebook-common/transforms/Metadata-Names.xml -i $BASEDIR/../../externals/facebook-common-docs/com
dotnet run -p $BASEDIR -- -o $BASEDIR/../facebook-share/transforms/Metadata-Names.xml -i $BASEDIR/../../externals/facebook-share-docs/com
dotnet run -p $BASEDIR -- -o $BASEDIR/../facebook-login/transforms/Metadata-Names.xml -i $BASEDIR/../../externals/facebook-login-docs/com
dotnet run -p $BASEDIR -- -o $BASEDIR/../facebook-messenger/transforms/Metadata-Names.xml -i $BASEDIR/../../externals/facebook-messenger-docs/com

