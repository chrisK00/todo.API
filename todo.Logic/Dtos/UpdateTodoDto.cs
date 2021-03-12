using System.ComponentModel.DataAnnotations;

#nullable enable

namespace todo.Logic.DTOS
{
    public class UpdateTodoDTO
    {
        [MinLength(1)]
        public string? Title { get; set; }

        //is already nullable by default but vs doesnt allow me to not have it as nullable
        public string? Description { get; set; }

        public bool? Completed { get; set; }
    }
}