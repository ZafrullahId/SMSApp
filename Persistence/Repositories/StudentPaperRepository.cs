using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class StudenPaperRepository : BaseRepository<StudentsPapers>, IStudentPaperRepository
    {
        public StudenPaperRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<List<StudentsPapers>> GetStudentPaperAsync(Guid paperId, int skipLength, int takeLength)
        {
            return await _Context.StudentsPapers
            .Include(x => x.Student)
            .ThenInclude(x => x.User)
            .Where(x => x.Paper.Id == paperId)
            .Skip((skipLength - 1) * takeLength)
            .Take(takeLength)
            .ToListAsync(); 
        }
        public async Task<StudentsPapers> GetStudentPaperByStudentId(Guid studentId, Guid paperId)
        {
            return await _Context.StudentsPapers
                .Include(x => x.Student)
                .Include(x => x.Paper)
                .Where(x => x.StudentId == studentId && x.PaperId == paperId && x.Paper.PaperStatus == PaperStatus.Ended)
                .SingleOrDefaultAsync();
        }
        public async Task<List<StudentsPapers>> GetAllAsync(Guid paperId)
        {
            return await _Context.StudentsPapers
                .Where(x => x.PaperId == paperId)
                .Include(x => x.Student)
                .ThenInclude(x => x.User)
                .ToListAsync();
        }
    }
}