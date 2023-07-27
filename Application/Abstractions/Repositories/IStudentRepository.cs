using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IStudentRepository  : IBaseRepository<Student>
    {
        Task<Student> GetStudentAsync(Guid userId);
        Task<List<Student>> GetStudentsByLevelIdAsync(Guid levelId);
    }
}