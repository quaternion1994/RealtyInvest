using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;

namespace RealtyInvest.Common.Utils
{
    public static class WidgetHelpers
    {
        public static MvcHtmlString ItemSelectList(this HtmlHelper html, IEnumerable<string> items, string id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<ul class=\"ui-widget-content\" id=\""+id+"\">");
            foreach(var str in items)
                builder.AppendFormat("<li>{0}</li>\n", str);
            builder.AppendLine("</ul>");
            return new MvcHtmlString(builder.ToString());
        }
    }
}