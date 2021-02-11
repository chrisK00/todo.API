using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using todo.API.Dtos;
using todo.Data.Models;
using todo.Data;
using AutoMapper;

namespace todo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //controller base?
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoController(ITodoRepository repo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all existing todos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        /// <summary>
        /// Returns a todo if found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
       
        /// <summary>
        /// Adds a new todo to the Db
        /// </summary>
        /// <param name="todoToAddDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] AddTodoDto todoToAddDto)
        {
            var todoToAdd = _mapper.Map<Todo>(todoToAddDto);

            var createdTodo = await _repo.Add(todoToAdd);

            await _unitOfWork.Commit();
            //Return a 201 and where the item can be found
            return Created("Todo", createdTodo.Id);
        }

        /// <summary>
        /// Deletes a todo using its guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            //Use a global exception handler instead
            try
            {
                await _repo.Delete(id);
            }
            catch
            {
                return NotFound();
            }
            await _repo.Delete(id);

            await _unitOfWork.Commit();
            return NoContent();
        }

        /// <summary>
        /// Updates an existing todo by assigning the old props to the one sent in
        /// </summary>
        /// <param name="todoToUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateTodo([FromBody]UpdateTodoDto todoToUpdateDto)
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
