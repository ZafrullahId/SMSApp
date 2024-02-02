using Domain.Entity;
using System.Linq.Expressions;

namespace Application.Abstractions.Repositories
{
    public interface IStudentRepository  : IBaseRepository<Student>
    {
        Task<Student> GetStudentAsync(Guid userId);
        Task<List<Student>> GetStudentsByLevelIdAsync(Guid levelId);
        Task<Student> LoginStudentAsync(Expression<Func<Student, bool>> expression);
    }
}