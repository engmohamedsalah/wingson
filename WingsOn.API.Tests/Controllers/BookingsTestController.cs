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

namespace WingsOn.API.Tests.Controllers
{
    [TestClass]
    public class BookingsTestController
    {
        private Mock<IBookingService> bookingServiceMock;
        BookingsController objController;

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
            bookingServiceMock = new Mock<IBookingService>();
            objController = new BookingsController(bookingServiceMock.Object);
            
        }
        /// <summary>
        /// Gets the passengers on flight.
        /// </summary>
        [TestMethod]
        public void CreateNewBooking()
        {
            //Arrange
            var newBooking = new NewBookingViewModel()
            {
                FlightNumber = "BB124",
                Person = new PersonViewModel()
                {
                    Address = "123 street",
                    DateBirth = new DateTime(1985,5,5),
                    Email = "testyahoo.com",
                    Gender = GenderType.Male,
                    Name = "Adam lalana"
                }

            };
            bookingServiceMock.Setup(a => a.Create(It.IsAny<string>(), It.IsAny<Person>())).Returns(new Booking() {
                DateBooking = DateTime.Now,
                Id = 5200,
                Number = "BB124"
            });
            // Act
            IHttpActionResult actionResult = objController.Post(newBooking);
            var contentResult = actionResult as OkNegotiatedContentResult<BookingViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            bookingServiceMock.Verify(a => a.Create(It.IsAny<string>(),It.IsAny<Person>()), Times.Once);



        }
        
    }
}
