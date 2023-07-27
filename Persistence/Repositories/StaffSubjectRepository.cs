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
    public class StaffSubjectRepository : BaseRepository<StaffsSubjects>, IStaffSubjectRepository
    {
        public StaffSubjectRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<List<StaffsSubjects>> GetStaffSubjectsAsync(Guid id)
        {
            return await _Context.StaffsSubjects
                .Include(x => x.Subject)
                .Where(x => x.StaffId == id)
                .ToListAsync();
        }
    }
}
