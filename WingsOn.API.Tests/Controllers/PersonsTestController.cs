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
    public class PersonsTestController
    {
        private Mock<IPersonService> personServiceMock;
        PersonsController objController;
        Person person;

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
            personServiceMock = new Mock<IPersonService>();
            objController = new PersonsController(personServiceMock.Object);

            person = new Person
            {
                Id = 77,
                Address = "P.O. Box 795, 1956 Odio. Rd.",
                DateBirth = new DateTime(1980, 5, 5),
                Email = "egestas.lacinia@Proinmi.com",
                Gender = GenderType.Male,
                Name = "Branden Johnston"
            };



        }
        /// <summary>
        /// Gets the person by identifier.
        /// </summary>
        [TestMethod]
        public void GetPersonById()
        {
            //Arrange
            personServiceMock.Setup(a => a.GetById(It.IsAny<int>())).Returns(person);

            // Act
            IHttpActionResult actionResult = objController.Get(77);
            var contentResult = actionResult as OkNegotiatedContentResult<PersonViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("Branden Johnston", contentResult.Content.Name);
        }
        /// <summary>
        /// Updates the person email.
        /// </summary>
        [TestMethod]
        public void UpdatePersonEmail()
        {
            //Arrange
            string newMail = "newMail@yahoo.com";
            person.Email = newMail;
            personServiceMock.Setup(a => a.GetById(It.IsAny<int>())).Returns(person);
            // Act
            IHttpActionResult actionResult = objController.Patch(77, new PersonPatchViewModel() { Email = newMail });
            var contentResult = actionResult as OkNegotiatedContentResult<PersonViewModel>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(newMail, contentResult.Content.Email);
        }

    }
}
