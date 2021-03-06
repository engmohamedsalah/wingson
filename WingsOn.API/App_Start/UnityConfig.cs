using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WingsOn.BLL;

namespace WingsOn.API
{
    /// <summary>
    /// this is configuration for IOC
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registers the components. for the Business service
        /// </summary>
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            //register person service
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IFlightService, FlightService>();
            container.RegisterType<IBookingService, BookingService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}