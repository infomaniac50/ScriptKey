using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    /// <summary>
    /// Provides string formatting functions
    /// </summary>
    public static class Formatting
    {
        /// <summary>
        /// Capitalizes strings.
        /// </summary>
        /// <param name="AString">The A string.</param>
        /// <returns></returns>
        public static string CapitalizeString(string AString)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(AString);
        }
    }
}
