using log4net;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using WingsOn.API.ExceptionHandler;
using WingsOn.API.Helper;

namespace WingsOn.API.ActionFilters
{
    /// <summary>
    /// Intriduces Model state auto validation to reduce code duplication
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute" />
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ValidateModelAttribute));
        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var modelState = actionContext.ModelState;
                Logger.Error("model failed validation\n" + JsonConvert.SerializeObject(actionContext.ModelState));
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, GenerateApiError(modelState));

            }
        }
        /// <summary>
        /// Generates the API error.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        /// <returns></returns>
        internal static APIErrorData GenerateApiError(ModelStateDictionary modelState)
        {
            return new APIErrorData()
            {
                Code = "InvalidModelState",
                Message = "Request failed validation",
                DateTime = DateTime.Now,
                ErrorId = new Guid(),

            };
        }
    }

}