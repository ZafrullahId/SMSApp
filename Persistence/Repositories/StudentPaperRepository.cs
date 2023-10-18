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
    public class StudenPaperRepository : BaseRepository<StudentPaper>, IStudentPaperRepository
    {
        public StudenPaperRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<List<StudentPaper>> GetStudentPaperAsync(Guid paperId)
        {
            return await _Context.StudentPaper
            .Include(x => x.Student)
            .ThenInclude(x => x.User)
            .ToListAsync(); 
        }
        public async Task<StudentPaper> GetStudentPaperByStudentId(Guid studentId, Guid paperId)
        {
            return await _Context.StudentPaper
                .Include(x => x.Student)
                .Include(x => x.Paper)
                .Where(x => x.StudentId == studentId && x.PaperId == paperId && x.Paper.PaperStatus == PaperStatus.Ended)
                .SingleOrDefaultAsync();
        }
        public async Task<List<StudentPaper>> GetAllAsync(Guid paperId)
        {
            return await _Context.StudentPaper
                .Where(x => x.PaperId == paperId)
                .Include(x => x.Student)
                .ThenInclude(x => x.User)
                .ToListAsync();
        }
    }
}