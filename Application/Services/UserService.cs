using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private string generatedToken = null;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepository;
        private readonly IJWTAuthenticationManager _tokenService;
        public UserService(IUserRepository userRepository, IConfiguration config, IJWTAuthenticationManager tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<Response<LoginDto>> LoginAsync(LoginRequestModel model)
        {
            var user = await _userRepository.LoginAsync(x => x.User.Email == model.Email && x.User.Password == model.Password);
            if (user == null) { return new Response<LoginDto> { Message = "Invalid Credentials", Success = false, }; }

            var roles = await _userRepository.GetUserRolesAsync(x => x.UserId == user.UserId);
            if (roles.IsNullOrEmpty()) { return new Response<LoginDto> { Message = "No role found for this user", Success = false, }; }

            var roleDtos = _mapper.Map<List<RoleDto>>(roles);
            var userDto = new UserDto
            {
                Id = user.UserId,
                Email = user.User.Email,
                Roles = roleDtos
            };
            generatedToken = _tokenService.GenerateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), userDto);
            return new Response<LoginDto> { Message = "Valid Credential", Success = true, Data = new LoginDto { Token = generatedToken } };
        }
    }
}