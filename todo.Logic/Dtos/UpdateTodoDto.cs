using System;
using System.ComponentModel.DataAnnotations;

namespace todo.Logic.DTOS
{ 
    public class UpdateTodoDTO
    {
        public Guid Id { get; set; }

        [MinLength(1)]
        public string Title { get; set; }

        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
