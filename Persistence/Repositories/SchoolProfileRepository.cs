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
    public class SchoolProfileRepository : BaseRepository<SchoolProfile>, ISchoolProfileRepository
    {
        public SchoolProfileRepository(SMSAppContext context)
        {
            _Context = context;
        }
    }
}
