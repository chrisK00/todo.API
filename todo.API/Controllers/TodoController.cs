using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using todo.API.Data;
using todo.API.Dtos;
using todo.API.Models;

namespace todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repo;
        private readonly IUnitOfWork _unitOfWork;

        public TodoController(ITodoRepository repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(Guid id)
        {
            var todo = await _repo.GetById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateTodo(TodoToAddDto todoToAddDto)
        {
            var todoToAdd = new Todo()
            {
                Title = todoToAddDto.Title,
                Description = todoToAddDto.Description,
                Completed = false
            };
            var createdTodo = await _repo.Add(todoToAdd);

            await _unitOfWork.Commit();
            //Return a 201 and where the item can be found
            return Created("Todo", createdTodo.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            bool deleted = await _repo.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }
            await _unitOfWork.Commit();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo(TodoToUpdateDto todoToUpdateDto)
        {
            var todoToUpdate = await _repo.GetById(todoToUpdateDto.Id);
            if (todoToUpdate == null)
            {
                return NotFound();
            }

            todoToUpdate.Title = todoToUpdateDto.Title;
            todoToUpdate.Description = todoToUpdateDto.Description;
            todoToUpdate.Completed = todoToUpdateDto.Completed;

            await _unitOfWork.Commit();
            return NoContent();

        }
    }
}