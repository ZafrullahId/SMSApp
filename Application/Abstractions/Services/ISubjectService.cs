using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
namespace Application.Abstractions.Services
{
    public interface ISubjectService
    {
        Task<BaseResponse> CreateAsync(CreateSubjectRequestModel model);
        Task<SubjectResponseModel> GetSubjectByIdAsync(Guid id);
        Task<SubjectsResponseModel> GetSubjects();
        Task<SubjectsResponseModel> GetSubjectsByStaffIdAsync(Guid staffId);
    }
}
