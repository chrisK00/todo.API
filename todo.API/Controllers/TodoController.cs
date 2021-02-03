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
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoController(ITodoRepository repo, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
        public async Task<IActionResult> AddTodo(TodoToAddDto todoToAddDto)
        {
            var todoToAdd = _mapper.Map<Todo>(todoToAddDto);
         
            var createdTodo = await _repo.Add(todoToAdd);

            await _unitOfWork.Commit();
            //Return a 201 and where the item can be found
            return Created("Todo", createdTodo.Id);
        }

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
