using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model.Services
{
    public class CheckQuestion
    {
        public string RemoveWhitespace(string s)
        {
            Regex trimmer = new Regex(@"\s\s+");
            return trimmer.Replace(s, " ").Trim();
        }

        public string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        //remove tag &nbsp; in string
        public string StripTagSpaceHtml(string input)
        {
            return Regex.Replace(input, "&nbsp;", String.Empty);
        }

        public bool CheckRedunantQuestion(string newContent, string []oldContent)
        {
            var newContentAfter = RemoveWhitespace(StripTagSpaceHtml(StripHTML(newContent)));
            for (int i = 0; i < oldContent.Length; i++)
            {
                if (newContentAfter == RemoveWhitespace(StripTagSpaceHtml(StripHTML(oldContent[i]))))
                    return true;
            }
            return false;
        }
    }
}
