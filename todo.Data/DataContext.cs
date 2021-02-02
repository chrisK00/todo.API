using Microsoft.EntityFrameworkCore;
using todo.Data.Models;

namespace todo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //This is a table in our db
        public DbSet<Todo> Todos { get; set; }
    }
}