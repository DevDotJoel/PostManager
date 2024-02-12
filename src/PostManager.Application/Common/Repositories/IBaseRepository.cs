using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostManager.Application.Common.Repositories
{
    public interface IBaseRepository<TId,T> where T:class
    {
        Task<T> GetByIdAsync(TId id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(TId id);
        Task AddMultipleAsync(List<T> entities);
        Task UpdateMultipleAsync(List<T> entities);
        Task GetByIdsAsync(List<TId> ids);
    }
}
