using Microsoft.EntityFrameworkCore;
using ToDoEF.Models;
using Xamarin.Forms;

namespace ToDoEF.Services.EF
{
    class DatabaseContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDatabaseService>().GetDatabasePath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
