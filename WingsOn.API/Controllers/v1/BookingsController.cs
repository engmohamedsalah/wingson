using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WingsOn.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Bookings")]
    public class BookingsController : BaseAPIController
    {
       
       

        // POST: api/Booking
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Booking/5
       
    }
}
