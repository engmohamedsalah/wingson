using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WingsOn.BLL.ExceptionHandling
{
    /// <summary>
    /// this exception raise in case flight not exist with
    /// provided flight number
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ObjectNotExistWithIdException : Exception
    {
        public ObjectNotExistWithIdException(string message) : base() { }

    }
}
