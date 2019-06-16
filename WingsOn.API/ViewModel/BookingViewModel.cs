using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WingsOn.API.ViewModel
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public PersonViewModel Person { get; set; }
    }
}