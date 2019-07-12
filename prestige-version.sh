#!/bin/sh

if ([ "$1" = "fix" ] || [ "$1" = "feature" ] || [ "$1" = "revert" ] || [ "$1" = "change" ]) && [ ! -z "$2" ] && [ ! -z "$3" ] && [ ${#4} -lt 80 ];
then
    TYPE=$1
    SCOPE=$2
    TRELLOID=$3
    DESC=$4
    BRANCHE=$(git rev-parse --abbrev-ref HEAD)

    if [ ! "$BRANCHE" = "$TYPE/$SCOPE/$TRELLOID" ];
    then
        git checkout -b "$TYPE/$SCOPE/$TRELLOID"
    fi

    git add *
    git commit -m "$TYPE($SCOPE): $DESC"
else
    echo "Wrong usage, please use :\n./prestige-version.sh [fix, feature, revert, change] [character, monsters, server, etc..] [trelloId] [description]"
fi
