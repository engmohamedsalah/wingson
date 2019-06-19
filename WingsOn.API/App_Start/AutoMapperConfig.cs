using AutoMapper;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WingsOn.API.ViewModel;
using WingsOn.BLL;
using WingsOn.Domain;

namespace WingsOn.API
{
    /// <summary>
    /// this class contains the required mapping between the 
    /// view and view Models
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Registers this instance.
        /// </summary>
        public static void Register()
        {
            //define mapping objects
            Mapper.Initialize(cfg =>
            {
                //mapping between Person and PersonViewModel
                cfg.CreateMap<Person, PersonViewModel>();
                cfg.CreateMap<PersonPatchViewModel, Person>();

                cfg.CreateMap<Booking,BookingViewModel> ()
                .ForMember(a => a.Id, b => b.MapFrom(c => c.Id))
                .ForMember(a => a.BookingDate , b => b.MapFrom(c => c.DateBooking))
                
                .ForMember(a => a.FlightId , b => b.MapFrom(c => c.Flight.Id))
                .ForMember(a => a.FlightNumber , b => b.MapFrom(c => c.Flight.Number))
                .ForMember(a => a.PersonId , b => b.MapFrom(c => c.Customer.Id))
                .ForMember(a => a.Person , b => b.MapFrom(c => c.Customer));

            });
        }
    }
}