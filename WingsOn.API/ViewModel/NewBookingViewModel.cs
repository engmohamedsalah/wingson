using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingsOn.Domain;

namespace WingsOn.API.ViewModel
{
    public class NewBookingViewModel
    {
        public string FlightNumber { get; set; }
        public PersonViewModel Person { get; set; }
    }
}