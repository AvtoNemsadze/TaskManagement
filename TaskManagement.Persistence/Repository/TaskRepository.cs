using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Common.Interfaces.Repositories;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Persistence.Repository
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        private readonly TaskManagementDbContext _dbContext;

        public TaskRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<TaskEntity> GetTaskWithDetails(Expression<Func<TaskEntity, bool>> predicate, CancellationToken cancellationToken)
        //{
        //    return await _dbContext.Tasks
        //        .Where(predicate)
        //        .FirstOrDefaultAsync(cancellationToken);
        //}
    }
}
