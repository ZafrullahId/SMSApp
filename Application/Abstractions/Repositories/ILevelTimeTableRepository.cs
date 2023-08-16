using Domain.Entity;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface ILevelTimeTableRepository : IBaseRepository<LevelTimeTable>
    {
        Task<LevelTimeTable> GetAsync(Guid levelId, Term term, string seasion);
    }
}
