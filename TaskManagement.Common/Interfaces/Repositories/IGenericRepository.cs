using System.Linq.Expressions;

namespace TaskManagement.Common.Interfaces.Repositories
{
    public interface IGenericRepository
    {
        Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> CountAsync<TEntity>(IQueryable<TEntity> data, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class;
        void Detach<TEntity>(TEntity entity) where TEntity : class;
        void Dispose();
        Task<List<TEntity>> GetAllAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : class;
        Task<List<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class;
        TEntity GetSingleByDynamicFunc<TEntity>(Func<TEntity, bool> @where) where TEntity : class;
        IEnumerable<TEntity> GetAllByDynamicFunc<TEntity>(Func<TEntity, bool> @where) where TEntity : class;
        Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> data, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class;
        Task<TEntity> GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
    }
}
