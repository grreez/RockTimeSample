using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RockTimeWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              null,
              "home/article/{action}",
               new { controller = "Article" }
           );

            routes.MapRoute(
               null,
               "home/article/",
                new { controller = "Article", action = "Index" }
            );

            routes.MapRoute(
               null,
               "{*catchall}",
                new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(null, "(controller)/(action");
        }
    }
}