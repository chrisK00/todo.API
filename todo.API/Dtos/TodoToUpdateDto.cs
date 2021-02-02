using System;
using System.ComponentModel.DataAnnotations;

namespace todo.API.Dtos
{
    /// <summary>
    /// Data Transfer Object for http Post
    /// Whenever a new todo is added we dont want the user to specify the id but rather the Db do it
    /// </summary>
    public class TodoToUpdateDto
    {
        public Guid Id { get; set; }

        [MinLength(1)]
        public string Title { get; set; }

        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}