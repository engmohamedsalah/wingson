using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    public class AirportService : EntityService<Airport>, IAirportService
    {

        AirportRepository _airportRepository;

        public AirportService(AirportRepository airportRepository)
            : base(airportRepository)
        {

            _airportRepository = airportRepository;
        }


        public Airport GetById(int Id)
        {
            return _airportRepository.Get(Id);
        }
    }
}
