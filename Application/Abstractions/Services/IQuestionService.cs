using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IQuestionService
    {
        Task<BaseResponse> DeletAsync(Guid id);
        Task<QuestionOptionsResponseModel> GetQuestionByIdAsync(Guid id);
        Task<QuestionsOptionsResponseModel> GetAllQuestionsByPaperIdAsync(Guid paperId);
        Task<BaseResponse> UpdateAsync(Guid questionId, UpdateQuestionRequestModel model);
        Task<BaseResponse> CreateQuestionAsync(CreateQuestionRequestModel model, Guid paperId);
    }
}