using Application.Abstractions.Repositories;
using Domain.Entity;
using Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<UserRole> GetStudentAsync(Guid userId) => await _Context.UserRoles
                .Where(x => x.UserId == userId)
                .Include(x => x.User)
                .Include(x => x.User.Student)
                .Include(x => x.User.Student.Department)
                .Include(x => x.User.Student.Level)
                .Include(x => x.Role)
            .SingleOrDefaultAsync();
    }
}
