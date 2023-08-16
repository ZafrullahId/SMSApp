using Application.Abstractions.Repositories;
using Domain.Entity;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class SubjectTimeTableRepository : BaseRepository<SubjectTimeTable>, ISubjectTimeTableRepository
    {
        public SubjectTimeTableRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<IEnumerable<SubjectTimeTable>> GetSubjectTimeTableAsync(Guid timeTableId)
        {
            return await _Context.SubjectTimeTables
                .Where(x => x.TimeTableId == timeTableId)
                .Include(x => x.Subject)
                .OrderBy(x => x.StartTime)
                .ToListAsync();
        }
        public async Task<IEnumerable<SubjectTimeTable>> GetSubjectTimeTableAsync(string seasion, Term term)
        {
            return await _Context.SubjectTimeTables
                .Where(x => x.TimeTable.Seasion == seasion && x.TimeTable.Term == term)
                .Include(x => x.Subject)
                .OrderBy(x => x.TimeTable)
                .ToListAsync();
        }
    }
}
