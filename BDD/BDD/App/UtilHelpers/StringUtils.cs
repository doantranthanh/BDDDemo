using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.UtilHelpers
{
    internal static class StringUtils
    {
        public const string CarriageReturnLineFeed = "\r\n";
        public const string Empty = "";
        public const char CarriageReturn = '\r';
        public const char LineFeed = '\n';
        public const char Tab = '\t';

        public static string FormatWith(this string format, IFormatProvider provider, object arg0)
        {
            return FormatWith(format, provider, new object[1]
            {
                arg0
            });
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            ValidationUtils.ArgumentNotNull(format, nameof(format));
            return string.Format(provider, format, args);
        }
    }
}
