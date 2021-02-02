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

        public TodoController(ITodoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(Guid id)
        {
            var todo = await _repo.Get(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }


        [HttpPost]
        public async Task<IActionResult> PostTodo(TodoToAddDto todoToAddDto)
        {
            var todoToAdd = new Todo()
            {
                Title = todoToAddDto.Title,
                Description = todoToAddDto.Description,
                Completed = false
            };
            var createdTodo = await _repo.Add(todoToAdd);

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
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutTodo(TodoToUpdateDto todoToUpdateDto)
        {
            var todoToUpdate = new Todo
            {
                Title = todoToUpdateDto.Title,
                Completed = todoToUpdateDto.Completed,
                Description = todoToUpdateDto.Description
            };
            bool updated = await _repo.Update(todoToUpdate);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}