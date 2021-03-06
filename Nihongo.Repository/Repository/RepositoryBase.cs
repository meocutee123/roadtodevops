using Microsoft.EntityFrameworkCore;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Repository.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly NihongoContext _dbContext;

        public RepositoryBase(NihongoContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity is null)
            {
                throw new KeyNotFoundException($"[Repository base - Delete] Entity not found!");
            }
            await Task.FromResult(_dbContext.Remove(entity));
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            await Task.FromResult(_dbContext.Set<T>().Update(entity));
        }

    }
}
