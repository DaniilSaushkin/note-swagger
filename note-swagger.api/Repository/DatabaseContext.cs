using Microsoft.EntityFrameworkCore;
using note_swagger.api.DTO;

// Выключает все предупреждения с кодом CS1591
#pragma warning disable CS1591
namespace note_swagger.api.Repository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options) { Database.EnsureCreated(); }
    }
}
