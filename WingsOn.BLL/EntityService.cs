using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Dal;
using WingsOn.Domain;
using System.Linq.Dynamic;

namespace WingsOn.BLL
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="WingsOn.BLL.IEntityService{T}" />
    public abstract class EntityService<T> : IEntityService<T> where T : DomainObject
    {

        IRepository<T> _repository;

        public EntityService(IRepository<T> repository)
        {
           
            _repository = repository;
        }

        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Save(entity);
           
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Save(entity);

        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Gets the specified sidx.
        /// </summary>
        /// <param name="sidx">The sort index.</param>
        /// <param name="sord">The sord direction.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns></returns>
        //public virtual IQueryable<T> Get(string sidx, string sord, int page, int pageCount)
        //{
        //    var pageSize = (page - 1) * pageCount;
        //    return _repository.GetAll().Skip(pageSize).Take(pageCount).AsQueryable()
        //        .OrderBy(sidx + " " + sord).AsQueryable();
        //}
    }
}
