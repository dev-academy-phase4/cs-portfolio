using System.Data.Entity.Migrations;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Portfolio.Migrations;

namespace Portfolio
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Runs Code First database update on each restart...
            // handy for deploy via GitHub.
            #if !DEBUG
                var migrator = new DbMigrator(new Configuration());
                migrator.Update();
            #endif
        }
    }
}
