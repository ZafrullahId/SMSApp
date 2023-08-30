using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;
using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.Services
{
    public interface IStudentService
    {
        Task<BaseResponse> UploadStudentListFileAsync(IFormFile file);
        Task<Response<StudentDto>> GetStudentByUserIdAsync(Guid userId);
        Task<BaseResponse> CreateAsync(CreateStudentRequestModel model, Guid staffUserId);
        Task<BaseResponse> UpdateStudentAsync(Guid userId, UpdateStudentRequestModel model);
        Task<Responses<StudentDto>> GetAllStudentsAsync(PaginationFilter filter, string route);
    }
}