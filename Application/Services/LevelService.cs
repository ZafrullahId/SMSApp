using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;
namespace Application.Services
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IStaffLevelRepository _staffLevelRepository;
        private readonly IMapper _mapper;
        public LevelService(ILevelRepository levelRepository, IStaffLevelRepository staffLevelRepository, IStaffRepository staffRepository, IMapper mapper)
        {
            _levelRepository = levelRepository;
            _staffRepository = staffRepository;
            _staffLevelRepository = staffLevelRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> CreateLevel(CreateLevelRequestModel model)
        {
            var levelExist = await _levelRepository.ExistsAsync(x => x.Name.Equals(model.Name));
            if (levelExist) { return new BaseResponse { Message = "Level already exist", Success = false }; }
            var level = _mapper.Map<Level>(model);
            await _levelRepository.CreateAsync(level);
            await _levelRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Successfully Created", Success = true };
        }
        public async Task<LevelsResponseModel> GetLevelsAsync()
        {
            var levels = await _levelRepository.GetAllAsync();
            var orderedLevel = levels.OrderBy(x => x.Name).ToList();
            if (levels.IsNullOrEmpty()) { return new LevelsResponseModel { Message = "No level yet", Success = false }; }

            var data = _mapper.Map<List<LevelDto>>(orderedLevel);
            return new LevelsResponseModel { Message = "Levels found successfully", Success = true, Data = data };
        }
        public async Task<LevelResponseModel> GetLevelAsync(Guid id)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == id && x.IsDeleted == false);
            if (level is null) { return new LevelResponseModel { Message = "Level not found", Success = false }; }

            var data = _mapper.Map<LevelDto>(level);
            return new LevelResponseModel { Message = "Level found successfully", Success = true, Data = data };
        }
        public async Task<BaseResponse> DeleteLevelAsync(Guid id)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == id && x.IsDeleted == false);
            if (level is null) { return new LevelResponseModel { Message = "Level not found", Success = false }; }

            level.IsDeleted = true;
            await _levelRepository.UpdateAsync(level);
            return new BaseResponse { Message = "Level Deleted Successfully", Success = true };
        }
        public async Task<LevelsResponseModel> GetLevelsByStaffId(Guid staffId)
        {
            var staff = await _staffRepository.GetAsync(staffId);
            if (staff is null) { return new LevelsResponseModel { Message = "Staff not found", Success = false, }; }
            
            var staffLevels = await _staffLevelRepository.GetLevelsByStaffIdAsync(staffId);
            var data = _mapper.Map<List<LevelDto>>(staffLevels);
            return new LevelsResponseModel { Message = "Level Successfully Retrived", Success = true, Data = data };

        }
    }
}