using System.ComponentModel.DataAnnotations;

namespace todo.API.Dtos
{
    /// <summary>
    /// Data Transfer Object for http Post
    /// Whenever a new todo is added we dont want the user to specify the id but rather the Db do it
    /// </summary>
    public class TodoToUpdateDto : TodoDtoBase
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
    }
}