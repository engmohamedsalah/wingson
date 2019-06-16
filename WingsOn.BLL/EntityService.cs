using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Dal;
using WingsOn.Domain;


namespace WingsOn.BLL
{
    public abstract class EntityService<T> : IEntityService<T> where T : DomainObject
    {

        IRepository<T> _repository;

        public EntityService(IRepository<T> repository)
        {
           
            _repository = repository;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Save(entity);
           
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Save(entity);

        }
        

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
