using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task<BaseResponse> Create(CreateRoleRequestModel model);
        Task<RoleResponseModel> GetRoleAsync(string Name);
        Task<RolesResponseModel> GetRolesAsync();
    }
}