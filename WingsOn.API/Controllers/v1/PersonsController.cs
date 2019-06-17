using AutoMapper;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WingsOn.API.ExceptionHandler.FilterException;
using WingsOn.API.ViewModel;
using WingsOn.BLL;
using WingsOn.BLL.ExceptionHandling;
using WingsOn.Domain;

namespace WingsOn.API.Controllers.v1
{
    /// <summary>
    /// this controller resposibple for API related to
    /// 1- Get Person with ID
    /// 2- update Person Email
    /// </summary>
    /// <seealso cref="WingsOn.API.Controllers.BaseAPIController" />
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Persons")]
    public class PersonsController : BaseAPIController
    {

        IPersonService _personService;
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsController"/> class.
        /// </summary>
        /// <param name="personService">The person service.</param>
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Endpoint that returns a person by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Person/5
        [CustomExceptionHandling]
        public IHttpActionResult Get(int id)
        {
            //Validation of for the id to 
            //check if it greater than 
            if(id<=0)
            {
                // throw new IdNotValidException();
                throw new IdOrNumberNotValidException();
            }
            // get required person with Id
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            var result = Mapper.Map<PersonViewModel>(person);
            return Ok(result);
           
           
        }
        
         
        /// <summary>
        /// Endpoint that updates a person’s email address
        /// </summary>
        [HttpPatch()]
            
        public IHttpActionResult Patch(int id, [FromBody]PersonPatchViewModel updatedPerson)
        {
            try
            {
                _personService.UpdatePersonPatially(id, Mapper.Map<Person>(updatedPerson) );
            }
            catch (ObjectNotExistWithIdException)
            {
                // throw new IdNotValidException();
                throw new IdOrNumberNotValidException();
            }
            catch (InValidEmailException)
            {
                throw new EmailValidException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            var person = _personService.GetById(id);
            return Ok(person);
        }

    }
}
