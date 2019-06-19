using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain;


namespace WingsOn.Dal
{
    public static class RepositoryBaseExtension
    {

        //this is for ensures that one thread does not enter a critical section
        //this is use for generating the booking id
        private static readonly Object lockObj = new Object();

        /// <summary>
        /// Wheres the specified predict.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="predict">The predict.</param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this RepositoryBase<T> repository,Func<T,bool> predict)
        where T : DomainObject
        {
            return repository.GetAll().Where(predict);
        }
        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="predict">The predict.</param>
        /// <returns></returns>
        public static T SingleOrDefault<T>(this RepositoryBase<T> repository, Func<T, bool> predict)
        where T : DomainObject
        {
            return repository.GetAll().SingleOrDefault(predict);
        }

        /// <summary>
        /// Creates the specified new object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="newObj">The new object.</param>
        /// <returns></returns>
        public static T Create<T>(this RepositoryBase<T> repository,T newObj) where T : DomainObject
        {
            // critical section
            lock (lockObj)
            {
               
                if (newObj.Id == 0)
                {
                    int newId = repository.GetAll().Max(a => a.Id) + 1;
                    newObj.Id = newId;
                }
                repository.Save(newObj);
            }
            return newObj;
        }
       
    }
   
}
