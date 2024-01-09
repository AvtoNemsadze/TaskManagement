﻿using Azure.Core;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Common.Exceptions;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Domain.Entities.Task;
using TaskManagement.Persistence.Context;
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

        public async Task<TaskEntity?> GetTaskWithDetailsAsync(int id, CancellationToken cancellationToken)
        {
            var task = await _dbContext.Tasks
                 .Include(q => q.TaskLevelEntity)
                 .Include(q => q.TaskStatusEntity)
                 .Include(q => q.TaskPriorityEntity)
                 .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);

             return task;
        }

        public async Task<IQueryable<TaskEntity>> GetTaskListWithDetailsAsync()
        {
            var tasks = _dbContext.Tasks
               .Include(q => q.TaskLevelEntity)
               .Include(q => q.TaskStatusEntity)
               .Include(q => q.TaskPriorityEntity);

            return tasks;
        }

        public async Task<IEnumerable<TaskEntity>> GetTasksWithPastDeadlinesAsync(DateTime currentTime)
        {
            return await _dbContext.Tasks
                .Where(task => task.TaskStatusId != (int)TaskStatus.Failed && task.TaskStatusId != (int)TaskStatus.Completed && task.DueDate < currentTime)
                .ToListAsync();
        }
    }
}


//public async Task<IQueryable<TaskEntity>> GetTaskListWithDetailsAsync()
//{
//    var tasks = await _dbContext.Tasks
//        .Include(q => q.TaskLevelEntity)
//        .Include(q => q.TaskStatusEntity)
//        .Include(q => q.TaskPriorityEntity).ToListAsync();

//    return tasks.AsQueryable();
//}
