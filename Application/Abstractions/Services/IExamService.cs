
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;

namespace Application.Abstractions.Services
{
    public interface IExamService
    {
        Task<BaseResponse> ChangeExamStateAsync(Guid id);
        Task<BaseResponse> CreateExamAsync(CreateExamRequestModel model);
        Task<Responses<ExamDto>> GetAllExamsAsync(PaginationFilter filter, string route);
        Task<Responses<ExamDto>> GetAllOngoingExamsAsync(PaginationFilter filter, string route);
    }
}