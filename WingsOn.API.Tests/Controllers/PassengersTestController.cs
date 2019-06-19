using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WingsOn.API;
using WingsOn.API.Controllers;
using WingsOn.API.Controllers.v1;
using Moq;
using WingsOn.BLL;
using System.Net.Http;
using System.Web.Http;
using WingsOn.API.ViewModel;
using System.Web.Http.Results;
using WingsOn.Dal;
using WingsOn.Domain;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Globalization;

namespace WingsOn.API.Tests.Controllers
{
    [TestClass]
    public class PassengersTestController
    {
        private Mock<IFlightService> flighServiceMock;
        private Mock<IBookingService> bookingServiceMock;
        PassengersController objController;
        List<Person> listPassengers;
        
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            Mapper.Reset();
            AutoMapperConfig.Register();
        }
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            flighServiceMock = new Mock<IFlightService>();
            bookingServiceMock = new Mock<IBookingService>();
            objController = new PassengersController(flighServiceMock.Object, bookingServiceMock.Object);
            CultureInfo cultureInfo = new CultureInfo("nl-NL");

            listPassengers = new List<Person>()
            {
                new Person
                {
                    Id = 77,
                    Address = "P.O. Box 795, 1956 Odio. Rd.",
                    DateBirth = DateTime.Parse("01/01/1940", cultureInfo),
                    Email = "egestas.lacinia@Proinmi.com",
                    Gender = GenderType.Male,
                    Name = "Branden Johnston"
                },
                new Person
                {
                    Id = 96,
                    Address = "P.O. Box 660, 6702 Nunc St.",
                    DateBirth = DateTime.Parse("17/03/1981", cultureInfo),
                    Email = "leo.in.lobortis@accumsanconvallisante.ca",
                    Gender = GenderType.Male,
                    Name = "Germaine Fowler"
                },
            };



        }
        /// <summary>
        /// Gets the passengers on flight.
        /// </summary>
        [TestMethod]
        public void GetPassengersOnFlight()
        {
            //Arrange
            bookingServiceMock.Setup(a => a.GetPassengersInFlight(It.IsAny<string>())).Returns(listPassengers);

            // Act
            IHttpActionResult actionResult = objController.Get("BB124");
            var contentResult = actionResult as OkNegotiatedContentResult<List<PersonViewModel>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            bookingServiceMock.Verify(a => a.GetPassengersInFlight(It.IsAny<string>()), Times.Once);



        }

        /// <summary>
        /// Gets all male passengers.
        /// </summary>
        [TestMethod]
        public void GetAllMalePassengers()
        {
            //Arrange
            bookingServiceMock.Setup(a => a.GetPassengersByGender(It.IsAny<GenderType>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(listPassengers);

            // Act
            IHttpActionResult actionResult = objController.Get(GenderType.Male,1,2);
            var contentResult = actionResult as OkNegotiatedContentResult<List<PersonViewModel>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            bookingServiceMock.Verify(a => a.GetPassengersByGender(It.IsAny<GenderType>(), It.IsAny<string>(), 
                It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);

        }
    }
}
