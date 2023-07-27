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
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        public StaffRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<Staff> GetStaffByUserIdAsync(Guid userId)
        {
            return await _Context.Staffs
                .Where(x => x.UserId == userId)
                .Include(x => x.User).FirstOrDefaultAsync();
        }
    }
}