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
    public class ExamRepository : BaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<List<Exam>> GetAllOngoingExamsAsync()
        {
            return await _Context.Exams
            .Where(x => x.IsEnded == false)
            .ToListAsync();
        }
    }
}