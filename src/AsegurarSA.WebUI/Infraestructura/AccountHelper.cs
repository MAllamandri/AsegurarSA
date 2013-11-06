using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Providers.Entities;
using AsegurarSA.Domain.Concrete;

namespace AsegurarSA.WebUI.Infraestructura
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Color(this HtmlHelper html , int userid)
        {
            var context = new EFEmpleadoRepository();
            var color = context.Empleados.FirstOrDefault(e => e.EmpleadoId == userid) == null ? "grey" : context.Empleados.FirstOrDefault(e => e.EmpleadoId == userid).Style;
            return MvcHtmlString.Create("<link rel=\"stylesheet\" href=\"/Content/themes/AsegurarSA/css/unicorn." + color +".css\" class=\"skin-color\" />");
        }
    }
}