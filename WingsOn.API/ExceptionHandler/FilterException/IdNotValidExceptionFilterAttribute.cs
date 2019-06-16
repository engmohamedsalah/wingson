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
    public class IdNotValidExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is IdNotValidException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ItemNotFound",
                    StatusCode = HttpStatusCode.NotFound,
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}