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
        private readonly IStudentRepository  _studentRepository;
        public UserService(IUserRepository userRepository, IConfiguration config, IJWTAuthenticationManager tokenService, IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _config = config;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _studentRepository = studentRepository;
        }

        public async Task<Response<LoginDto>> LoginAsync(LoginRequestModel model)
        {
            var auth = await _userRepository.LoginAsync(x => x.User.Email == model.Email && x.User.Password == model.Password);
            if (auth == null) { return new Response<LoginDto> { Message = "Invalid Credentials", Success = false, }; }

            //var roles = await _userRepository.GetUserRolesAsync(x => x.UserId == auth.UserId);
            //if (roles.IsNullOrEmpty()) { return new Response<LoginDto> { Message = "No role found for this user", Success = false, }; }

            var roleDtos = _mapper.Map<RoleDto>(auth.Role);
            var userDto = new UserDto
            {
                Id = auth.UserId,
                Role = roleDtos,
                Email = auth.User.Email,
                FullName = auth.User.FullName,
                ProfileImage = auth.User.ProfileImage,
                Password = auth.User.Password,
                PhoneNumber = auth.User.PhoneNumber,
            };
            generatedToken = _tokenService.GenerateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), userDto);
            return new Response<LoginDto> { Message = "Valid Credential", Success = true, Data = new LoginDto { Token = generatedToken, Roles = 
                userDto.Role.Name } };
        }
        public async Task<Response<LoginDto>> LoginAsync(StudentLoginRequestModel model)
        {
            var student = await _studentRepository.GetAsync(x => x.AdmissionNo == model.AdmissionNo && x.User.Password == model.Password);
            if (student == null) { return new Response<LoginDto> { Message = "Invalid Credentials", Success = false, }; }

            var userRoles = await _userRepository.LoginAsync(x => x.UserId == student.UserId);
            if (userRoles is null) { return new Response<LoginDto> { Message = "No role found for this user", Success = false, }; }

            var roleDtos = _mapper.Map<RoleDto>(userRoles.Role);
            var userDto = _mapper.Map<UserDto>(userRoles.User);
            userDto.Role = roleDtos;
            if (userDto.IsProfileComplete)
            {
                generatedToken = _tokenService.GenerateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), userDto);
            }
            else
            {
                generatedToken = _tokenService.GenerateNotCompletedProfileToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), userDto);
            }
            return new Response<LoginDto> { Message = "Valid Credential", Success = true, Data = new LoginDto { Token = generatedToken, Roles = 
                userDto.Role.Name} };
        }
    }
}