using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace todo.Data.NotUsedGenericRepos
{
    public interface IGenericRepo<T> where T : class
    {
        /// <summary>
        /// Adds a entity to EF which starts to track it
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>the entity that was just created by the context</returns>
        T Add(T entity);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        /// <summary>
        /// Send in a expression, func bool if should return or not
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
