#!/usr/bin/env bash

FNAME="EaseUI"

BUILD="XamBindData"

OUTPUTDIR="${BUILD}/${FNAME}.iOS"
NAMESPACE="${FNAME}.iOS"
FRAMEWORK="Products/${FNAME}.framework"
HEADERFILE="${FNAME}.h"

sharpie bind \
    -o ${OUTPUTDIR} \
    -n ${NAMESPACE} \
    -sdk iphoneos12.1 \
    ${FRAMEWORK}/Headers/*.h \
    -scope ${FRAMEWORK}/Headers \
    -c -F .
