using System.Collections.Generic;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    public interface IBookingService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Booking GetById(int Id);
        /// <summary>
        /// Gets the passengers in flight.
        /// </summary>
        /// <param name="FlightNumber">The flight number.</param>
        /// <returns></returns>
        IEnumerable<Person> GetPassengersInFlight(string FlightNumber);
        /// <summary>
        /// Gets the passengers by gender.
        /// </summary>
        /// <param name="Gender">The gender.</param>
        /// <returns></returns>
        IEnumerable<Person> GetPassengersByGender(GenderType Gender);
        /// <summary>
        /// Gets the passengers by gender with pagging and sorting.
        /// </summary>
        /// <param name="Gender">The gender.</param>
        /// <param name="sidx">The sidx.</param>
        /// <param name="sord">The sord.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns></returns>
        IEnumerable<Person> GetPassengersByGender(GenderType Gender, string sidx, string sord, int page, int pageCount);

        /// <summary>
        /// Creates new Booking with specified flight number and new user.
        /// </summary>
        /// <param name="FlightNumber">The flight number.</param>
        /// <param name="Person">The person.</param>
        /// <returns></returns>
        Booking Create(string FlightNumber, Person Person);

    }
}