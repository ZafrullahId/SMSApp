using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IStudentPaperService
    {
        Task<BaseResponse> ReleasePaperResults(Guid paperId);
        Task<StudentsPapersResponseModel> GetStudentsPapersAsync(Guid paperId);
        Task<BaseResponse> CreateStudentPaperAsync(Guid studentId, Guid paperId);
        Task<StudentPaperResponseModel> GetStudentPaper(Guid studentId, Guid paperId);
    }
}