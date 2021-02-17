using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Data.Models;

namespace todo.Data
{
    public interface ITodosRepository
    {
        Task<List<Todo>> GetAll();
        Task<Todo> GetById(Guid id);
        Task<Todo> Add(Todo todo);
        Task Delete(Guid id);
    }
}
