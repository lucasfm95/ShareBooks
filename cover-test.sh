#!/bin/bash
thold=80
if [ $# -ne 0 ]; then
  thold=$1
fi

dotnet test -p:CollectCoverage=true \
			-p:CoverletOutputFormat=opencover \
			-p:Threshold=$thold \
			-p:ThresholdType=line \
			-p:Exclude="[xunit.*]*" \
			ShareBooks.Tests/ShareBooks.Tests.csproj
ret=$?

case "$OSTYPE" in
  msys*) echo 'Attempting to generate report...' ;;
  *) exit $ret ;;
esac

which reportgenerator > /dev/null 2>&1
if [ $? -eq 0 ]; then
   reportgenerator "-reports:./ShareBooks.Tests/coverage.opencover.xml" "-targetdir:./ShareBooks.Tests/coverage_reports"
else
   echo 'Report Generator not found\n'
   echo 'dotnet tool install -g dotnet-reportgenerator-globaltool\n'
fi

exit $ret
