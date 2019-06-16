using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool UpdatePersonEmail(int id,string email)
        {
            //check if the email is valid
            if (!Validation.IsValidEmail(email))

                throw new Exception("InValid Email");

            //get the person
            var person = _personRepository.Get(id);
            if (person == null)
                throw new Exception("InValid Email");

            else
                person.Email = email;

            _personRepository.Save(person);

            return false;

        }
    }
}
