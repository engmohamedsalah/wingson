using System;

namespace WingsOn.API.ExceptionHandler
{
    public class LogMessage
    {
        public enum LogType { ResourceServerAPI , WebSite , B2B }
        public enum LogLevel { Error , Debug }
      
        public Guid ID { get; internal set; }
        public LogType MessageType { get; internal set; }
        public string SenderMethod { get; internal set; }
        public LogLevel Level { get; internal set; }
        public string MachineName { get; internal set; }
        public string Message { get; internal set; }
    }
}