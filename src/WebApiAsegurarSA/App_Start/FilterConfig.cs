using System.Web;
using System.Web.Mvc;

namespace WebApiAsegurarSA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}