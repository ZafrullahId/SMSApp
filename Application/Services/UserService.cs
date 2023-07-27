using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly IJWTAuthenticationManager _tokenService;
        private string generatedToken = null;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IConfiguration config, IJWTAuthenticationManager tokenService, IMapper mapper)
        {
            _userRepository = userRepository;
            _config = config;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel model)
        {
            var user = await _userRepository.LoginAsync(x => x.User.Email == model.Email && x.User.Password == model.Password);
            if (user == null) { return new LoginResponseModel { Message = "Invalid Credentials", Success = false, }; }

            var roles = await _userRepository.GetUserRolesAsync(x => x.UserId == user.UserId);
            if (roles.Count == 0) { return new LoginResponseModel { Message = "No role found for this user", Success = false, }; }

            var roleDtos = _mapper.Map<List<RoleDto>>(roles);
            var userDto = new UserDto
            {
                Id = user.UserId,
                Email = user.User.Email,
                Roles = roleDtos
            };
            generatedToken = _tokenService.GenerateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), userDto);
            return new LoginResponseModel { Message = "Valid Credential", Success = true, Data = new LoginDto { Token = generatedToken } };
        }
    }
}