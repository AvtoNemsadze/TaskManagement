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
    }
}
