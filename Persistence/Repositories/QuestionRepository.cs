using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<List<Question>> GetQuestionByPaperIdAsync(Guid paperId)
        {
            return await _Context.Questions
                .Where(x => x.PaperId == paperId && x.IsDeleted == false)
                .ToListAsync();
        }
        public async Task<Question> GetQuestionAsync(Guid id)
        {
            return await _Context.Questions
                .Where(x => x.Id == id && x.IsDeleted == false)
                .Include(x => x.Paper)
                .SingleOrDefaultAsync();
        }
    }
}