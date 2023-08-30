using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;

namespace Application.Abstractions.Services
{
    public interface IStudentPaperService
    {
        Task<BaseResponse> ReleasePaperResults(Guid paperId);
        Task<BaseResponse> CreateStudentPaperAsync(Guid studentUserId, Guid paperId);
        Task<Response<StudentPapersDto>> GetStudentPaper(Guid studentId, Guid paperId);
        Task<Responses<StudentPapersDto>> GetStudentsPapersAsync(PaginationFilter filter, string route, Guid paperId);
    }
}