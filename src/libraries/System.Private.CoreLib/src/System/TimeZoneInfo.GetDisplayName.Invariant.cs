// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    public sealed partial class TimeZoneInfo
    {
        private void GetDisplayName(Interop.Globalization.TimeZoneDisplayNameType nameType, string uiCulture, ref string? displayName)
        {
            displayName = _standardDisplayName;
        }

        private static void GetDisplayName(string timeZoneId, Interop.Globalization.TimeZoneDisplayNameType nameType, string uiCulture, string invariantDisplayName, ref string? displayName)
        {
            displayName = invariantDisplayName;
        }
    }
}
