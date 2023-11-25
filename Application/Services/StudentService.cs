using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;
using Application.Helpers;
using Application.Uploads;
using AutoMapper;
using Domain.Entity;
using Domain.Entity.Identity;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using System.Reflection;
using Twilio.Rest.Serverless.V1.Service.Asset;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IFileUpload _fileUpload;
        private readonly ISMSService _smsservice;
        private readonly IUriService _uriService;
        private readonly IMailService _emailService;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStaffLevelRepository _staffLevelRepository;
        private readonly IJWTAuthenticationManager _jwtAuthenticationManager;
        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository, ILevelRepository levelRepository, IRoleRepository roleRepository, IMailService emailService, IUserRoleRepository userRoleRepository, IFileUpload fileUpload, IMapper mapper, ISMSService smsservice, IStaffLevelRepository staffLevelRepository, IUriService uriService, IDepartmentRepository departmentRepository, IJWTAuthenticationManager jwtAuthenticationManager, IConfiguration config)
        {
            _config = config;
            _mapper = mapper;
            _smsservice = smsservice;
            _fileUpload = fileUpload;
            _uriService = uriService;
            _emailService = emailService;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _levelRepository = levelRepository;
            _studentRepository = studentRepository;
            _userRoleRepository = userRoleRepository;
            _staffLevelRepository = staffLevelRepository;
            _departmentRepository = departmentRepository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
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

        public async Task<BaseResponse> CreateAsync(CreateStudentRequestModel model, Guid staffUserId)
        {
            var level = await _levelRepository.GetAsync(x => x.Name == model.LevelName);
            var exist = await _staffLevelRepository.ExistsAsync(x => x.Staff.UserId == staffUserId && x.LevelId == level.Id);
            if (!exist) { return new BaseResponse { Message = $"Can Only added by Staff of {level.Name}", Success = false }; }

            var role = await _roleRepository.GetAsync(x => x.Name.ToLower() == "student");
            if (role is null) { return new BaseResponse { Message = "Student role not found", Success = false }; }

            var department = await _departmentRepository.GetAsync(model.DepartmentId);
            if (department is null) { return new BaseResponse { Success = false, Message = "Department not found" }; }

            var phoneNoExist = await _userRepository.ExistsAsync(x => x.PhoneNumber == model.PhoneNumber);
            if (phoneNoExist) { return new BaseResponse { Message = "Phone number already exist", Success = false }; }
            var user = new User
            {
                Password = new Random().Next(2014, 9089).ToString(),
                PhoneNumber = model.PhoneNumber,
            };
            var userRole = new UserRole { UserId = user.Id, RoleId = role.Id };
            await _userRoleRepository.CreateAsync(userRole);
            var student = new Student { LevelId = level.Id, UserId = user.Id, User = user, DepartmentId = department.Id };
            await _studentRepository.CreateAsync(student);
            await _studentRepository.SaveChangesAsync();
            string body = $"Congratulations! You've been successfully added to {department.Name} Department {level.Name}. Your admission number is {student.AdmissionNo} and " +
                $"your password is {user.Password}. To complete your profile and change your password please visit <url>";
            var sent = _smsservice.SendSmsAsync(model.PhoneNumber, "18787897387", body);
            if (!sent) { return new BaseResponse { Message = "Something went wrong", Success = false }; }
            return new BaseResponse { Message = "Student successfully added", Success = true };
        }
        public async Task<Response<Token>> GetStudentByUserIdAsync(Guid userId)
        {
            var userRole = await _userRoleRepository.GetStudentAsync(userId);
            if (userRole == null) { return new Response<Token> { Message = "Student not found", Success = false }; }
            if (!userRole.User.IsProfileComplete) { return new Response<Token> { Message = "Profile not Completed", Success = false }; }
            var studentDtoData = _mapper.Map<StudentDto>(userRole.User.Student);
            studentDtoData.User.Role = _mapper.Map<RoleDto>(userRole.Role);
            var token = _jwtAuthenticationManager.GenerateToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), studentDtoData);

            return new Response<Token> { Message = "Student Successfully retrieved", Success = true, Data = new () { AuthToken = token} };
        }

        public async Task<Results<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            if (students.IsNullOrEmpty()) { return new Results<StudentDto> { Message = "No student yet", Success = false }; }

            List<StudentDto> studentDtos = new();

            foreach (var student in students)
            {

                var user = await _userRepository.GetAsync(x => x.Id == student.UserId);
                if (user is null) { return new Results<StudentDto> { Message = "User not found", Success = false }; }

                var level = await _levelRepository.GetAsync(x => x.Id == student.LevelId);
                student.User = user;
                student.Level = level;
                var studentDtoData = _mapper.Map<StudentDto>(student);
                studentDtos.Add(studentDtoData);
            }
            //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //var totalRecords = await _studentRepository.CountAsync();
            //var pagedReponse = PaginationHelper.CreatePagedReponse<StudentDto>(studentDtos, validFilter, totalRecords, _uriService, route);
            return new Results<StudentDto> { Message = "Students successfully retrieved", Success = true, Data = studentDtos };
        }

        public async Task<BaseResponse> UpdateStudentAsync(Guid userId, UpdateStudentRequestModel model)
        {
            var student = await _studentRepository.GetStudentAsync(userId);
            if (student is null) { return new BaseResponse { Message = "Profile not found", Success = false }; }

            student.NextOfKin = model.NextOfKin ?? student.NextOfKin;
            student.DateOfBirth = model.DateOfBirth ?? student.DateOfBirth;
            student.User.Password = model.Password ?? student.User.Password;
            student.User.Email = model.Email ?? student.User.Email;
            student.User.FullName = model.FullName ?? student.User.FullName;
            student.User.PhoneNumber = model.PhoneNumber ?? student.User.PhoneNumber;
            student.User.ProfileImage = model.ProfileImage;
            student.User.IsProfileComplete = true;
            await _studentRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Sussessfully Updated", Success = true, };
        }

        public async Task<BaseResponse> UploadStudentListFileAsync(IFormFile file)
        {
            var isAValidFileExtension = FileUpload.CheckFileExtensionAsync(file);
            int addedCount = 0;
            int duplicateCount = 0;
            int invalidFormatCount = 0;
            if (!isAValidFileExtension) { return new BaseResponse { Message = "Invalid file format. Only .xlsx and .xml files are allowed. ", Success = false }; }

            var isValidHeadFormat = FileUpload.FileHeadFormat(file);
            if (!isValidHeadFormat) { return new BaseResponse { Message = "The header should be in the format S/N | Class | Phone | Department", Success = false }; }

            List<Student> addedStudent = new();
            using var package = new ExcelPackage(file.OpenReadStream());
            var worksheet = package.Workbook.Worksheets[0];
            for (int row = 2; row <= worksheet.Dimension.Rows; row++)
            {
                var user = new User
                {
                    Password = new Random().Next(2116, 9089).ToString(),
                    PhoneNumber = worksheet.Cells[row, 3].Value.ToString()
                };
                var level = await _levelRepository.GetAsync(x => x.Name.ToLower().Equals(worksheet.Cells[row, 2].Value.ToString().ToLower()));
                if (level is null) { invalidFormatCount++; continue; }

                var department = await _departmentRepository.GetAsync(x => x.Name.ToLower().Equals(worksheet.Cells[row, 3].Value.ToString().ToLower()));
                if (department is null) { invalidFormatCount++; continue; }

                var student = new Student { LevelId = level.Id, UserId = user.Id, User = user, Level = level, DepartmentId = department.Id };
                var studentExist = await _studentRepository.ExistsAsync(x => x.User.PhoneNumber == user.PhoneNumber && x.LevelId == level.Id);
                if (studentExist) { duplicateCount++; continue; }

                await _studentRepository.CreateAsync(student);
                addedStudent.Add(student);
                addedCount++;
            }
            await _studentRepository.SaveChangesAsync();

            BackgroundJob.Enqueue(() => _smsservice.SendBulkySms(addedStudent, "18787897387"));
            return new BaseResponse { Message = $"{addedCount} Student added, {duplicateCount} dupliacte and {invalidFormatCount} wrong input", Success = true };
        }
    }
}