using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
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
        Task<SubjectsTimeTableResponseModel> GetTimeTableSubjectsAsync(Guid timeTableId);
        Task<SubjectsTimeTableResponseModel> GeTimeTableByYearAndTerm(string seasion, Term term);
        //Task<BaseResponse> CreateTimeTableSubjectAsync(CreateSubjectTimeTableRequestModel model, Guid timeTableId);
    }
}
