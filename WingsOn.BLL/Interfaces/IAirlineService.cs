using WingsOn.Domain;

namespace WingsOn.BLL
{
    /// <summary>
    /// interface for Airline Service
    /// </summary>
    public interface IAirlineService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Airline GetById(int Id);

    }
}