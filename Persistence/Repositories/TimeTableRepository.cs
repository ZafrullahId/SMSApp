using Application.Abstractions.Repositories;
using Domain.Entity;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TimeTableRepository : BaseRepository<TimeTable>, ITimeTableRepository
    {
        public TimeTableRepository(SMSAppContext context)
        {
            _Context = context;
        }

    }
}
