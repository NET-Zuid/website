using System.Text;
using System.Text.RegularExpressions;

namespace DNZ.Common.Helpers
{
   public static class SlugHelper
    {
        public static string GenerateSlug(string headline)
        {
            var str = RemoveAccent(headline).ToLower();

            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");                  // invalid chars           
            str = Regex.Replace(str, @"\s+", " ").Trim();                   // convert multiple spaces into one space   
            str = str.Substring(0, str.Length <= 120 ? str.Length : 120).Trim();    // cut and trim it to prevent extreme long URL's
            str = Regex.Replace(str, @"\s", "-");                           // hyphens   

            return str;
        }

        private static string RemoveAccent(string txt)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
