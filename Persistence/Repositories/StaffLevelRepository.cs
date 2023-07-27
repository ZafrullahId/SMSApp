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
    public class StaffLevelRepository : BaseRepository<StaffsLevels>, IStaffLevelRepository
    {
        public StaffLevelRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<List<StaffsLevels>> GetLevelsByStaffIdAsync(Guid staffId)
        {
            return await _Context.StaffsLevels
                .Include(x => x.Level)
                .Where(x => x.StaffId == staffId)
                .ToListAsync();
        }
    }
}
