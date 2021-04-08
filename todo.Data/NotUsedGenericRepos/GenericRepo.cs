using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace todo.Data.NotUsedGenericRepos
{
    public abstract class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        //the class inhereting might want other features
        protected DataContext _context;

        public GenericRepo(DataContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                 .Where(predicate).ToList();
        }

        public virtual T Get(Guid id)
        {
            return _context.Find<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
