
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using System;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface ILevelService
    {
        Task<BaseResponse> CreateLevel(CreateLevelRequestModel model);
        Task<BaseResponse> DeleteLevelAsync(Guid id);
        Task<LevelResponseModel> GetLevelAsync(Guid id);
        Task<LevelsResponseModel> GetLevelsAsync();
        Task<LevelsResponseModel> GetLevelsByStaffId(Guid staffId);
    }
}