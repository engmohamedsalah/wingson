using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WingsOn.API.ExceptionHandler.FilterException
{
    public class IdOrNumberNotValidException : Exception
    {
        public IdOrNumberNotValidException() : base() { }
        public IdOrNumberNotValidException(string message) : base(message) { }
        public IdOrNumberNotValidException(string message, Exception ex) : base(message, ex) { }
    }
}