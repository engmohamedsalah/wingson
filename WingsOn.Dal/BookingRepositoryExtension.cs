using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WingsOn.Domain;

namespace WingsOn.Dal
{

    public class BookingRepositoryExtension : BookingRepository
    {
        public IQueryable<Person> GetPassengersInFlight(string flightNumber) 
        {

            var passengers = from rep in Repository
                         where rep.Flight.Number == flightNumber
                         select rep.Passengers;

            return passengers.SelectMany(a=>a).AsQueryable();
        }
        public IQueryable<Person> GetPassengersByGender(GenderType gender)
        {

            var passengers = Repository.SelectMany(a => a.Passengers)
                                        .Where(a=>a.Gender == gender).Distinct();

                             
            return passengers.AsQueryable();
        }
    }
}
