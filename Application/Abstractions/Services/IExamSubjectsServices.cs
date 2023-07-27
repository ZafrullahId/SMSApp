using Application.Dtos.ResponseModel;
using System;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IExamSubjectsServices
    {
        Task<ExamSubjectsResponseModel> GetExamSubjectsByLevelIdAsync(Guid examId, Guid levelId);

    }
}