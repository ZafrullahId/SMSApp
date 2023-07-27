using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IStudentPaperRepository : IBaseRepository<StudentsPapers>
    {
       Task<StudentsPapers> GetStudentPaperAsync(Guid examId,  Guid paperId);
       Task<StudentsPapers> GetStudentPaperByStudentId(Guid studentId, Guid paperId);
    }
}