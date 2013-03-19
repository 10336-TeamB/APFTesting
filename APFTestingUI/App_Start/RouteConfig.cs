using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace APFTestingUI {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Error - 404",
                "NotFound",
                new { controller = "Error", action = "NotFound" }
            );

            routes.MapRoute(
                "Error - 500",
                "ServerError",
                new { controller = "Error", action = "ServerError" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{examId}",
                defaults: new { controller = "Home", action = "Index", examId = UrlParameter.Optional }
            );
        }
    }
}