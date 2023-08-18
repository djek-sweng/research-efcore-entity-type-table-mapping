#!/bin/sh

if [ $# -eq 0 ]
then
    echo "Pass input argument."
    exit -1

elif [ "$1" == "tph" ]
then
    CSPORJ="Tph"

elif [ "$1" == "tpt" ]
then
    CSPORJ="Tpt"

elif [ "$1" == "tpc" ]
then
    CSPORJ="Tpc"

else
    echo "Invalid input argument."
    exit -1
fi

CSPORJ_FILE="./src/EFCore.TableMapping.WebApi."$CSPORJ"/EFCore.TableMapping.WebApi."$CSPORJ".csproj"

dotnet run --project "$CSPORJ_FILE" --launch-profile "https"

exit 0
