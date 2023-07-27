using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;

namespace Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel model);
    }
}