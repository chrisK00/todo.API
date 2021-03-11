using System.ComponentModel.DataAnnotations;

namespace todo.Logic.DTOS
{
    public class ReplaceTodoDTO
    {
        [MinLength(1)]
        public string Title { get; set; }

        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}