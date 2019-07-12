#!/bin/sh

if ([ "$1" = "fix" ] || [ "$1" = "feature" ] || [ "$1" = "revert" ] || [ "$1" = "change" ]) && [ ! -z "$2" ] && [ ! -z "$3" ] && [ ${#4} -lt 80 ];
then
    TYPE=$1
    SCOPE=$2
    TRELLOID=$3
    DESC=$4
    BRANCHE=$(git rev-parse --abbrev-ref HEAD)
    ANDROID="latest.apk"
    IOS="latest.apk"
    OLDTIME=500
    CURTIME=$(date +%s)
    ANDROIDTIME=$(stat -t %s -f %m $ANDROID)
    ANDROIDDIFF=$(expr $CURTIME - $ANDROIDTIME)
    IOSTIME=$(stat -t %s -f %m $IOS)
    IOSDIFF=$(expr $CURTIME - $IOSTIME)

    if [ "$ANDROIDDIFF" -lt "$OLDTIME" ] || [ "$IOSDIFF" -lt "$OLDTIME" ];
    then
        if [ ! "$BRANCHE" = "$TYPE/$SCOPE/$TRELLOID" ];
        then
            git checkout -b "$TYPE/$SCOPE/$TRELLOID"
        fi

        git add .
        git commit -m "$TYPE($SCOPE): $DESC"
        git push --set-upstream origin "$TYPE/$SCOPE/$TRELLOID"
        git checkout master
    else
        echo "You have to build the project for IOS or Android before !"
    fi
else
    echo "Wrong usage, please use :\n./prestige-version.sh [fix, feature, revert, change] [character, monsters, server, etc..] [trelloId] [description]"
fi
