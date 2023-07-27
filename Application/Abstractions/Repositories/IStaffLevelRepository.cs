using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IStaffLevelRepository : IBaseRepository<StaffsLevels>
    {
        Task<List<StaffsLevels>> GetLevelsByStaffIdAsync(Guid staffId);
    }
}
