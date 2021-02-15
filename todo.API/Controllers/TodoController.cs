using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using todo.Data.Models;
using todo.Data;
using AutoMapper;
using todo.Logic.Services;
using todo.Logic.Dtos;

namespace todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //controller base?
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// Gets all existing todos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _todoService.GetAllTodos());

        /// <summary>
        /// Returns a todo if found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(Guid id)
        {
            var todo = await _todoService.GetTodo(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        /// <summary>
        /// Returns a 201 and where the item can be found
        /// </summary>
        /// <param name="todoToAddDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoDto todoToAddDto) =>
             Created("Todo", await _todoService.AddTodo(todoToAddDto));

        /// <summary>
        /// Deletes a todo using its guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            if (!await _todoService.DeleteTodo(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        /// Updates an existing todo by assigning the old props to the one sent in
        /// </summary>
        /// <param name="todoToUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoDto todoToUpdateDto)
        {
            if (!await _todoService.UpdateTodo(todoToUpdateDto))
            {
                return NotFound();
            }
            return NoContent();
        }

        //Todo 
        //patch - completed todo?
    }
}
