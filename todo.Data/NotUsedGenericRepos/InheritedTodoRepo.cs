using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo.Data.Models;

namespace todo.Data.NotUsedGenericRepos
{
    public class InheritedTodoRepo : GenericRepo<Todo>
    {
        public InheritedTodoRepo(DataContext context) : base(context)
        {

        }
        public override Todo Add(Todo entity)
        {
            var todo = _context.Todos.Find(entity);
            if (todo != null)
            {
                throw new ArgumentException("Todo already exists");
            }
            return base.Add(entity);
        }

       /* public override IEnumerable<Todo> Find(Expression<Func<Todo, bool>> predicate)
        {
            return _context.Todos.Include().ThenInclude().Where().ToList();
        }
       */
    }
}
