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
    public class OptionRepository : BaseRepository<Choice>, IOptionRepository
    {
       public OptionRepository(SMSAppContext context)
       {
            _Context = context;
       } 
       public async Task<List<Choice>> GetOptionsByQuestionId(Guid id)
       {
            return await _Context.Options
            .Include(x => x.Question)
            .Where(x => x.QuestionId == id && x.IsDeleted == false)
            .ToListAsync();
       }
       public async Task<Choice> GetOptionAsync(Guid id)
       {
          return await _Context.Options
          .Include(x => x.Question)
          .ThenInclude(x => x.Paper)
          .SingleOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
       }
    }
}