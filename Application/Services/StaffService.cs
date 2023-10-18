using Application.Abstractions;
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
    public class StaffService : IStaffService
    {
        private readonly IMapper _mapper;
        private readonly IFileUpload _fileUpload;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IStaffLevelRepository _staffLevelRepository;
        private readonly IStaffSubjectRepository _staffSubjectRepository;
        public StaffService(IStaffRepository staffRepository, IUserRepository userRepository, ILevelRepository levelRepository, ISubjectRepository subjectRepository, IStaffLevelRepository staffLevelRepository, IStaffSubjectRepository staffSubjectRepository, IRoleRepository roleRepository, IFileUpload fileUpload, IMapper mapper, IUserRoleRepository userRoleRepository)
        {
            _mapper = mapper;
            _fileUpload = fileUpload;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _staffRepository = staffRepository;
            _levelRepository = levelRepository;
            _subjectRepository = subjectRepository;
            _userRoleRepository = userRoleRepository;
            _staffLevelRepository = staffLevelRepository;
            _staffSubjectRepository = staffSubjectRepository;
        }

        public async Task<BaseResponse> Create(CreateStaffRequestModel model)
        {
            var exist = await _userRepository.ExistsAsync(x => x.Email == model.Email);
            if (exist) { return new BaseResponse { Message = "User Already Exist", Success = false, }; }
            
            var path = await _fileUpload.UploadPicAsync(model.ProfileUpload);
            var user = _mapper.Map<User>(model);
            user.ProfileImage = path;
            await _userRepository.CreateAsync(user);

            var staff = new Staff { User = user };
            await _staffRepository.CreateAsync(staff);

            foreach (var l in model.Levels)
            {
                var level = await _levelRepository.GetAsync(x => x.Name == l);
                if (level is null) { return new BaseResponse { Message = $"Level {l} not found", Success = false, }; }
                
                var staffLevel = new StaffsLevels
                {
                    LevelId = level.Id,
                    StaffId = staff.Id,
                };
                await _staffLevelRepository.CreateAsync(staffLevel);
            }

            foreach (var s in model.Subjects)
            {
                var subject = await _subjectRepository.GetAsync(x => x.Name == s);
                if (subject is null) { return new BaseResponse { Message = $"Subject {s} not found", Success = false, }; }
                
                var staffSubjects = new StaffsSubjects { SubjectId = subject.Id, StaffId = staff.Id, };
                await _staffSubjectRepository.CreateAsync(staffSubjects);
            }

            foreach (var r in model.Roles)
            {
                var role = await _roleRepository.GetAsync(x => x.Name == r);
                if (role is null) { return new BaseResponse { Message = $"Role {r} not found", Success = false, }; }
                
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = role.Id,
                };
                await _userRoleRepository.CreateAsync(userRole);
            }
            await _userRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Staff Successfully Added", Success = true, };
        }

        public async Task<Response<StaffLevelSubjectDto>> GetAsync(Guid id)
        {
            var staff = await _staffRepository.GetStaffByUserIdAsync(id);
            if (staff is null) { return new Response<StaffLevelSubjectDto> { Message = "Staff not found", Success = false, }; }
            
            var levels = await _staffLevelRepository.GetLevelsByStaffIdAsync(staff.Id);
            if (levels.IsNullOrEmpty()) { return new Response<StaffLevelSubjectDto> { Message = "No Levels found for this satff", Success = false, }; }
            
            staff.StaffsLevels = levels;
            var subjects = await _staffSubjectRepository.GetStaffSubjectsAsync(staff.Id);
            if (subjects.IsNullOrEmpty()) { return new Response<StaffLevelSubjectDto> { Message = "No Subject found for this staff", Success = false, }; }
            
            staff.StaffsSubjects = subjects;
            var staffLevelSubjectDtoData = _mapper.Map<StaffLevelSubjectDto>(staff);
            return new Response<StaffLevelSubjectDto> { Message = "Staff Info successfully retrieved", Success = true, Data = staffLevelSubjectDtoData };
        }

        public async Task<BaseResponse> UpdateAsync(Guid id, UpdateStaffRequestModel model)
        {
            var staff = await _staffRepository.GetStaffByUserIdAsync(id);
            if (staff is null) { return new BaseResponse { Message = "Staff not found", Success = false }; }
            
            staff.User.FullName = model.FullName ?? staff.User.FullName;
            staff.User.Email = model.Email ?? staff.User.Email;
            staff.User.Password = model.Password ?? staff.User.Password;
            staff.User.PhoneNumber = model.PhoneNumber ?? staff.User.PhoneNumber;
            staff.User.ProfileImage = model.ProfileImage ?? staff.User.ProfileImage;
            await _staffRepository.UpdateAsync(staff);
            return new BaseResponse { Message = "Successfully Updated", Success = true, };
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            var staff = await _staffRepository.GetAsync(id);
            if (staff is null) { return new BaseResponse { Message = "Staff user", Success = false }; }
            
            var user = await _userRepository.GetAsync(staff.UserId);
            user.IsDeleted = true;
            await _userRepository.UpdateAsync(user);
            return new BaseResponse { Message = "Successfully Deleted", Success = true, };
        }
    }
}