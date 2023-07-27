using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IStudentService
    {
        Task<BaseResponse> CreateAsync(CreateStudentRequestModel model);
        Task<StudentsResponseModel> GetAllStudentsAsync();
        Task<StudentResponseModel> GetStudentByUserIdAsync(Guid userId);
        Task<BaseResponse> UpdateStudentAsync(Guid userId, UpdateStudentRequestModel model);
    }
}