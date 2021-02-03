using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo.API.Dtos;
using todo.Data.Models;

namespace todo.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          CreateMap<TodoToAddDto, Todo>();
        }
    }
}
