using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Data.Models;

namespace todo.Data
{
    public interface ITodosRepository
    {
        /// <summary>
        /// Dont need to await one liners, parent does that
        /// </summary>
        /// <returns></returns>
        Task<List<Todo>> GetAll();

        /// <summary>
        /// Returns null if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Todo> GetById(Guid id);

        Task Add(Todo todo);

        Task Delete(Guid id);
    }
}