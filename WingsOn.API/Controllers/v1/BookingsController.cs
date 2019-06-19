using AutoMapper;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WingsOn.API.ExceptionHandler.FilterException;
using WingsOn.API.ViewModel;
using WingsOn.BLL;
using WingsOn.BLL.ExceptionHandling;
using WingsOn.Domain;

namespace WingsOn.API.Controllers
{
    /// <summary>
    /// this class provide the API related to Booking
    /// </summary>
    /// <seealso cref="WingsOn.API.Controllers.BaseAPIController" />
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Bookings")]
    public class BookingsController : BaseAPIController
    {

       
        IBookingService _bookingService;
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingsController"/> class.
        /// </summary>
        /// <param name="bookingService">The booking service.</param>
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        /// <summary>
        /// Posts the specified booking.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <returns></returns>
        /// <exception cref="IdOrNumberNotValidException"></exception>
        public IHttpActionResult Post([FromBody]NewBookingViewModel booking)
        {
            try
            {
                //create new Booking
                var bookingObj = _bookingService.Create(booking.FlightNumber, Mapper.Map<Person>(booking.Person));

                var result = Mapper.Map<BookingViewModel>(bookingObj);

                return Ok(result);
            }
            catch (FligtNotExistException)
            {
                // throw new IdNotValidException();
                throw new IdOrNumberNotValidException();
            }
            catch
            {
                throw;
            }

        }

    }
}
