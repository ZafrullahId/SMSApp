
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;

namespace Application.Abstractions.Services
{
    public interface IExamService
    {
        Task<BaseResponse> ChangeExamStateAsync(Guid id);
        Task<Results<ExamDto>> GetAllExamsAsync();
        Task<Results<ExamDto>> GetAllOngoingExamsAsync();
        Task<BaseResponse> CreateExamAsync(CreateExamRequestModel model);
    }
}