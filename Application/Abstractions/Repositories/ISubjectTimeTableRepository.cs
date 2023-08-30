using Domain.Entity;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface ISubjectTimeTableRepository : IBaseRepository<SubjectTimeTable>
    {
        Task<IEnumerable<SubjectTimeTable>> GetSubjectTimeTableAsync(Guid timeTableId, int skipLength, int takeLength);
        Task<IEnumerable<SubjectTimeTable>> GetSubjectTimeTableAsync(string seasion, Term term);
    }
}
