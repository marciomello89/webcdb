using System.Web.Mvc;
using System.Web.Routing;

namespace WebCdb
{
    public class RouteConfig
    {
        protected RouteConfig() { }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "api/{controller}/{action}"
            );
        }
    }
}
