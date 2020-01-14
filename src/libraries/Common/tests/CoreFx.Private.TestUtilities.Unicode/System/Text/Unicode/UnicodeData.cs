// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;

namespace System.Text.Unicode
{
    public static class UnicodeData
    {
        private static readonly CodePoint[] _codePointData = new CodePoint[0x11_0000]; // an array for all code points
        private static readonly Lazy<ParsedUnicodeData> _lazyParsedData = new Lazy<ParsedUnicodeData>();

        public static CodePoint GetData(int codePoint)
        {
            if ((uint)codePoint >= _codePointData.Length)
            {
                throw new ArgumentOutOfRangeException(
                    message: FormattableString.Invariant($"Value U+{(uint)codePoint:X4} is not a valid code point."),
                    paramName: nameof(codePoint));
            }

            CodePoint data = _codePointData[codePoint];

            if (data is null)
            {
                // generate on-demand

                data = new CodePoint(codePoint, _lazyParsedData.Value);
                data ??= Interlocked.CompareExchange(ref _codePointData[codePoint], data, null);
            }

            return data;
        }

        public static CodePoint GetData(uint codePoint) => GetData((int)codePoint);

        public static CodePoint GetData(Rune rune) => GetData(rune.Value);
    }
}
