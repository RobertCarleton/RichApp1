using Microsoft.EntityFrameworkCore;

namespace Rad301_2024_Week2_Lab1
{
    public class TodoDB : DbContext
    {
        public TodoDB(DbContextOptions<TodoDB> options) : base(options) { }
        public DbSet<Todo> Todos => Set<Todo>();
    }
}
