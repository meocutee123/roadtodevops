using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nihongo.Application.Interfaces.Reposiroty
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        Task<IList<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
    }
}
