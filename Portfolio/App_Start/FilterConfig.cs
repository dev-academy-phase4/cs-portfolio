using System.Web.Mvc;

namespace Portfolio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute { Roles = "Admin" });
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
