﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LeaveSystem.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute(null, "abc{Name}",
                new { controller = "Home", action = "Contact"}
            );
            */
            routes.MapRoute(null, "",
                new { controller = "Product", action = "List", category = (string)null, page = 1});
            /*
            routes.MapRoute(null, "",
                new { controller = "Product", action = "List", category = (string)null, page = 1 });
            */


            
            routes.MapRoute(null, "Page{page}",
                 new { controller = "Product", action = "List", category = (string)null },
                 new { page = @"\d+" }
            );

            routes.MapRoute(null, "Admin/{action}",
                new { controller = "Admin", action = "Index" });

            routes.MapRoute(null, "{category}",
                new { controller = "Product", action = "List", page = 1 }
            );

            routes.MapRoute(null, "{category}/Page{page}",
                new { controller = "Product", action = "List" },
                new { page = @"\d+" }
            );

            
            routes.MapRoute(null, "{controller}/{action}");
           
            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
             * */
        }
    }
}
