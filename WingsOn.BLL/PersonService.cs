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
    public class PersonService : EntityService<Person>, IPersonService
    {

        PersonRepository _personRepository;

        public PersonService(PersonRepository personRepository)
            : base(personRepository)
        {

            _personRepository = personRepository;
        }


        public Person GetById(int Id)
        {
            return _personRepository.Get(Id);
        }

        public Person UpdatePersonEmail(int id, string email)
        {
            //check if the email is valid
            if (!Validation.IsValidEmail(email))

                throw new InValidEmailException(nameof(email));

            //get the person
            var person = _personRepository.Get(id);
            if (person == null)
                throw new ObjectNotExistWithIdException("Not Exist Person");


            person.Email = email;

            _personRepository.Save(person);

            return person;

        }
    }
}
