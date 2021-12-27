using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAllAsync();
        Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
