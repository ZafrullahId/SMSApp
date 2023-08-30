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
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using System.Reflection;
using Twilio.Rest.Serverless.V1.Service.Asset;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IFileUpload _fileUpload;
        private readonly ISMSService _smsservice;
        private readonly IUriService _uriService;
        private readonly IMailService _emailService;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IStaffLevelRepository _staffLevelRepository;
        public StudentService(IStudentRepository studentRepository, IUserRepository userRepository, ILevelRepository levelRepository, IRoleRepository roleRepository, IMailService emailService, IUserRoleRepository userRoleRepository, IFileUpload fileUpload, IMapper mapper, ISMSService smsservice, IStaffLevelRepository staffLevelRepository, IUriService uriService)
        {
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
            if (!exist) { return new BaseResponse { Message = "Can <b>Only</b> added by Staff of {LevelName}", Success = false }; }

            var role = await _roleRepository.GetAsync(x => x.Name.ToLower() == "student");
            if (role is null) { return new BaseResponse { Message = "Student role not found", Success = false }; }

            var phoneNoExist = await _userRepository.ExistsAsync(x => x.PhoneNumber == model.PhoneNumber);
            if (phoneNoExist) { return new BaseResponse { Message = "Phone number already exist", Success = false }; }
            var user = new User
            {
                Password = new Random().Next(2014, 9089).ToString(),
                PhoneNumber = model.PhoneNumber,
            };
            var student = new Student { LevelId = level.Id, UserId = user.Id, User = user };
            await _studentRepository.CreateAsync(student);
            await _studentRepository.SaveChangesAsync();
            string body = $"Congratulations! Your admission number is {student.AdmissionNo} and " +
                $"your password is {user.Password}. To complete your profile and change your password please visit <url>";
            var sent = _smsservice.SendSmsAsync(model.PhoneNumber, "18787897387", body);
            if (!sent) { return new BaseResponse { Message = "Something went wrong", Success = false }; }
            return new BaseResponse { Message = "Student successfully added", Success = true };
        }
        public async Task<Response<StudentDto>> GetStudentByUserIdAsync(Guid userId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);
            if (user is null) { return new Response<StudentDto> { Message = "User not found", Success = false }; }

            var student = await _studentRepository.GetAsync(x => x.UserId == userId);
            if (student is null) { return new Response<StudentDto> { Message = "Student not found", Success = false }; }

            var level = await _levelRepository.GetAsync(x => x.Id == student.LevelId);
            if (level is null) { return new Response<StudentDto> { Message = "Level not found", Success = false }; }

            student.User = user;
            student.Level = level;
            var studentDtoData = _mapper.Map<StudentDto>(student);
            return new Response<StudentDto> { Message = "Student Successfully retrieved", Success = true, Data = studentDtoData };
        }

        public async Task<Responses<StudentDto>> GetAllStudentsAsync(PaginationFilter filter, string route)
        {
            var students = await _studentRepository.GetFilterAsync(filter.PageNumber, filter.PageSize);
            if (students.IsNullOrEmpty()) { return new Responses<StudentDto> { Message = "No student yet", Success = false }; }

            List<StudentDto> studentDtos = new();

            foreach (var student in students)
            {

                var user = await _userRepository.GetAsync(x => x.Id == student.UserId);
                if (user is null) { return new Responses<StudentDto> { Message = "User not found", Success = false }; }

                var level = await _levelRepository.GetAsync(x => x.Id == student.LevelId);
                student.User = user;
                student.Level = level;
                var studentDtoData = _mapper.Map<StudentDto>(student);
                studentDtos.Add(studentDtoData);
            }
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = await _studentRepository.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<StudentDto>(studentDtos, validFilter, totalRecords, _uriService, route);
            return new Responses<StudentDto> { Message = "Students successfully retrieved", Success = true, Data = pagedReponse };
        }

        public async Task<BaseResponse> UpdateStudentAsync(Guid userId, UpdateStudentRequestModel model)
        {
            var student = await _studentRepository.GetStudentAsync(userId);
            if (student is null) { return new BaseResponse { Message = "Profile not found", Success = false }; }

            var mailExist = await _userRepository.ExistsAsync(x => x.Email == model.Email);
            if (mailExist) { return new BaseResponse { Message = "Email already in use",Success = false }; }

            student.NextOfKin = model.NextOfKin ?? student.NextOfKin;
            student.DateOfBirth = model.DateOfBirth ?? student.DateOfBirth;
            student.User.Password = model.Password ?? student.User.Password;
            student.User.Email = model.Email ?? student.User.Email;
            student.User.FullName = model.FullName ?? student.User.FullName;
            student.User.PhoneNumber = model.PhoneNumber ?? student.User.PhoneNumber;
            student.User.ProfileImage = model.ProfileImage != null ? await _fileUpload.UploadPicAsync(model.ProfileImage) : student.User.ProfileImage;
            await _studentRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Sussessfully Updated", Success = true, };
        }

        public async Task<BaseResponse> UploadStudentListFileAsync(IFormFile file)
        {
            var isAValidFileExtension = FileUpload.CheckFileExtensionAsync(file);
            int addedCount = 0;
            int duplicateCount = 0;
            int invalidFormatCount = 0;
            if (!isAValidFileExtension)
            {
                return new BaseResponse { Message = "Invalid file format. Only .xlsx and .xml files are allowed. ", Success = false };
            }
            var isValidHeadFormat = FileUpload.FileHeadFormat(file);
            if (!isValidHeadFormat)
            {
                return new BaseResponse { Message = "The header should be in the format S/N | Class | Phone", Success = false };
            }
            using var package = new ExcelPackage(file.OpenReadStream());
            var worksheet = package.Workbook.Worksheets[0];
            for (int row = 2; row <= worksheet.Dimension.Rows; row++)
            {
                var user = new User
                {
                    Password = new Random().Next(2116, 9089).ToString(),
                    PhoneNumber = worksheet.Cells[row, 3].Value.ToString()
                };
                var level = await _levelRepository.GetAsync(x => x.Name.Equals(worksheet.Cells[row, 2].Value.ToString()));
                if (level is null) { invalidFormatCount++;  continue; }

                var student = new Student { LevelId = level.Id, UserId = user.Id, User = user, Level = level };
                var studentExist = await _studentRepository.ExistsAsync(x => x.User.PhoneNumber == user.PhoneNumber && x.LevelId == level.Id);
                if (studentExist) { duplicateCount++; continue; }
                await _studentRepository.CreateAsync(student);
                addedCount++;
            }
            await _studentRepository.SaveChangesAsync();
            return new BaseResponse { Message = $"{addedCount} Student added, {duplicateCount} dupliacte and {invalidFormatCount} wrong input", Success = true };
        }
    }
}