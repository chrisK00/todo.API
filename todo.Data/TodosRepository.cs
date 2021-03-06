﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo.Data.Models;

namespace todo.Data
{
    public class TodosRepository : ITodosRepository
    {
        private readonly DataContext _context;

        public TodosRepository(DataContext context)
        {
            _context = context;
        }

        public Task Add(Todo todo) => _context.Todos.AddAsync(todo).AsTask();

        public async Task Delete(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                throw new KeyNotFoundException();
            }
            _context.Todos.Remove(todo);
        }

        public Task<Todo> GetById(Guid id) =>
             _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

        public Task<List<Todo>> GetAll() => _context.Todos.ToListAsync();
    }
}