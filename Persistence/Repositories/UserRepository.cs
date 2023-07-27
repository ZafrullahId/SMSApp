using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Domain.Entity;
using Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
namespace Persistence.Repositories
{ 
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<UserRole> LoginAsync(Expression<Func<UserRole, bool>> expression)
        {
            return await _Context.UserRoles
                .Include(x => x.User)
                .Include(x => x.Role)
                .SingleOrDefaultAsync(expression);
        }
        public async Task<List<UserRole>> GetUserRolesAsync(Expression<Func<UserRole, bool>> expression)
        {
            return await _Context.UserRoles
                .Include(x => x.Role)
                .Where(expression)
                .ToListAsync();
        }
    }
}