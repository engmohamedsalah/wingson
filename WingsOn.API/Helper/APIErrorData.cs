using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WingsOn.API.Helper
{
    public class APIErrorData
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public Uri RequestUri { get; set; }
        public Guid ErrorId { get; set; }
    }
}