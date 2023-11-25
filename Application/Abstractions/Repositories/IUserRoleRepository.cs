using Domain.Entity.Identity;

namespace Application.Abstractions.Repositories
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        Task<UserRole> GetStudentAsync(Guid userId);
    }
}
