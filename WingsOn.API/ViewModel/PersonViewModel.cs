using System;
using WingsOn.Domain;

namespace WingsOn.API.ViewModel
{
    public class PersonViewModel
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public GenderType Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public int Id { get; set; }
    }
}
