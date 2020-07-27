#!/bin/bash

dotnet run -o ../facebook-core/transforms/Metadata-Names.xml -i ../../externals/facebook-core-docs/com
dotnet run -o ../facebook-applinks/transforms/Metadata-Names.xml -i ../../externals/facebook-applinks-docs/com
dotnet run -o ../facebook-places/transforms/Metadata-Names.xml -i ../../externals/facebook-places-docs/com
dotnet run -o ../facebook-common/transforms/Metadata-Names.xml -i ../../externals/facebook-common-docs/com
dotnet run -o ../facebook-share/transforms/Metadata-Names.xml -i ../../externals/facebook-share-docs/com
dotnet run -o ../facebook-login/transforms/Metadata-Names.xml -i ../../externals/facebook-login-docs/com
dotnet run -o ../facebook-messenger/transforms/Metadata-Names.xml -i ../../externals/facebook-messenger-docs/com

