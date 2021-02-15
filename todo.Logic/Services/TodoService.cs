using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.Data;
using todo.Data.Models;
using todo.Logic.Dtos;

namespace todo.Logic.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoService(ITodoRepository repo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos() => await _repo.GetAll();

        public async Task<Todo> GetTodo(Guid id)
        {
            var todo = await _repo.GetById(id);
            //if todo is null return null otherwise return todo
            return todo ?? null;
        }

        /// <summary>
        /// Adds a new todo to the Db 
        /// </summary>
        /// <param name="todoToAddDto"></param>
        /// <returns></returns>
        public async Task<Guid> AddTodo(AddTodoDto todoToAddDto)
        {
            var todoToAdd = _mapper.Map<Todo>(todoToAddDto);
            var createdTodo = await _repo.Add(todoToAdd);
            await _unitOfWork.Commit();
            return createdTodo.Id;
        }

        public async Task<bool> DeleteTodo(Guid id)
        {
            try
            {
                await _repo.Delete(id);
            }
            catch
            {
                return false;
            }

            await _unitOfWork.Commit();
            return true;
        }

        public async Task<bool> UpdateTodo(UpdateTodoDto todoToUpdateDto)
        {
            var todoToUpdate = await _repo.GetById(todoToUpdateDto.Id);
            if (todoToUpdate == null)
            {
                return false;
            }
            todoToUpdate.Title = todoToUpdateDto.Title;
            todoToUpdate.Description = todoToUpdateDto.Description;
            todoToUpdate.Completed = todoToUpdateDto.Completed;

            await _unitOfWork.Commit();
            return true;
        }

    }
}
