using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Weixin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //注意顺序
            routes.MapRoute(
                name: "wx",
                url: "wx/{str}",
                defaults: new { controller = "Home", action = "wx", str = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "qr",
               url: "qr/{used}",
               defaults: new { controller = "Home", action = "qr", used = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}