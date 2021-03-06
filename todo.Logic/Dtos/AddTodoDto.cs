﻿using System.ComponentModel.DataAnnotations;

namespace todo.Logic.DTOS
{
    /// <summary>
    /// Data Transfer Object
    /// Whenever a new todo is added we dont want the user to specify the id but rather the Db do it
    /// </summary>
    public class AddTodoDTO
    {
        [Required, MinLength(1)]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}