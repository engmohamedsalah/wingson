using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WingsOn.API.ExceptionHandler.FilterException
{
    public class EmailValidException : Exception
    {
        public EmailValidException() : base() { }
        public EmailValidException(string message) : base(message) { }
        public EmailValidException(string message, Exception ex) : base(message, ex) { }
    }
}