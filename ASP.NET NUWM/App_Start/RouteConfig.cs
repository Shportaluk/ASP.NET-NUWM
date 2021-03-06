﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP.NET_NUWM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "OnlyAction",
                           url: "{action}",
                           defaults: new { controller = "Home", action = "Index" }
                         );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
            routes.MapRoute(
                name: "Page",
                url: "{Page}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Page",
                    id = UrlParameter.Optional
                }
            );
            
        }
    }
}
