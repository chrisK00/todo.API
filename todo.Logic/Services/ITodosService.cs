using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Data.Models;
using todo.Logic.DTOS;

namespace todo.Logic.Services
{
    public interface ITodosService
    {
        Task<Guid> AddTodo(AddTodoDTO todoToAddDto);
        Task DeleteTodo(Guid id);
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodo(Guid id);
        Task UpdateTodo(UpdateTodoDTO todoToUpdateDto);
    }
}