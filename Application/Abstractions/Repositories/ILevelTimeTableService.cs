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
        Task<Responses<SubjectTimeTableDto>> GetLevelTimeTableAsync(PaginationFilter filter, string route, Guid levelId, Term term, string seasion);
    }
}
