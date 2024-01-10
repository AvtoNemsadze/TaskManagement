using TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        Task<TaskEntity?> GetTaskWithDetailsAsync(int id, CancellationToken cancellationToken);
        Task<IQueryable<TaskEntity>> GetTaskListWithDetailsAsync();
        Task<IEnumerable<TaskEntity>> GetTasksWithPastDeadlinesAsync(DateTime currentTime);
    }
}
