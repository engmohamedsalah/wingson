using System.Collections.Generic;
using WingsOn.Domain;

namespace WingsOn.BLL
{
    public interface IEntityService<T> : IService
     where T : DomainObject
    {
        void Create(T entity);
        //void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}