using System.Collections.Generic;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    public interface IBookingService
    {

        Booking GetById(int Id);

        IEnumerable<Person> GetPassengersInFlight(string FlightNumber);
        IEnumerable<Person> GetPassengersByGender(GenderType gender);

    }
}