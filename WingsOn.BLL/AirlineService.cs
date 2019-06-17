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
    /// this service resposible for serve any operation done in AirlineRepository
    /// </summary>
    /// <seealso cref="WingsOn.BLL.EntityService{WingsOn.Domain.Airline}" />
    /// <seealso cref="WingsOn.BLL.IAirlineService" />
    public class AirlineService : EntityService<Airline>, IAirlineService
    {
        //reference to AirlineRepository
        AirlineRepository _AirlineRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AirlineService"/> class.
        /// </summary>
        /// <param name="AirlineRepository">The airline repository.</param>
        public AirlineService(AirlineRepository AirlineRepository)
            : base(AirlineRepository)
        {

            _AirlineRepository = AirlineRepository;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Airline GetById(int Id)
        {
            return _AirlineRepository.Get(Id);
        }
    }
}
