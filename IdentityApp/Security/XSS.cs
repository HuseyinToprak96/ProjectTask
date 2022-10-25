using Ganss.Xss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Security
{
    public static class XSS
    {
        public static string ClearTag(string str)
        {
            var sanitizer = new HtmlSanitizer();
            var html = str;
            var sanitized = sanitizer.Sanitize(html, "https://www.example.com");
            return sanitized;
        }
    }
}
