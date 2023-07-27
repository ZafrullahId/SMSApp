using Domain.Entity;
namespace Application.Abstractions.Repositories
{
    public interface IOptionRepository : IBaseRepository<Choice>
    {
        Task<List<Choice>> GetOptionsByQuestionId(Guid id);
        Task<Choice> GetOptionAsync(Guid id);
    }
}