using Microsoft.Web.Http.Routing;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Routing;
using WingsOn.API.ExceptionHandler;
using WingsOn.API.ExceptionHandler.FilterException;

namespace WingsOn.API
{
    /// <summary>
    /// WebApi configuration 
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
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
    

            //add custom validation
           config.Filters.Add(new CustomExceptionHandlingAttribute());
            


        }
    }
}
