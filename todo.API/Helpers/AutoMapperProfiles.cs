using AutoMapper;
using todo.API.Dtos;
using todo.Data.Models;

namespace todo.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          CreateMap<AddTodoDto, Todo>();
        }
    }
}
