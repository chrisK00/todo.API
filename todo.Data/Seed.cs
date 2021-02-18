using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using todo.Data.Models;

namespace todo.Data
{
    public static class Seed
    {

        public static void SeedTodos(DataContext context)
        {                         
            context.Todos.Add(new Todo() { Title = "Hello", Description = "So much todo!" });
            context.SaveChanges();
        }
    }
}
