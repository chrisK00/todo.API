using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo.API.Dtos;
using todo.API.Models;

namespace todo.API.Data
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAll();
        Task<Todo> Get(Guid id);
        Task<Todo> Add(Todo todo);
        Task<bool> Update(Todo todo);
        Task<bool> Delete(Guid id);
    }
}
