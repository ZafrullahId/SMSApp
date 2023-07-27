

using Domain.Entity;

namespace Application.Abstractions.Repositories
{
    public interface IExamRepository : IBaseRepository<Exam>
    {
        Task<List<Exam>> GetAllOngoingExamsAsync();
    }
}