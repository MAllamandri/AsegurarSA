using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;

namespace AsegurarSA.WebUI.Infraestructura
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Color(this HtmlHelper html , int userid)
        {
            return MvcHtmlString.Create("<link rel=\"stylesheet\" href=\"~/Content/themes/AsegurarSA/css/unicorn." + "color" +".css\" class=\"skin-color\" />");
        }
    }
}