using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IStudentPaperRepository : IBaseRepository<StudentsPapers>
    {
       Task<List<StudentsPapers>> GetAllAsync(Guid paperId);
       Task<StudentsPapers> GetStudentPaperByStudentId(Guid studentId, Guid paperId);
        Task<List<StudentsPapers>> GetStudentPaperAsync(Guid paperId, int skipLength, int takeLength);
    }
}