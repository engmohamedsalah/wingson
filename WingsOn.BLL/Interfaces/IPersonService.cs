using WingsOn.Domain;

namespace WingsOn.BLL
{
    public interface IPersonService
    {

        Person GetById(int Id);

        bool UpdatePersonEmail(int id,string email);
    }
}