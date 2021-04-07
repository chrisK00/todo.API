using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo.Data;
using todo.Data.Models;
using Xunit;

namespace todo.Tests
{
    public class TodosRepositoryTests
    {
        private readonly DataContext _context;
        private readonly TodosRepository _todosRepo;
        private readonly Guid _todoId;

        public TodosRepositoryTests()
        {
            //creating in memory db
            var contextOptions = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase("todos");
            _context = new DataContext(contextOptions.Options);

            //make sure db is created and seed
            _context.Database.EnsureCreated();
            _todoId = Guid.NewGuid();
            SetupData();

            _todosRepo = new TodosRepository(_context);
        }

        private void SetupData()
        {
            _context.Todos.AddRange(
                new Todo { Id = _todoId },
                new Todo { Id = Guid.NewGuid(), Title = "Hello world", Completed = false }
                );
            _context.SaveChanges();
        }

        [Fact]
        private async Task GetById_Returns_Todo_If_ExistsAsync()
        {
            var result = await _todosRepo.GetById(_todoId);
            Assert.Equal(result.Id, _todoId);
        }
    }
}