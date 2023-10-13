using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Common.Interfaces.Repositories;

namespace TaskManagement.Persistence.Repository
{
    public class GenericRepository : IGenericRepository
    {

        public TaskManagementDbContext _context { get; set; }

        public GenericRepository(TaskManagementDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class
        {
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual void HardDelete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void HardDeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.RemoveRange(entities);
        }

        public virtual async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> @where, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class
        {
            return await _context.Set<TEntity>().AnyAsync(where, cancellationToken);
        }

        public virtual async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> @where, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class
        {
            return await _context.Set<TEntity>().CountAsync(where, cancellationToken);
        }

        public virtual async Task<int> CountAsync<TEntity>(IQueryable<TEntity> data, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class
        {
            return await data.CountAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllAsync<TEntity>(CancellationToken cancellationToken = new CancellationToken()) where TEntity : class
        {
            return await _context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public virtual async Task<List<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> @where, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class
        {
            return await _context.Set<TEntity>().Where(where).ToListAsync(cancellationToken);
        }

        public virtual TEntity GetSingleByDynamicFunc<TEntity>(Func<TEntity, bool> @where) where TEntity : class
        {
            return _context.Set<TEntity>().FirstOrDefault(@where);
        }

        public virtual IEnumerable<TEntity> GetAllByDynamicFunc<TEntity>(Func<TEntity, bool> @where) where TEntity : class
        {
            return _context.Set<TEntity>().Where(@where);
        }

        public virtual async Task<List<TEntity>> ToListAsync<TEntity>(IQueryable<TEntity> data, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class
        {
            return await data.ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> @where, CancellationToken cancellationToken = new CancellationToken()) where TEntity : class
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(where, cancellationToken);
        }

        public virtual void Detach<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Detached;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
