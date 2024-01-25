using Microsoft.EntityFrameworkCore;
using System.Threading;
using TaskManagement.Application.Contracts.Persistence;
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
                 .Include(q => q.Comments)
                 .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);

             return task;
        }

        public async Task<IQueryable<TaskEntity>> GetTaskListWithDetailsAsync()
        {
            var tasks = _dbContext.Tasks
               .Include(q => q.TaskLevelEntity)
               .Include(q => q.TaskStatusEntity)
               .Include(q => q.TaskPriorityEntity)
               .Include(q => q.Comments)
               .AsNoTracking();

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