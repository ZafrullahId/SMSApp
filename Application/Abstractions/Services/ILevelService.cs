
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;
using System;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface ILevelService
    {
        Task<BaseResponse> DeleteLevelAsync(Guid id);
        Task<Response<LevelDto>> GetLevelAsync(Guid id);
        Task<Results<LevelDto>> GetLevelsByStaffId(Guid staffId);
        Task<BaseResponse> CreateLevel(CreateLevelRequestModel model);
        Task<Responses<LevelDto>> GetLevelsAsync(PaginationFilter filter, string route);
    }
}