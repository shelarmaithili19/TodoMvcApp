using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoMvcApp.Models;

namespace TodoMvcApp.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
