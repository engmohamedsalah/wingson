using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WingsOn.API.ExceptionHandler
{
    /// <summary>
    /// I am trying to implement global exception logging in web api and send a frienldy message to the user with that error ID
    /// so that I tried to add it to HttpRequestMessage.Properties
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        private const string LogId = "LOG_ID";

        public static void SetLogId(this HttpRequestMessage request, Guid id)
        {
            request.Properties[LogId] = id;
        }

        public static Guid GetLogId(this HttpRequestMessage request)
        {
            object value;
            if (request.Properties.TryGetValue(LogId, out value))
            {
                return (Guid)value;
            }

            return Guid.Empty;
        }
    }
}