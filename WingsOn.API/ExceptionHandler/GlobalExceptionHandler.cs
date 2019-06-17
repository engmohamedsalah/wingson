using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using WingsOn.API.Constants;
using WingsOn.API.Helper;
namespace WingsOn.API.ExceptionHandler
{
    public class GlobalExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            // Get the ID
            var id = context.Request.GetLogId();

            var metadata = new APIErrorData
            {
                Code = APIErrorCodes.GLOGBAL_ERR_CODE,
                Message = "An error occurred! Please use the ticket ID to contact our support",
                DateTime = DateTime.Now,
                RequestUri = context.Request.RequestUri,
                ErrorId = id
                
            };

            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, metadata);
            context.Result = new ResponseMessageResult(response);
        }
    }

    
}