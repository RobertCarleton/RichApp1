using Microsoft.EntityFrameworkCore;

namespace W4L1P1
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
