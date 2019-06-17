using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    public class FlightService : EntityService<Flight>, IFlightService
    {

        FlightRepository _flightRepository;

        public FlightService(FlightRepository flightRepository)
            : base(flightRepository)
        {

            _flightRepository = flightRepository;
        }


        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Flight GetById(int Id)
        {
            return _flightRepository.Get(Id);
        }
        public Flight GetByFlightNumber(string flightNumber)
        {
            return _flightRepository.SingleOrDefault(a=>a.Number==flightNumber);
        }
    }
}
