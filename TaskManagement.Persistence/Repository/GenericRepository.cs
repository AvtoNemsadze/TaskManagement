﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Common.Interfaces.Repositories;

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

        public async Task Delete(T entity)
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
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        //public async Task<IReadOnlyList<T>> GetAll(Expression<Func<T, bool>> predicate)
        //{
        //    return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        //}

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> @where, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(where, cancellationToken);
        }
    }
}
