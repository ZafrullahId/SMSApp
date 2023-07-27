using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IOptionService
    {
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<OptionsResponseModel> GetOptionByQuestionIdAsync(Guid id);
        Task<BaseResponse> UpdateAsync(Guid id, UpdateOptionRequestModel model);
        Task<BaseResponse> SubmitPaperAsync(List<Guid> optionIds, Guid studentId);
        Task<BaseResponse> CheckOptionAsync(Guid optionId, Guid questionId, Guid studentId);
        Task<BaseResponse> CreateOptionsAsync(List<CreateOptionRequestModel> optionRequestModels, Guid questionId);
    }
}