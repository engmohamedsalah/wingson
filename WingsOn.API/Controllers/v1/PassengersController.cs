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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Flights")]
   
    public class PassengersController : ApiController
    {
        
        IFlightService _flightService;
        IBookingService _bookingService;

        public PassengersController(IFlightService flightService, IBookingService bookingService)
        {
            _flightService = flightService;
            _bookingService = bookingService;
        }


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
        [Route("api/v{version:apiVersion}/Flights/Passengers/gender")]
        public IHttpActionResult Get(GenderType gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var passengers = _bookingService.GetPassengersByGender(gender);
            var result = Mapper.Map<List<PersonViewModel>>(passengers);
            return Ok(result);

        }
        //public IHttpActionResult Get(int id)
        //{
        //    _flightService.GetById(id);

        //    return null;
        //}


    }
}
