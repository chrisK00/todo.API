using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.Data;
using todo.Logic.Dtos;

namespace todo.Logic.Services
{
    public class TodoService
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
