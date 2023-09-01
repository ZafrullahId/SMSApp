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
        //Task<SubjectsTimeTableResponseModel> GeTimeTableByYearAndTerm(string seasion, Term term);
        Task<Results<IEnumerable<SubjectTimeTableDto>>> GetTimeTableByYearAndTerm(string seasion, Term term);
        Task<Responses<SubjectTimeTableDto>> GetTimeTableSubjectsAsync(PaginationFilter filter, string route, Guid timeTableId);
        //Task<BaseResponse> CreateTimeTableSubjectAsync(CreateSubjectTimeTableRequestModel model, Guid timeTableId);
    }
}
