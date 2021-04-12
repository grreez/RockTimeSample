using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RockTimeWebsite.ExtensionMethods
{
    public static class StringHelper
    {

        public static string ToUrl(this string str)
        {
            return GenerateUrl(str);
        }
        private static string GenerateUrl(string str)
        {
            var url = str;
            url = string.Format("{0}", url.ToLower());
            url = RemoveAccent(url);
            url = Regex.Replace(url, @"[^a-z0-9\s-]", "-");
            url = Regex.Replace(url, @"\s+", "-");
            return url;
        }
        private static string RemoveAccent(string str)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(str);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
       
    }
}