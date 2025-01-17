using Microsoft.EntityFrameworkCore;

namespace TodoApi_MinimalApi
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }
    }
}
