using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task<Results<RoleDto>> GetRolesAsync();
        Task<Response<RoleDto>> GetRoleAsync(string Name);
        Task<BaseResponse> Create(CreateRoleRequestModel model);
    }
}