using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    public class BookingService : EntityService<Booking>, IBookingService
    {
       
        BookingRepositoryExtension _bookingRepository;
        
      

        public BookingService(BookingRepositoryExtension bookingRepository)
            : base(bookingRepository)
        {

            _bookingRepository = bookingRepository;
        }
        /// <summary>
        /// Creates new Booking with specified flight number and new Person.
        /// </summary>
        /// <param name="FlightNumber">The flight number.</param>
        /// <param name="Person">The person.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Booking Create(string FlightNumber, Person Person)
        {
            //check if the Flight Exist

            return null;
           
            
        }

        public Booking GetById(int Id)
        {
            return _bookingRepository.Get(Id);
        }

        public IEnumerable<Person> GetPassengersByGender(GenderType gender)
        {
            var passengers = _bookingRepository.GetAll().SelectMany(a => a.Passengers)
                                      .Where(a => a.Gender == gender).Distinct();


            return passengers.AsQueryable();

            //return _bookingRepository.GetPassengersByGender(gender);
        }

        public IEnumerable<Person> GetPassengersInFlight(string flightNumber)
        {
            var passengers = from rep in _bookingRepository.GetAll()
                             where rep.Flight.Number == flightNumber
                             select rep.Passengers;

            return passengers.SelectMany(a => a).AsQueryable();


            //return _bookingRepository.GetPassengersInFlight(flightNumber);
        }
    }
}
