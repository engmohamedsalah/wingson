using WingsOn.Domain;

namespace WingsOn.BLL
{
    /// <summary>
    /// interface for Airport Service 
    /// </summary>
    public interface IAirportService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Airport GetById(int Id);

    }
}