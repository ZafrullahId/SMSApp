using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IPaperService
    {
        Task<BaseResponse> EndPaperAsync(Guid paperId);
        Task<BaseResponse> StartPaperAsync(Guid paperId);
        Task<Response<PaperDto>> GetPaperByIdAsync(Guid id);
        Task<BaseResponse> TerminatePaperAsync(Guid paperId);
        Task<BaseResponse> UpdatePaperAync(Guid Id, UpdatePaperRequestModel model);
        Task<BaseResponse> Create(CreatePaperRequestModel model, Guid examId, Guid staffId, Guid timeTableId);
        Task<Results<PaperDto>> GetAllPapersByLevelIdAsync(Guid levelId, Guid examId);
    }
}