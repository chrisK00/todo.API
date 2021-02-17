using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.Data;
using todo.Data.Models;
using todo.Logic.DTOS;

namespace todo.Logic.Services
{
    public class TodosService : ITodosService
    {
        private readonly ITodosRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodosService(ITodosRepository repo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos() => await _repo.GetAll();

        public async Task<Todo> GetTodo(Guid id) => await _repo.GetById(id);

        /// <summary>
        /// Adds a new todo to the Db 
        /// </summary>
        /// <param name="todoToAddDTO"></param>
        /// <returns></returns>
        public async Task<Guid> AddTodo(AddTodoDTO todoToAddDTO)
        {
            var todoToAdd = _mapper.Map<Todo>(todoToAddDTO);
            var createdTodo = await _repo.Add(todoToAdd);
            await _unitOfWork.Commit();
            return createdTodo.Id;
        }

        public async Task DeleteTodo(Guid id)
        {
            await _repo.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task UpdateTodo(UpdateTodoDTO todoToUpdateDTO)
        {
            var todoToUpdate = await _repo.GetById(todoToUpdateDTO.Id);
            if (todoToUpdate == null)
            {
                throw new KeyNotFoundException();
            }
            todoToUpdate.Title = todoToUpdateDTO.Title;
            todoToUpdate.Description = todoToUpdateDTO.Description;
            todoToUpdate.Completed = todoToUpdateDTO.Completed;

            await _unitOfWork.Commit();
        }

    }
}
