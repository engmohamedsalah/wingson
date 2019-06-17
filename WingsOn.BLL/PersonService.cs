using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.BLL.ExceptionHandling;
using WingsOn.BLL.Helper;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    /// <summary>
    /// this service resposible for serve any operation done in PersonRepository 
    /// </summary>
    /// <seealso cref="WingsOn.BLL.EntityService{WingsOn.Domain.Person}" />
    /// <seealso cref="WingsOn.BLL.IPersonService" />
    public class PersonService : EntityService<Person>, IPersonService
    {
        //reference to PersonRepository
        PersonRepository _personRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="personRepository">The person repository.</param>
        public PersonService(PersonRepository personRepository)
            : base(personRepository)
        {

            _personRepository = personRepository;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Person GetById(int Id)
        {
            return _personRepository.Get(Id);
        }
        /// <summary>
        /// Updates the person patially.
        /// if any prop in the Person class empty the it will be ignore int the update
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="updatePerson">The update person.</param>
        /// <returns></returns>
        /// <exception cref="ObjectNotExistWithIdException">Not Exist Person</exception>
        /// <exception cref="InValidEmailException">Email</exception>
        public Person UpdatePersonPatially(int id, Person updatePerson)
        {

            //get the person
            var person = _personRepository.Get(id);
            if (person == null)
                throw new ObjectNotExistWithIdException("Not Exist Person");

            //check if the email is valid
            if (!string.IsNullOrEmpty(updatePerson.Email) && !Checker.IsValidEmail(updatePerson.Email))

                throw new InValidEmailException(nameof(updatePerson.Email));
            else
                person.Email = updatePerson.Email;
           
             
           //this part for future use
            if (!string.IsNullOrEmpty(updatePerson.Address))
                person.Address = updatePerson.Address;
            if (updatePerson.DateBirth!=null)
                person.DateBirth = updatePerson.DateBirth;

            //save to the personRepository
            _personRepository.Save(person);

            return person;

        }
    }
}
