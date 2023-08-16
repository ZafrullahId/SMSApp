using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Domain.Entity.Identity;
using Hangfire;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IFileUpload _fileUpload;
        private readonly ISMSService _smsservice;
        private readonly IMailService _emailService;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository, ILevelRepository levelRepository, IRoleRepository roleRepository, IMailService emailService, IUserRoleRepository userRoleRepository, IFileUpload fileUpload, IMapper mapper = null, ISMSService smsservice = null)
        {
            _mapper = mapper;
            _fileUpload = fileUpload;
            _smsservice = smsservice;
            _emailService = emailService;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _levelRepository = levelRepository;
            _studentRepository = studentRepository;
            _userRoleRepository = userRoleRepository;
        }
        //public async Task<BaseResponse> CreateAsync(UpdateStudentRequestModel model)
        //{
        //    var exist = await _userRepository.ExistsAsync(x => x.Email == model.User.Email);
        //    if (exist) { return new BaseResponse { Message = "Email Already in use", Success = false }; }


        //    var role = await _roleRepository.GetAsync(x => x.Name.ToLower() == "student");
        //    if (role is null) { return new BaseResponse { Message = "Student role not found", Success = false }; }


        //    var level = await _levelRepository.GetAsync(x => x.Name == model.Class);
        //    if (level is null) { return new BaseResponse { Message = "Level not found", Success = false }; }


        //    var path = await _fileUpload.UploadPicAsync(model.User.ProfileUpload);

        //    var student = _mapper.Map<Student>(model);
        //    student.LevelId = level.Id;
        //    await _studentRepository.CreateAsync(student);

        //    var userRole = new UserRole { RoleId = role.Id, UserId = student.User.Id, };
        //    await _userRoleRepository.CreateAsync(userRole);
        //    string htmlContent = File.ReadAllText(@"..\Persistence\File\StudentRegistrationEmailTemplate.html");
        //    if (htmlContent is null)
        //    {
        //        return new BaseResponse { Message = "Html Content is empty", Success = false };
        //    }
        //    var mailRequest = new MailRequest
        //    {
        //        Subject = "Success Extrammural Classes - Unlock the Power of Education at Your Fingertips!",
        //        ToEmail = student.User.Email,
        //        ToName = student.User.FullName,
        //        HtmlContent = htmlContent.Replace("{{Student Name}}", student.User.FullName)
        //    };
        //    _emailService.SendEMailAsync(mailRequest);
        //    await _studentRepository.SaveChangesAsync();

        //    return new BaseResponse { Message = "Successfully registered", Success = true, };
        //}

        public async Task<BaseResponse> CreateAsync(CreateStudentRequestModel model)
        {
            var level = await _levelRepository.GetAsync(x => x.Name == model.LevelName);
            var role = await _roleRepository.GetAsync(x => x.Name.ToLower() == "student");
            if (role is null) { return new BaseResponse { Message = "Student role not found", Success = false }; }

            var exist = await _userRepository.ExistsAsync(x => x.PhoneNumber == model.PhoneNumber);
            if (exist) { return new BaseResponse { Message = "Phone number already exist", Success = false }; }
            var user = new User
            {
                Password = new Random().Next(2014, 9089).ToString(),
                PhoneNumber = model.PhoneNumber,
            };
            var student = new Student { LevelId = level.Id, UserId = user.Id, User = user };
            await _studentRepository.CreateAsync(student);
            await _studentRepository.SaveChangesAsync();
            string body = $"Congratulations! Your admission number is {student.AdmissionNo} and " +
                $"your password is {user.Password}. To complete your profile and change your password pls vist <url>";
            var sent = _smsservice.SendSmsAsync(model.PhoneNumber, "18787897387", body);
            if (!sent) { return new BaseResponse { Message = "Something went wrong", Success = false }; }
            return new BaseResponse { Message = "Student successfully added", Success = true };
        }
        public async Task<StudentResponseModel> GetStudentByUserIdAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);
            if (user is null) { return new StudentResponseModel { Message = "User not found", Success = false }; }

            var student = await _studentRepository.GetAsync(x => x.UserId == userId);
            if (student is null) { return new StudentResponseModel { Message = "Student not found", Success = false }; }

            var level = await _levelRepository.GetAsync(x => x.Id == student.LevelId);
            if (level is null) { return new StudentResponseModel { Message = "Level not found", Success = false }; }

            student.User = user;
            student.Level = level;
            var studentDtoData = _mapper.Map<StudentDto>(student);
            return new StudentResponseModel { Message = "Student Successfully retrieved", Success = true, Data = studentDtoData };
        }

        public async Task<StudentsResponseModel> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            if (students.IsNullOrEmpty()) { return new StudentsResponseModel { Message = "No student yet", Success = false }; }

            List<StudentDto> studentDtos = new();

            foreach (var student in students)
            {

                var user = await _userRepository.GetAsync(x => x.Id == student.UserId);
                if (user is null) { return new StudentsResponseModel { Message = "User not found", Success = false }; }

                var level = await _levelRepository.GetAsync(x => x.Id == student.LevelId);
                student.User = user;
                student.Level = level;
                var studentDtoData = _mapper.Map<StudentDto>(student);
                studentDtos.Add(studentDtoData);
            }
            return new StudentsResponseModel { Message = "Students successfully retrieved", Success = true, Data = studentDtos };
        }

        public async Task<BaseResponse> UpdateStudentAsync(Guid userId, UpdateStudentRequestModel model)
        {
            var student = await _studentRepository.GetStudentAsync(userId);
            if (student is null) { return new BaseResponse { Message = "Profile not found", Success = false }; }

            student.NextOfKin = model.NextOfKin ?? student.NextOfKin;
            student.DateOfBirth = model.DateOfBirth ?? student.DateOfBirth;
            student.User.Password = model.Password ?? student.User.Password;
            student.User.FullName = model.FullName ?? student.User.FullName;
            student.User.PhoneNumber = model.PhoneNumber ?? student.User.PhoneNumber;
            student.User.ProfileImage = model.ProfileImage ?? student.User.ProfileImage;
            await _studentRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Sussessfully Updated", Success = true, };
        }
        
    }
}