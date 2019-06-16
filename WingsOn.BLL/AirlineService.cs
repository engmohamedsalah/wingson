using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    public class AirlineService : EntityService<Airline>, IAirlineService
    {
       
        AirlineRepository _AirlineRepository;

        public AirlineService(AirlineRepository AirlineRepository)
            : base(AirlineRepository)
        {

            _AirlineRepository = AirlineRepository;
        }


        public Airline GetById(int Id)
        {
            return _AirlineRepository.Get(Id);
        }
    }
}
