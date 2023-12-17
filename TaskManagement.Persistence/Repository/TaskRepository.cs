﻿using Microsoft.EntityFrameworkCore;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Domain.Entities.Task;
using TaskStatus = TaskManagement.Common.Enums.TaskStatusEnum;

namespace TaskManagement.Persistence.Repository
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TaskRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksWithPastDeadlinesAsync(DateTime currentTime)
        {
            return await _dbContext.Tasks
                .Where(task => task.TaskStatusId != (int)TaskStatus.Failed && task.TaskStatusId != (int)TaskStatus.Completed && task.DueDate < currentTime)
                .ToListAsync();
        }
    }
}
