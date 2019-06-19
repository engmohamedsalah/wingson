using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WingsOn.API.ExceptionHandler.FilterException
{
    public class IdNotValidException : Exception
    {
        public IdNotValidException() : base() { }
        public IdNotValidException(string message) : base(message) { }
        public IdNotValidException(string message, Exception ex) : base(message, ex) { }
    }
}