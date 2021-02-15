using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Data.Models;
using todo.Logic.Dtos;

namespace todo.Logic.Services
{
    public interface ITodoService
    {
        Task<Guid> AddTodo(AddTodoDto todoToAddDto);
        Task<bool> DeleteTodo(Guid id);
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodo(Guid id);
        Task<bool> UpdateTodo(UpdateTodoDto todoToUpdateDto);
    }
}