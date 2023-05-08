using System;
using System.Text.RegularExpressions;

namespace Nett.Backports
{
    internal class GuidEx
    {
        //https://web.archive.org/web/20200719131004/http://geekswithblogs.net:80/colinbo/archive/2006/01/18/66307.aspx
        public static bool TryParse(string s, out Guid result)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            
            var format = new Regex(
                "^[A-Fa-f0-9]{32}$|" + 
                "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
            
            var match = format.Match(s);
            if (match.Success)
            {
                result = new Guid(s);
                return true;
            }
            else
            {
                result = Guid.Empty;
                return false;
            }
        }

        public static Guid Parse(string s)
        {
            if (!TryParse(s, out var guid))
            {
                throw new FormatException($"'{s}' is not a valid GUID.");
            }

            return guid;
        }
    }
}
