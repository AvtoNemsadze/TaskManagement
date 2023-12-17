using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Common.Interfaces.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetTasksWithPastDeadlinesAsync(DateTime currentTime);
    }
}
