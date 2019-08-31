using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Zeplin.ScreenDumpExample
{
    public static class Util
    {
        /// See: https://stackoverflow.com/questions/2920744/url-slugify-algorithm-in-c
        public static string SanitisePath(this string text)
        {
            var str = text.RemoveDiacritics().ToLower();
            // invalid chars            
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "", RegexOptions.Compiled);
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ", RegexOptions.Compiled).Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            // hyphens 
            str = Regex.Replace(str, @"\s", "-", RegexOptions.Compiled);
            // convert multiple hyphens into one underscore
            str = Regex.Replace(str, @"-{2,}", "_", RegexOptions.Compiled).Trim();
            return str;
        }

        /// See: http://www.siao2.com/2007/05/14/2629747.aspx
        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark) stringBuilder.Append(c);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string GeneratePathForScreenVersion(DateTime? created, string author, string screenName)
        {
            return Path.Combine(
                $"{created.GetValueOrDefault().ToString("s").SanitisePath().ToUpper()}_{author.SanitisePath()}",
                $"{created.GetValueOrDefault().ToString("dd_hh-mm-sstt-dddd")}_{screenName.SanitisePath()}_current.png"
            );
        }
    }
}