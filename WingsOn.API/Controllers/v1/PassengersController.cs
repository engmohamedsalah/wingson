using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WingsOn.API.Controllers.v1
{
    public class PassengersController : BaseAPIController
    {
        // GET: api/Passenger
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Passenger/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Passenger
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Passenger/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Passenger/5
        public void Delete(int id)
        {
        }
    }
}
