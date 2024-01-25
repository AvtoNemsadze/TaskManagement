using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TaskManagementDbContext _dbContext;

        public GenericRepository(TaskManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async ValueTask Delete(T entity)
        {
           _dbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id) ?? default!;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
        }

        public async ValueTask Update(T entity)
        {
             _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<T?> GetSingleAsync(Expression<Func<T, bool>> @where, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(where, cancellationToken);
        }

        //public async Task<T> GetSingleWithIncludesAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        //{
        //    var query = _dbContext.Set<T>().AsQueryable();

        //    if (includes != null)
        //    {
        //        query = includes.Aggregate(query, (current, include) => current.Include(include));
        //    }

        //    return await query.FirstOrDefaultAsync(where, cancellationToken) ?? default!;
        //}

        public IQueryable<T> GetAllQueryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }
    }
}
