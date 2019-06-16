using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using WingsOn.BLL;
using log4net;
using Newtonsoft.Json;
using static WingsOn.API.ExceptionHandler.LogMessage;

namespace WingsOn.API.ExceptionHandler
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(UnhandledExceptionLogger));

        
        public override void Log(ExceptionLoggerContext context)
        {
            var logMsg = PrepareLogMessage(context);
            _logger.Error(JsonConvert.SerializeObject(logMsg));
            //Do whatever logging you need to do here.
        }

        public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {


            var logMsg = PrepareLogMessage(context);
            // Set the ID
            context.Request.SetLogId(logMsg.ID);

            //log the error
          
           _logger.Error(JsonConvert.SerializeObject(logMsg));
            return Task.FromResult<bool>(true);

        }
        public virtual bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }
        private LogMessage PrepareLogMessage(ExceptionLoggerContext context)
        {
            return new LogMessage
            {
                ID = Guid.NewGuid(),
                MessageType = LogType.ResourceServerAPI,
                SenderMethod = context.Request.RequestUri != null ? string.Format("Request URL: {0}", context.Request.RequestUri.ToString()) : "",
                Level = LogLevel.Error,
                MachineName = Environment.MachineName,
                Message = context.Exception.Message
            };
            
        }
        

    }
}