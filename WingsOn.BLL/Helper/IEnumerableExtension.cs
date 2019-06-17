using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WingsOn.Domain;
using System.Linq.Dynamic;
namespace WingsOn.BLL.Helper
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Gets the sorted paged data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <param name="sidx">The sort key .</param>
        /// <param name="sord">The sort direction.</param>
        /// <param name="page">The page number.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetSortedPagedData<T>(this IEnumerable<T> data, string sidx, string sord, int page, int pageCount)
        {

            var pageSize = (page - 1) * pageCount;
            return data.Skip(pageSize).Take(pageCount).AsQueryable()
                .OrderBy(sidx + " " + sord).AsQueryable();
        }
    }
}
