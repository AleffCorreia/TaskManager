using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public DbSet<TaskItem> TaskItems => Set<TaskItem>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TaskManager.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
