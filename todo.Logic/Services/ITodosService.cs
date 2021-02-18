using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using todo.Data.Models;
using todo.Logic.DTOS;

namespace todo.Logic.Services
{
    public interface ITodosService
    {
        Task<Guid> AddTodo(AddTodoDTO todoToAddDTO);
        Task DeleteTodo(Guid id);
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodo(Guid id);
        Task ReplaceTodo(Guid id, ReplaceTodoDTO todoToReplaceDTO);
        Task UpdateTodo(Guid id, UpdateTodoDTO todoToUpdateDTO);
    }
}