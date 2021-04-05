using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using todo.Data;
using todo.Data.Models;
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

        public TodosServiceTests()
        {
            _todosRepo = new Mock<ITodosRepository>();
            _uow = new Mock<IUnitOfWork>();
            _mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfiles>());

            SetupData();

            _todosService = new TodosService(_todosRepo.Object, _uow.Object, new Mapper(_mapper));
        }

        private void SetupData()
        {
            var guid = Guid.Parse("69F720212993462DB69563C1B61349D1");
            _todosRepo.Setup(x => x.GetById(guid)).ReturnsAsync(
                new Todo { Id = Guid.Parse("69F720212993462DB69563C1B61349D1") });
        }

        [Fact]
        public async Task Should_Return_Todo_If_Exists()
        {
            var result = await _todosService.GetTodo(Guid.Parse("69F720212993462DB69563C1B61349D1"));

            Assert.Equal(result.Id, Guid.Parse("69F720212993462DB69563C1B61349D1"));
        }
    }
}
