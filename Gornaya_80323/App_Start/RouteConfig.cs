using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gornaya_80323
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "menu",
                defaults: new
                {
                    controller = "Book",
                    action = "List",
                    page = 1,
                    type = (string)null
                }
            );

            routes.MapRoute(
                name: "",
                url: "menu/page{page}",
                defaults: new {    controller = "Book",
                    action = "List",
                    type = (string)null
                },
                constraints: new { page = @"\d+" });

            routes.MapRoute(
            name: "",
            url: "menu/{type}",
            defaults: new
            {
                controller = "Book",
                action = "List",
                page = 1
            });

            routes.MapRoute(
            name: "",
            url: "menu/{type}/page{page}",
            defaults: new { controller = "Book", action = "List" },
            constraints: new { page = @"\d+" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
