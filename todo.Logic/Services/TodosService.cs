﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
            todoToAdd.Id = Guid.NewGuid();
            await _repo.Add(todoToAdd);
            await _unitOfWork.Commit();
            return todoToAdd.Id;
        }

        public async Task DeleteTodo(Guid id)
        {
            await _repo.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task ReplaceTodo(Guid id, ReplaceTodoDTO todoToReplaceDTO)
        {
            var todoToUpdate = await _repo.GetById(id);
            if (todoToUpdate == null)
            {
                throw new KeyNotFoundException();
            }
            todoToUpdate.Title = todoToReplaceDTO.Title;
            todoToUpdate.Description = todoToReplaceDTO.Description;
            todoToUpdate.Completed = todoToReplaceDTO.Completed;

            await _unitOfWork.Commit();
        }

        public async Task UpdateTodo(Guid id, UpdateTodoDTO todoToUpdateDTO)
        {
            var todoToUpdate = await _repo.GetById(id);
            if (todoToUpdate == null)
            {
                throw new KeyNotFoundException();
            }

            //Ef wont track in case of property being null
            todoToUpdate.Title = todoToUpdateDTO.Title ?? todoToUpdate.Title;
            todoToUpdate.Completed = todoToUpdateDTO.Completed ?? todoToUpdate.Completed;
            todoToUpdate.Description = todoToUpdateDTO.Description ?? todoToUpdate.Description;

            await _unitOfWork.Commit();
        }
    }
}