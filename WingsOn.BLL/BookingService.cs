using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using WingsOn.BLL.ExceptionHandling;
using WingsOn.BLL.Helper;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WingsOn.BLL.EntityService{WingsOn.Domain.Booking}" />
    /// <seealso cref="WingsOn.BLL.IBookingService" />
    public class BookingService : EntityService<Booking>, IBookingService
    {
        //reference to BookingRepository
        BookingRepository _bookingRepository;
        //reference to FlightRepository
        FlightRepository _flightRepository;
        //reference to PersonRepository
        PersonRepository _personRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="BookingService"/> class.
        /// </summary>
        /// <param name="bookingRepository">The booking repository.</param>
        /// <param name="flightRepository">The flight repository.</param>
        /// <param name="personRepository">The person repository.</param>
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

                //create new Booking
                var book = new Booking()
                {
                    DateBooking = DateTime.Now,
                    Number = flightNumber,
                    Customer = person,
                    Flight = flight,
                    Passengers = passengers
                };
                //add the new object to the repository
                _bookingRepository.Create(book);

                return book;

            }
            catch
            {
                throw;
            }



        }
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Booking GetById(int Id)
        {
            return _bookingRepository.Get(Id);
        }

        /// <summary>
        /// Gets the passengers by gender.
        /// </summary>
        /// <param name="gender">The gender.</param>
        /// <returns></returns>
        public IEnumerable<Person> GetPassengersByGender(GenderType gender)
        {
            var passengers = _bookingRepository.GetAll().SelectMany(a => a.Passengers)
                                      .Where(a => a.Gender == gender).Distinct();

            
            return passengers.AsQueryable();
        }
        public IEnumerable<Person> GetPassengersByGender(GenderType gender, string sidx, string sord, int page, int pageCount)
        {
            var passengers = _bookingRepository.GetAll()
                              .SelectMany(a => a.Passengers.Where(b => b.Gender == gender))
                             .GetSortedPagedData(sidx, sord, page, pageCount)
                              ;
            return passengers;
        }
        /// <summary>
        /// Gets the passengers in flight.
        /// </summary>
        /// <param name="flightNumber">The flight number.</param>
        /// <returns></returns>
        public IEnumerable<Person> GetPassengersInFlight(string flightNumber)
        {
            var passengers = from rep in _bookingRepository.GetAll()
                             where rep.Flight.Number == flightNumber
                             select rep.Passengers;

            return passengers.SelectMany(a => a).AsQueryable();
        }
    }
}
