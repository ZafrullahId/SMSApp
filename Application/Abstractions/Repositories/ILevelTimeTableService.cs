using Application.Dtos;
using Application.Dtos.ResponseModel;
using Application.Filter;
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
        Task<Response<LevelTimeTableDto>> GetLevelTimeTableAsync(Guid levelId, Term term, string seasion);
    }
}
