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
    public class ExamSubjectsRepository : BaseRepository<ExamSubjects>, IExamSubjectsRepository
    {
        public ExamSubjectsRepository(SMSAppContext context)
        {
            _Context = context;
        }
    }
}