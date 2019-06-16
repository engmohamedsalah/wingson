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


        public Booking GetById(int Id)
        {
            return _bookingRepository.Get(Id);
        }

        public IEnumerable<Person> GetPassengersByGender(GenderType gender)
        {
            
            return _bookingRepository.GetPassengersByGender(gender);
        }

        public IEnumerable<Person> GetPassengersInFlight(string flightNumber)
        {
            return _bookingRepository.GetPassengersInFlight(flightNumber);
        }
    }
}
