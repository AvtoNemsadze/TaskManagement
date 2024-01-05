using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Persistence.Context
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskLevelEntity>().HasData(
                new TaskLevelEntity { Id = 1, Name = "Easy" },
                new TaskLevelEntity { Id = 2, Name = "Medium" },
                new TaskLevelEntity { Id = 3, Name = "Difficult" });

            modelBuilder.Entity<TaskPriorityEntity>().HasData(
                new TaskPriorityEntity { Id = 1, Name = "Low" },
                new TaskPriorityEntity { Id = 2, Name = "Medium" },
                new TaskPriorityEntity { Id = 3, Name = "High" },
                new TaskPriorityEntity { Id = 4, Name = "Urgent" });

            modelBuilder.Entity<TaskStatusEntity>().HasData(
                new TaskStatusEntity { Id = 1, Name = "NotStarted" },
                new TaskStatusEntity { Id = 2, Name = "Started" },
                new TaskStatusEntity { Id = 3, Name = "InProgress" },
                new TaskStatusEntity { Id = 4, Name = "Failed" },
                new TaskStatusEntity { Id = 5, Name = "Completed" });
        }
    }
}
