using Microsoft.EntityFrameworkCore;

namespace Rad301_2024_Week4_Lab1
{
    public class TodoDB : DbContext
    {
        public TodoDB(DbContextOptions<TodoDB> options) : base(options) { }
        public DbSet<Todo> Todos => Set<Todo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                .Property(t => t.TodoStatus)
                .HasConversion<string>(); // Convert the enum to string in the database
        }
    }
}
