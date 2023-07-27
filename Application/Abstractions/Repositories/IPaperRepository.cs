using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IPaperRepository : IBaseRepository<Paper>
    {
        Task<Paper> GetByIdAsync(Guid id);
        Task<List<Paper>> GetAllPapersByLevelIdAsync(Guid levelId, Guid examId);
        Task<List<Paper>> GetExamPapersBySubjectIdAsync(Guid examId, Guid subjectId, Guid level);
    }
}