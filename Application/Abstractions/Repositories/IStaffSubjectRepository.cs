using Domain.Entity;
namespace Application.Abstractions.Repositories
{
    public interface IStaffSubjectRepository : IBaseRepository<StaffsSubjects>
    {
        Task<List<StaffsSubjects>> GetStaffSubjectsAsync(Guid id);
    }
}
