using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.Services
{
    public interface IStudentService
    {
        Task<StudentsResponseModel> GetAllStudentsAsync();
        Task<BaseResponse> UploadStudentListFileAsync(IFormFile file);
        Task<StudentResponseModel> GetStudentByUserIdAsync(Guid userId);
        Task<BaseResponse> CreateAsync(CreateStudentRequestModel model, Guid staffUserId);
        Task<BaseResponse> UpdateStudentAsync(Guid userId, UpdateStudentRequestModel model);
    }
}