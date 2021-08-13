using System.Text;
using System.Text.RegularExpressions;

namespace Zadanie1.DemoImplementation
{
    public static class StringSanitizer
    {
        public static string SanitizeString(string toSanitize)
        {
            var sanitizedString = Regex.Replace(toSanitize, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);

            return sanitizedString;
        }
    }
}