using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo.API.Models;

namespace todo.API.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Todo> Add(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> Delete(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return false;
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Todo> Get(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return null;
            }
            return todo;
        }

        public async Task<List<Todo>> GetAll() => await _context.Todos.ToListAsync();

        public async Task<bool> Update(Todo todo)
        {
            var todoToUpdate = await _context.Todos.FindAsync(todo.Id);
            if (todoToUpdate == null)
            {
                return false;
            }

            todoToUpdate.Title = todo.Title;
            todoToUpdate.Description = todo.Description;
            todoToUpdate.Completed = todo.Completed;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
