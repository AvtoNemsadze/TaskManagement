using System.Linq.Expressions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Common.Interfaces.Repositories
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        //Task<TaskEntity> GetSingle(Expression<Func<TaskEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
