using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

public class TextHelper
{
    public static MvcHtmlString SkipLine(string text)
    {
        if (string.IsNullOrEmpty(text))
            return MvcHtmlString.Create(text);
        else
        {
            StringBuilder builder = new StringBuilder();
            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (i > 0)
                    builder.Append("<br/>\n");
                builder.Append(HttpUtility.HtmlEncode(lines[i]));
            }
            return MvcHtmlString.Create(builder.ToString());
        }
    }

    public static MvcHtmlString EndLine(string text)
    {
        if (String.IsNullOrEmpty(text))
        {
            return MvcHtmlString.Empty;
        }

        var newText = Regex.Replace(text, Environment.NewLine, "<br/>");
        return MvcHtmlString.Create(newText);
    }
}

