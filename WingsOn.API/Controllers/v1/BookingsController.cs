using AutoMapper;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WingsOn.API.ViewModel;
using WingsOn.BLL;
using WingsOn.Domain;

namespace WingsOn.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Bookings")]
    public class BookingsController : BaseAPIController
    {

       
        IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // POST: api/Booking
        public IHttpActionResult Post([FromBody]BookingViewModel booking)
        {
            //create new Booking
            var bookingObj = _bookingService.Create(booking.FlightNumber, Mapper.Map<Person>(booking.Person));
            //

            var result = Mapper.Map<BookingViewModel>(bookingObj);

            return Ok(result);
        }

        // PUT: api/Booking/5
       
    }
}
