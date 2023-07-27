
using Application.Abstractions.Repositories;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PaperRepository : BaseRepository<Paper>, IPaperRepository
    {
        public PaperRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<List<Paper>> GetAllPapersByLevelIdAsync(Guid levelId, Guid examId)
        {
            return await _Context.Papers
            .Include(x => x.Subject)
            .Where(x => x.LevelId == levelId && x.ExamId == examId)
            .ToListAsync();
        }
        public async Task<List<Paper>> GetExamPapersBySubjectIdAsync(Guid examId, Guid subjectId, Guid level)
        {
                return await _Context.Papers
                .Where(x => x.ExamId == examId && x.SubjectId == subjectId && x.LevelId == level)
                .ToListAsync();
        }
        public async Task<Paper> GetByIdAsync(Guid id)
        {
            return await _Context.Papers
                .Include(x => x.Subject)
                .SingleOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }
    }
}