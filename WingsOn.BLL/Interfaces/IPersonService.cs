using WingsOn.Domain;

namespace WingsOn.BLL
{
    public interface IPersonService
    {

        Person GetById(int Id);

        Person UpdatePersonEmail(int id,string email);
    }
}