using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo.API.Data
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
