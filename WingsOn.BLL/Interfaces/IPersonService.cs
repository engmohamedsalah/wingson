using WingsOn.Domain;

namespace WingsOn.BLL
{
    public interface IPersonService
    {

        Person GetById(int Id);
        Person UpdatePersonPatially(int id,Person person);
    }
}