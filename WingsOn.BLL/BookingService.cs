using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.BLL.ExceptionHandling;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    public class BookingService : EntityService<Booking>, IBookingService
    {

        BookingRepository _bookingRepository;
        FlightRepository _flightRepository;
        PersonRepository _personRepository;



        public BookingService(BookingRepository bookingRepository, FlightRepository flightRepository, PersonRepository personRepository)
            : base(bookingRepository)
        {

            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _personRepository = personRepository;
        }
        /// <summary>
        /// Creates new Booking with specified flight number and new Person.
        /// </summary>
        /// <param name="flightNumber">The flight number.</param>
        /// <param name="person">The person.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Booking Create(string flightNumber, Person person)
        {
            //check if the Flight Exist

            try
            {
                //cehck fist about flight number if exist of not
                var flight = _flightRepository.SingleOrDefault(a => a.Number == flightNumber);
                if (flight == null)
                    throw new FligtNotExistException(nameof(flight));


                //create new person
                _personRepository.Create(person);
                var passengers = new List<Person>() { person };
                
                var book = new Booking()
                {
                    DateBooking = DateTime.Now,
                    Number = flightNumber,
                    Customer = person,
                    Flight = flight,   
                    Passengers = passengers
                };
                _bookingRepository.Create(book);

                return book;

            }
            catch
            {
                throw;
            }



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
