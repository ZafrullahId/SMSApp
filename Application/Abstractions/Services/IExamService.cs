
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IExamService
    {
        Task<BaseResponse> ChangeExamStateAsync(Guid id);
        Task<BaseResponse> CreateExamAsync(CreateExamRequestModel model);
        Task<ExamsResponseModel> GetAllExamsAsync();
        Task<ExamsResponseModel> GetAllOngoingExamsAsync();
    }
}