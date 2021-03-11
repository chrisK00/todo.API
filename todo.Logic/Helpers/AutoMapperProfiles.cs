using AutoMapper;
using todo.Data.Models;
using todo.Logic.DTOS;

namespace todo.Logic.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddTodoDTO, Todo>();
        }
    }
}