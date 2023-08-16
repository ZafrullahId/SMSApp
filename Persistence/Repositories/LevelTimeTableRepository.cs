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
    public class LevelTimeTableRepository : BaseRepository<LevelTimeTable>, ILevelTimeTableRepository
    {
        public LevelTimeTableRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<LevelTimeTable> GetAsync(Guid levelId, Term term, string seasion)
        {
            return await _Context.LevelTimeTables
                .Where(x => x.LevelId == levelId && x.TimeTable.Term == term && x.TimeTable.Seasion == seasion)
                .Include(x => x.TimeTable)
                .SingleOrDefaultAsync();
        }
    }
}
