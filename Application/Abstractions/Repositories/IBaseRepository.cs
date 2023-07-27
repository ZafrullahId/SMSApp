using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task SaveChangesAsync();
        Task<bool> DeleteAsync(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Guid id);
        Task<T> UpdateAsync(T entity);
    }
}