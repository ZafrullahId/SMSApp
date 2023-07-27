using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
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
        public async Task<StudentsPapers> GetStudentPaperAsync(Guid examId,  Guid paperId)
        {
            return await _Context.StudentsPapers
            .Include(x => x.Student)
            .ThenInclude(x => x.User)
            .Where(x => x.Paper.ExamId == examId && x.PaperId ==  paperId && x.Paper.PaperStatus == PaperStatus.Ended)
            .SingleOrDefaultAsync(); 
        }
        public async Task<StudentsPapers> GetStudentPaperByStudentId(Guid studentId, Guid paperId)
        {
            return await _Context.StudentsPapers
                .Include(x => x.Student)
                .Include(x => x.Paper)
                .Where(x => x.StudentId == studentId && x.PaperId == paperId && x.Paper.PaperStatus == PaperStatus.Ended).SingleOrDefaultAsync();
        }

    }
}