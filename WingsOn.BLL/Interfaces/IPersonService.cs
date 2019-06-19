using WingsOn.Domain;

namespace WingsOn.BLL
{
    public interface IPersonService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Person GetById(int Id);
        /// <summary>
        /// Updates the person patially.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="person">The person.</param>
        /// <returns></returns>
        Person UpdatePersonPatially(int id,Person person);
    }
}