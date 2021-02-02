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
        private readonly DataContext _context;

        //Dependancy injecting our db context
        public TodoController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Retreiving a list of todos from our db and sending back an 200 ok response to the caller
            var todos = await _context.Todos.ToListAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
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

            //Adding the new todo and saving
            await _context.Todos.AddAsync(todoToAdd);
            await _context.SaveChangesAsync();

            //Return a 201 and where the item can be found
            return Created("Todo", todoToAdd.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            //Check if the todo with that id actually exists in the db
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutTodo(TodoToUpdateDto todoToUpdateDto)
        {
            var todoToUpdate = await _context.Todos.FindAsync(todoToUpdateDto.Id);
            if (todoToUpdate == null)
            {
                return NotFound();
            }

            //Assign the new values to the found todo
            todoToUpdate.Title = todoToUpdateDto.Title;
            todoToUpdate.Description = todoToUpdateDto.Description;
            todoToUpdate.Completed = todoToUpdateDto.Completed;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}