using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IQuestionRepository  : IBaseRepository<Question>
    {
        Task<Question> GetQuestionAsync(Guid id);
        Task<List<Question>> GetQuestionByPaperIdAsync(Guid paperId);
    }
}