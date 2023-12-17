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

            DataSeeder.Seed(modelBuilder);
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskLevelEntity> TaskLevels { get; set; }
        public DbSet<TaskStatusEntity> TaskStatuses { get; set; }
        public DbSet<TaskPriorityEntity> TaskPriorities { get; set; }
    }
}