using System.Linq.Expressions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Common.Interfaces.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetTasksWithPastDeadlinesAsync(DateTime currentTime);
    }
}
