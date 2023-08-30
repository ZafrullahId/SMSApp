using Application.Dtos;
using Application.Dtos.ResponseModel;
using System;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IExamSubjectsServices
    {
        Task<Response<ExamSubjectsDto>> GetExamSubjectsByLevelIdAsync(Guid examId, Guid levelId);

    }
}