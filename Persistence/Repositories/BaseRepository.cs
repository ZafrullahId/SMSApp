using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Application.Dtos.ResponseModel;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected SMSAppContext _Context;
        public async Task<T> CreateAsync(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task SaveChangesAsync()
        {
            await _Context.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _Context.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetFilterAsync(int skipLength, int takeLength)
        {
            return await _Context.Set<T>()
               .Skip((skipLength - 1) * takeLength)
                .Take(takeLength)
               .ToListAsync();
        }
        public async Task<List<T>> GetFilterAsync(int skipLength, int takeLength, Expression<Func<T, bool>> expression)
        {
            return await _Context.Set<T>()
               .Skip((skipLength - 1) * takeLength)
               .Take(takeLength)
               .Where(expression)
               .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await _Context.Set<T>().CountAsync();
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _Context.Set<T>().CountAsync(expression);
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _Context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _Context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteAsync(T entity)
        {
            _Context.Set<T>().Remove(entity);
            await _Context.SaveChangesAsync();
            return true;
        }
        public async Task<T> GetAsync(Guid id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _Context.Set<T>().SingleOrDefaultAsync(expression);
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return await _Context.Set<T>().AnyAsync(expression);
        }
    }
}