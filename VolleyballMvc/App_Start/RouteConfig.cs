using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VolleyballMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes( RouteCollection routes )
        {
           // var gen = System.Threading.Thread.CurrentThread.
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );
            routes.IgnoreRoute("{*favicon}",
        new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{gender}/{controller}/{action}", // URL with parameters
                new { controller = "home", action = "index", gender = "" } // Parameter defaults
        );

//            routes.MapRoute(
//    "Default", // Route name
//    "{controller}/{action}", // URL with parameters
//    new { controller = "home", action = "index", gender = "" } // Parameter defaults
//);

            //routes.MapRoute(
            //    name: "Default" ,
            //    url: "{controller}/{action}/{id}" ,
            //    defaults: new { controller = "Home", action = "Index" , id = UrlParameter.Optional }
            //);
        }
    }
}
//http://stackoverflow.com/questions/3683404/asp-net-mvc-localized-routes-and-the-default-language-for-the-user