using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using todo.Logic.DTOS;
using todo.Logic.Services;

namespace todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //controller base?
    public class TodosController : ControllerBase
    {
        private readonly ITodosService _todosService;

        public TodosController(ITodosService todosService)
        {
            _todosService = todosService;
        }

        /// <summary>
        /// Gets all existing todos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _todosService.GetAllTodos());

        /// <summary>
        /// Returns a todo if found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(Guid id)
        {
            var todo = await _todosService.GetTodo(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        /// <summary>
        /// Returns a 201 and where the item can be found
        /// </summary>
        /// <param name="todoToAddDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoDTO todoToAddDTO) =>
             Created("Todo", await _todosService.AddTodo(todoToAddDTO));

        /// <summary>
        /// Deletes a todo using its guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            await _todosService.DeleteTodo(id);
            return NoContent();
        }

        /// <summary>
        /// Replaces an existing todo by assigning the old props to the one sent in. We only need [FromBody] if it isnt an entity in the incoming request
        /// </summary>
        /// <param name="todoToReplaceDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ReplaceTodo(Guid id, [FromBody] ReplaceTodoDTO todoToReplaceDTO)
        {
            await _todosService.ReplaceTodo(id,todoToReplaceDTO);
            return NoContent();
        }

        /// <summary>
        /// Updates a todo
        /// </summary>
        /// <param name="todoToUpdateDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpPatch("{id}")]
       public async Task<IActionResult> UpdateTodo(Guid id,[FromBody] UpdateTodoDTO todoToUpdateDTO)
        {
            await _todosService.UpdateTodo(id,todoToUpdateDTO);
            return NoContent();
        }
    }
}
