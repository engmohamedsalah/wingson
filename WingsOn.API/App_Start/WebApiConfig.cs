using Microsoft.Web.Http.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using WingsOn.API.ExceptionHandler;

namespace WingsOn.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            //adding the versioning to the API
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                }
            };
            config.MapHttpAttributeRoutes(constraintResolver);
            config.AddApiVersioning();


            //Registration for any unhandled exception is thrown anywhere
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            //for general exception
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());



            // Web API configuration and services

            // Web API routes
            // config.MapHttpAttributeRoutes();
            ////////////////////////////////



            ////////////////////////////
            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/


        }
    }
}
