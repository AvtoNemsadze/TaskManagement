using System.Linq.Expressions;


namespace TaskManagement.Application.Interfaces.Repositories
{
    public interface ITaskManagementDbRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        bool Any<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class;
        int Count<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class;
        Task<int> CountAsync<TEntity>(IQueryable<TEntity> data, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class;
        void Detach<TEntity>(TEntity entity) where TEntity : class;
        void Dispose();
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        Task<List<TEntity>> GetAllAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : class;
        Task<List<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class;
        TEntity GetSingleByDynamicFunc<TEntity>(Func<TEntity, bool> @where) where TEntity : class;
        IEnumerable<TEntity> GetAllByDynamicFunc<TEntity>(Func<TEntity, bool> @where) where TEntity : class;
        Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> data, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class;
        TEntity GetSingle<TEntity>(Expression<Func<TEntity, bool>> where) where TEntity : class;
        Task<TEntity> GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default) where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
