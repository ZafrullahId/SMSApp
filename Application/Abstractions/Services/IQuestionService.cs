using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.Services
{
    public interface IQuestionService
    {
        Task<BaseResponse> DeletAsync(Guid id);
        Task<QuestionOptionsResponseModel> GetQuestionByIdAsync(Guid id);
        Task<QuestionsOptionsResponseModel> GetAllQuestionsByPaperIdAsync(Guid paperId);
        Task<BaseResponse> UpdateAsync(Guid questionId, UpdateQuestionRequestModel model);
        Task<BaseResponse> CreateQuestionAsync(CreateQuestionRequestModel model, IFormFile? QuestionIMage, Guid paperId);
    }
}