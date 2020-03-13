using System.Web;
using System.Web.Mvc;

namespace Demo_Upload_Multiple_Images
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
