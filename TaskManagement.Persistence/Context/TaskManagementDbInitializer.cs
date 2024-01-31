using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities.Language;
using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Persistence.Context
{
    public class TaskManagementDbInitializer
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

            modelBuilder.Entity<LanguageEntity>().HasData(
               new LanguageEntity { Id = 1, Prefix = "ka-GE", Name = "Georgia" },
               new LanguageEntity { Id = 2, Prefix = "en-US", Name = "English" });
        }
    }
     

    //public class TaskManagementDbInitializer
    //{
    //    public void Initialize(TaskManagementDbContext context)
    //    {
    //        context.Database.Migrate();
    //        SeedEverything(context);
    //    }

    //    public static void SeedEverything(TaskManagementDbContext dbContext)
    //    {
    //        dbContext.Database.EnsureCreated();

    //        SeedTaskLevels(dbContext);
    //        SeedTaskPriorities(dbContext);
    //        SeedTaskStatuses(dbContext);
    //        SeedLanguages(dbContext);
    //    }

    //    private static void SeedTaskLevels(TaskManagementDbContext dbContext)
    //    {
    //        if (!dbContext.TaskLevels.Any())
    //        {
    //            dbContext.TaskLevels.AddRange(new List<TaskLevelEntity>
    //        {
    //            new TaskLevelEntity { Id = 1, Name = "Easy" },
    //            new TaskLevelEntity { Id = 2, Name = "Medium" },
    //            new TaskLevelEntity { Id = 3, Name = "Difficult" }
    //        });

    //            dbContext.SaveChanges();
    //        }
    //    }

    //    private static void SeedTaskPriorities(TaskManagementDbContext dbContext)
    //    {
    //        if (!dbContext.TaskPriorities.Any())
    //        {
    //            dbContext.TaskPriorities.AddRange(new List<TaskPriorityEntity>
    //        {
    //            new TaskPriorityEntity { Id = 1, Name = "Low" },
    //            new TaskPriorityEntity { Id = 2, Name = "Medium" },
    //            new TaskPriorityEntity { Id = 3, Name = "High" },
    //            new TaskPriorityEntity { Id = 4, Name = "Urgent" }
    //        });

    //            dbContext.SaveChanges();
    //        }
    //    }

    //    private static void SeedTaskStatuses(TaskManagementDbContext dbContext)
    //    {
    //        if (!dbContext.TaskStatuses.Any())
    //        {
    //            dbContext.TaskStatuses.AddRange(new List<TaskStatusEntity>
    //        {
    //            new TaskStatusEntity { Id = 1, Name = "NotStarted" },
    //            new TaskStatusEntity { Id = 2, Name = "Started" },
    //            new TaskStatusEntity { Id = 3, Name = "InProgress" },
    //            new TaskStatusEntity { Id = 4, Name = "Failed" },
    //            new TaskStatusEntity { Id = 5, Name = "Completed" }
    //        });

    //            dbContext.SaveChanges();
    //        }
    //    }

    //    private static void SeedLanguages(TaskManagementDbContext dbContext)
    //    {
    //        if (!dbContext.Languages.Any())
    //        {
    //            dbContext.Languages.AddRange(new List<LanguageEntity>
    //        {
    //            new LanguageEntity { Id = 1, Prefix = "ka-GE", Name = "Georgia" },
    //            new LanguageEntity { Id = 2, Prefix = "en-US", Name = "English" }
    //        });

    //            dbContext.SaveChanges();
    //        }
    //    }
    //}
}
