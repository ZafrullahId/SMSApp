using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IStaffService
    {
        Task<BaseResponse> Create(CreateStaffRequestModel model);
        Task<BaseResponse> DeleteAsync(Guid id);
        Task<Response<StaffLevelSubjectDto>> GetAsync(Guid id);
        Task<BaseResponse> UpdateAsync(Guid id, UpdateStaffRequestModel model);
    }
}