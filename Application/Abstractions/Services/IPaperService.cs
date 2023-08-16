using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IPaperService
    {
        Task<BaseResponse> EndPaperAsync(Guid paperId);
        Task<BaseResponse> StartPaperAsync(Guid paperId);
        Task<PaperResponseModel> GetPaperByIdAsync(Guid id);
        Task<BaseResponse> TerminatePaperAsync(Guid paperId);
        Task<BaseResponse> UpdatePaperAync(Guid Id, UpdatePaperRequestModel model);
        Task<PapersResponseModel> GetAllPapersByLevelIdAsync(Guid LevelId, Guid ExamId);
        Task<BaseResponse> Create(CreatePaperRequestModel model, Guid examId, Guid staffId, Guid timeTableId);
    }
}