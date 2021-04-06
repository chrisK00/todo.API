using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using todo.Data;
using todo.Data.Models;
using todo.Logic.DTOS;
using todo.Logic.Helpers;
using todo.Logic.Services;
using Xunit;

namespace todo.Tests
{
    public class TodosServiceTests
    {
        private readonly Mock<ITodosRepository> _todosRepo;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly MapperConfiguration _mapper;
        private readonly ITodosService _todosService;
        private readonly Guid _todoId;

        public TodosServiceTests()
        {
            _todosRepo = new Mock<ITodosRepository>();
            _uow = new Mock<IUnitOfWork>();
            _mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfiles>());
            _todoId = Guid.NewGuid();

            SetupData();

            _todosService = new TodosService(_todosRepo.Object, _uow.Object, new Mapper(_mapper));
        }

        private void SetupData()
        {        
            _todosRepo.Setup(x => x.GetById(_todoId)).ReturnsAsync(
                new Todo { Id = _todoId });

        }

        [Fact]
        public async Task Should_Return_Todo_If_Exists()
        {
            var result = await _todosService.GetTodo(_todoId);

            Assert.Equal(result.Id, _todoId);
            Assert.NotEqual(result.Id, Guid.NewGuid());
        }

        [Fact]
        public async Task AddTodo_Should_Return_New_Guid()
        {
            var result = await _todosService.AddTodo(new AddTodoDTO { Title = "Hi" });

            Assert.NotEqual(result, Guid.Empty);
        }
    }
}
