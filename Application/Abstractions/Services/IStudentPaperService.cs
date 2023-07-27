using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IStudentPaperService
    {
        Task<BaseResponse> CreateStudentPaperAsync(Guid studentId, Guid paperId);
        Task<StudentPaperResponseModel> GetStudentPaper(Guid studentId, Guid paperId);
        Task<StudentsPapersResponseModel> GetStudentPapersBySubjectIdAsync(Guid subjectId, Guid levelId, Guid examId);
        Task<BaseResponse> ReleasePaperResults(Guid paperId);
    }
}