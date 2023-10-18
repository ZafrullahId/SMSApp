using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;
using Application.Helpers;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
namespace Application.Services
{
    public class LevelService : ILevelService
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly ILevelRepository _levelRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IStaffLevelRepository _staffLevelRepository;
        public LevelService(ILevelRepository levelRepository, IStaffLevelRepository staffLevelRepository, IStaffRepository staffRepository, IMapper mapper, IUriService uriService)
        {
            _levelRepository = levelRepository;
            _staffRepository = staffRepository;
            _staffLevelRepository = staffLevelRepository;
            _mapper = mapper;
            _uriService = uriService;
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
        public async Task<Results<LevelDto>> GetLevelsAsync()
        {
            var levels = await _levelRepository.GetAllAsync();
            var orderedLevel = levels.OrderBy(x => x.Name).ToList();
            if (levels.IsNullOrEmpty()) { return new Results<LevelDto> { Message = "No level yet", Success = false }; }

            var data = _mapper.Map<List<LevelDto>>(orderedLevel);
            //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //var totalRecords = await _levelRepository.CountAsync();
            //var pagedReponse = PaginationHelper.CreatePagedReponse<LevelDto>(data, validFilter, totalRecords, _uriService, route);
            return new Results<LevelDto> { Message = "Levels found successfully", Success = true, Data = data };
        }
        public async Task<Response<LevelDto>> GetLevelAsync(Guid id)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == id && x.IsDeleted == false);
            if (level is null) { return new Response<LevelDto> { Message = "Level not found", Success = false }; }

            var data = _mapper.Map<LevelDto>(level);
            return new Response<LevelDto> { Message = "Level found successfully", Success = true, Data = data };
        }
        public async Task<BaseResponse> DeleteLevelAsync(Guid id)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == id && x.IsDeleted == false);
            if (level is null) { return new BaseResponse { Message = "Level not found", Success = false }; }

            level.IsDeleted = true;
            await _levelRepository.UpdateAsync(level);
            return new BaseResponse { Message = "Level Deleted Successfully", Success = true };
        }
        public async Task<Results<LevelDto>> GetLevelsByStaffId(Guid staffId)
        {
            var staff = await _staffRepository.GetAsync(staffId);
            if (staff is null) { return new Results<LevelDto> { Message = "Staff not found", Success = false, }; }
            
            var staffLevels = await _staffLevelRepository.GetLevelsByStaffIdAsync(staffId);
            var data = _mapper.Map<List<LevelDto>>(staffLevels);
            return new Results<LevelDto> { Message = "Level Successfully Retrived", Success = true, Data = data };

        }
    }
}