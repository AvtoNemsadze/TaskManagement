using System.Linq.Expressions;

namespace TaskManagement.Common.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Exists(int id);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAllQueryable();
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        //Task<T> GetSingleWithIncludesAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}
