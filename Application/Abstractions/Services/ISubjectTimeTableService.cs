using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface ISubjectTimeTableService
    {
        Task<Results<SubjectTimeTableDto>> GetTimeTableSubjectsAsync(Guid timeTableId);
        Task<Results<IEnumerable<SubjectTimeTableDto>>> GetTimeTableBySessionAndTerm(string seasion, Term term);
    }
}
