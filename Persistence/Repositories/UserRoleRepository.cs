using Application.Abstractions.Repositories;
using Domain.Entity;
using Domain.Entity.Identity;
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
    }
}
