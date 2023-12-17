using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Persistence
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementDbContext).Assembly);

            modelBuilder.Entity<TaskLevelEntity>().HasData(
              new TaskLevelEntity { Id = 1, Name = "Easy" },
              new TaskLevelEntity { Id = 2, Name = "Medium" },
              new TaskLevelEntity { Id = 3, Name = "Difficult" });
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskLevelEntity> TaskLevels { get; set; }

    }
}
