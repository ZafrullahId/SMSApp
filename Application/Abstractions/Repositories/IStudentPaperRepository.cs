using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IStudentPaperRepository : IBaseRepository<StudentPaper>
    {
        Task<List<StudentPaper>> GetAllAsync(Guid paperId);
        Task<StudentPaper> GetStudentPaperByStudentId(Guid studentId, Guid paperId);
        Task<List<StudentPaper>> GetStudentPaperAsync(Guid paperId);
    }
}