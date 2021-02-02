using System.Threading.Tasks;

namespace todo.API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task Commit() => await _context.SaveChangesAsync();

    }
}
