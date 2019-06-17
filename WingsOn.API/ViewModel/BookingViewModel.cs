using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingsOn.Domain;

namespace WingsOn.API.ViewModel
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string FlightId { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public DateTime BookingDate { get; set; }
    }
}