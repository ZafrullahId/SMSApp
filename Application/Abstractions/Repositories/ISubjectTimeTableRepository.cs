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
        Task<IEnumerable<SubjectTimeTable>> GetSubjectTimeTableAsync(Guid timeTableId);
        Task<IEnumerable<SubjectTimeTable>> GetSubjectTimeTableAsync(int year, Term term);
    }
}
