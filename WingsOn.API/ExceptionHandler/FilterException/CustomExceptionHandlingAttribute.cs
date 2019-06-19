using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WingsOn.API.ExceptionHandler.FilterException
{
    /// <summary>
    /// this is custom Exception handling 
    /// </summary>
    /// <seealso cref="System.Web.Http.Filters.ExceptionFilterAttribute" />
    public class CustomExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            
            if (context.Exception is IdOrNumberNotValidException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Object is not found with an Id/Number which passed via request paramenters",
                    StatusCode = HttpStatusCode.NotFound,
                };
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, resp);

                base.OnException(context);
            }
            else if (context.Exception is EmailValidException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Email is invalid format",
                    StatusCode = HttpStatusCode.BadRequest,
                };
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, resp);

                base.OnException(context);
            }
            else if (context.Exception is IdNotValidException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Id should be integer greater than 0",
                    StatusCode = HttpStatusCode.BadRequest,
                };
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, resp);

                base.OnException(context);
            }
        }
    }
}