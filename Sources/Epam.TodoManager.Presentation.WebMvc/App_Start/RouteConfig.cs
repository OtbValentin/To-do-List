using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Epam.TodoManager.Presentation.WebMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "Account", action = "Register" }
            );

            //routes.MapRoute(
            //    name: "Lists",
            //    url: "lists/{id}",
            //    defaults: new { controller = "Webapp", action = "Lists", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Tasks",
            //    url: "lists/{listid}/tasks",
            //    defaults: new { controller="Webapp", action = "Tasks"}
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Webapp", action = "Index"}
            );
        }
    }
}
