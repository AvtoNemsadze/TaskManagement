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


            modelBuilder.Entity<TaskStatusEntity>().HasData(
                new TaskStatusEntity { Id = 1, Name = "NotStarted" },
                new TaskStatusEntity { Id = 2, Name = "Started" },
                new TaskStatusEntity { Id = 3, Name = "InProgress" },
                new TaskStatusEntity { Id = 4, Name = "Failed" },
                new TaskStatusEntity { Id = 5, Name = "Completed" });

            modelBuilder.Entity<TaskEntity>().ToTable("Tasks");
            modelBuilder.Entity<TaskLevelEntity>().ToTable("TaskLevels");
            modelBuilder.Entity<TaskStatusEntity>().ToTable("TaskStatuses");
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TaskLevelEntity> TaskLevels { get; set; }
        public DbSet<TaskStatusEntity> TaskStatuses { get; set; }
    }
}