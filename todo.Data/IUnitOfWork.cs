using System.Threading.Tasks;

namespace todo.Data
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
