using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entity.Identity;

namespace Application.Abstractions.Repositories
{
    public interface IUserRepository  : IBaseRepository<User>
    {
        Task<UserRole> LoginAsync(Expression<Func<UserRole, bool>> expression);
        Task<List<UserRole>> GetUserRolesAsync(Expression<Func<UserRole, bool>> expression);
    }
}