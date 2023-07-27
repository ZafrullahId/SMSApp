using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IStaffRepository  : IBaseRepository<Staff>
    {
        Task<Staff> GetStaffByUserIdAsync(Guid userId);
    }
}