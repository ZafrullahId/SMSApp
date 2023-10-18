using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<Response<LoginDto>> LoginAsync(LoginRequestModel model);
        Task<Response<LoginDto>> LoginAsync(StudentLoginRequestModel model);
    }
}