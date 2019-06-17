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
    public class CustomExceptionHandlingAttribute : ExceptionFilterAttribute
    {
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
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,resp);

                base.OnException(context);
            }
        }
    }
}