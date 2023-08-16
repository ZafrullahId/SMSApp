using Application.Dtos.ResponseModel;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface ILevelTimeTableService
    {
        Task<LevelTimeTableResponseModel> GetLevelTimeTableAsync(Guid levelId, Term term, string seasion);
    }
}
