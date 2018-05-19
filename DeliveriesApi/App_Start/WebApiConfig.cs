using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DeliveriesApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */
            config.Routes.MapHttpRoute(
                name: "ApiById",
                routeTemplate: "api/{controller}"
                //defaults: new { id = RouteParameter.Optional }
                //constraints: new { id = @"^[0-9]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = "Get" }
            );

            //this will remove all formaters and every page will return application/json
            // but this applys only to web api controlers
            var jsonFormatter = config.Formatters.JsonFormatter;
            config.Formatters.Clear();  //  .Remove(jsonFormatter);
            config.Formatters.Insert(0, jsonFormatter);

        }

    }
}
