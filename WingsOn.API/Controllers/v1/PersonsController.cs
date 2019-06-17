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

namespace WingsOn.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Persons")]
    public class PersonsController : BaseAPIController
    {

        IPersonService _personService;

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
            
        public IHttpActionResult Patch(int id, string email)
        {
            try
            {
                _personService.UpdatePersonEmail(id, email);
            }
            catch (ObjectNotExistWithIdException)
            {
                // throw new IdNotValidException();
                throw new IdOrNumberNotValidException();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            var person = _personService.GetById(id);
            return Ok(person);
        }

        // DELETE: api/Person/5
        //public void Delete(int id)
        //{
        //}
    }
}
