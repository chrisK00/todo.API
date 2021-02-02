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
            return true;
        }

        /// <summary>
        /// Returns null if not found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Todo> GetById(Guid id) => await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<Todo>> GetAll() => await _context.Todos.ToListAsync();

    }
}
