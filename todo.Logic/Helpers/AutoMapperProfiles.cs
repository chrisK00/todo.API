using AutoMapper;
using todo.Data.Models;
using todo.Logic.Dtos;

namespace todo.Logic.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          CreateMap<AddTodoDto, Todo>();
        }
    }
}
