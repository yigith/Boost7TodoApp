using Microsoft.EntityFrameworkCore;

namespace TodoListApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem() { Id = 1, IsDone = true, Title = "Do your homework" },
                new TodoItem() { Id = 2, IsDone = false, Title = "Do fitness" },
                new TodoItem() { Id = 3, IsDone = false, Title = "Call your parents" },
                new TodoItem() { Id = 4, IsDone = true, Title = "Clean your room" }
                );
        }
    }
}
