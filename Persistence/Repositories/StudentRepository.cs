using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Domain.Entity;
using Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(SMSAppContext context)
        {
            _Context = context;
        }
        public async Task<Student> GetStudentAsync(Guid userId) => await _Context.Students
                .Where(x => x.UserId == userId)
                .Include(x => x.User)
            .Include(x => x.Level)
            .Include(x => x.Department)
            .SingleOrDefaultAsync();
        
        public async Task<List<Student>> GetStudentsByLevelIdAsync(Guid levelId) => await _Context.Students
            .Where(z => z.LevelId == levelId)
            .Include(x => x.User).ToListAsync();
    }
}