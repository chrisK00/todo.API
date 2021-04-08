using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.Data
{
    /// <summary>
    /// Not Used since generic repos are considered bad practice not all repos requires the same methods. 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class NotUsedGenericRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        public NotUsedGenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
