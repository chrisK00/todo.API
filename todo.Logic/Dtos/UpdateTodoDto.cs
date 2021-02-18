using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace todo.Logic.DTOS
{
    public class UpdateTodoDTO
    {
        public Guid Id { get; set; }

        [MinLength(1)]
        public string? Title { get; set; }

        //is already nullable by default but vs doesnt allow me to not have it as nullable
        public string? Description { get; set; }
        public bool? Completed { get; set; }
    }
}
