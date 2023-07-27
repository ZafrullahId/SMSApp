using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Domain.Entity.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Create(CreateRoleRequestModel model)
        {
            var roleExist = await _roleRepository.ExistsAsync(x => x.Name.Equals(model.Name));
            if (roleExist) { return new BaseResponse { Message = "Role Already Exist", Success = false, }; }

            var role = _mapper.Map<Role>(model);
            await _roleRepository.CreateAsync(role);
            await _roleRepository.SaveChangesAsync();
            return new BaseResponse { Success = true, Message = "Role Successfully Created" };
        }
        public async Task<RoleResponseModel> GetRoleAsync(string Name)
        {
            var role = await _roleRepository.GetAsync(x => x.Name == Name);
            if (role == null) { return new RoleResponseModel { Message = "Role not found", Success = false, }; }

            var roleDtoData = _mapper.Map<RoleDto>(role);
            return new RoleResponseModel { Message = "Role found", Success = true, Data = roleDtoData };
        }
        public async Task<RolesResponseModel> GetRolesAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            if (roles.IsNullOrEmpty()) { return new RolesResponseModel { Message = "No role found", Success = false, }; }

            var roleDtoDatas = _mapper.Map<List<RoleDto>>(roles);
            return new RolesResponseModel { Success = true, Message = "Roles successfully found", Data = roleDtoDatas };
        }
    }
}