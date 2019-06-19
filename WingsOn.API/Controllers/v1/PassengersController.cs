using AutoMapper;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WingsOn.API.ViewModel;
using WingsOn.BLL;
using WingsOn.Domain;

namespace WingsOn.API.Controllers.v1
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Flights")]
    //[Authorize]
    public class PassengersController : ApiController
    {
        
        IFlightService _flightService;
        IBookingService _bookingService;
        /// <summary>
        /// Initializes a new instance of the <see cref="PassengersController"/> class.
        /// </summary>
        /// <param name="flightService">The flight service.</param>
        /// <param name="bookingService">The booking service.</param>
        public PassengersController(IFlightService flightService, IBookingService bookingService)
        {
            _flightService = flightService;
            _bookingService = bookingService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns></returns>
        // GET: api/Flight/5/Passengers
        [Route("api/v{version:apiVersion}/Flights/{flightNumber}/Passengers")]
        [SwaggerOperation("Get Passengers in a specific flight")]
        public IHttpActionResult Get(string flightNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var passengers= _bookingService.GetPassengersInFlight(flightNumber);
            var result = Mapper.Map<List<PersonViewModel>>(passengers);
            return Ok(result);
            
        }
        /// <summary>
        /// Gets the specified gender.
        /// </summary>
        /// <param name="gender">The gender.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <param name="sidx">The sidx.</param>
        /// <param name="sord">The sord.</param>
        /// <returns></returns>
        [Route("api/v{version:apiVersion}/Passengers/{gender}")]
        public IHttpActionResult Get(GenderType gender, [FromUri] int page = 1, [FromUri] int pageCount = 2,
            [FromUri] string sidx = "Id", [FromUri] string sord = "asc")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var passengers = _bookingService.GetPassengersByGender(gender,sidx,sord,page,pageCount);
            var result = Mapper.Map<List<PersonViewModel>>(passengers);
            return Ok(result);

        }
        


    }
}
