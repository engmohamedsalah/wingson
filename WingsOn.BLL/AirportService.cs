using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WingsOn.BLL.EntityService{WingsOn.Domain.Airport}" />
    /// <seealso cref="WingsOn.BLL.IAirportService" />
    public class AirportService : EntityService<Airport>, IAirportService
    {
        //reference to AirportRepository
        AirportRepository _airportRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="AirportService"/> class.
        /// </summary>
        /// <param name="airportRepository">The airport repository.</param>
        public AirportService(AirportRepository airportRepository)
            : base(airportRepository)
        {

            _airportRepository = airportRepository;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Airport GetById(int Id)
        {
            return _airportRepository.Get(Id);
        }
    }
}
