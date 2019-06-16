using WingsOn.Domain;

namespace WingsOn.BLL
{
    public interface IAirlineService
    {

        Airline GetById(int Id);

    }
}