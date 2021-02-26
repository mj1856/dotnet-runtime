// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
//

#pragma once

#include "pal_locale.h"
#include "pal_compiler.h"
#include "pal_errors.h"

/*
These values should be kept in sync with the managed Interop.GlobalizationInterop.TimeZoneDisplayNameType enum.
*/
typedef enum
{
    TimeZoneDisplayName_Generic = 0,
    TimeZoneDisplayName_Standard = 1,
    TimeZoneDisplayName_DaylightSavings = 2,
    TimeZoneDisplayName_GenericLocation = 3,
    TimeZoneDisplayName_ExemplarCity = 4,
} TimeZoneDisplayNameType;

PALEXPORT ResultCode GlobalizationNative_GetTimeZoneDisplayName(const UChar* localeName,
                                                                const UChar* timeZoneId,
                                                                TimeZoneDisplayNameType type,
                                                                UChar* result,
                                                                int32_t resultLength);

// Not exported
void GetTimeZoneDisplayName_FromCalendar(const char* locale,
                                         const UChar* timeZoneId,
                                         const UDate timestamp,
                                         UCalendarDisplayNameType type,
                                         UChar* result,
                                         int32_t resultLength,
                                         UErrorCode* err);

// Not exported
void GetTimeZoneDisplayName_FromPattern(const char* locale,
                                        const UChar* timeZoneId,
                                        const UDate timestamp,
                                        const UChar* pattern,
                                        UChar* result,
                                        int32_t resultLength,
                                        UErrorCode* err);

// Not exported
void FixupTimeZoneGenericDisplayName(const char* locale,
                                     const UChar* timeZoneId,
                                     const UDate timestamp,
                                     UChar* result,
                                     int32_t resultLength,
                                     UErrorCode* err);
