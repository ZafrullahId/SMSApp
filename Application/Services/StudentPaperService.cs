using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;
using Application.Helpers;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Hangfire;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class StudentPaperService : IStudentPaperService
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IMailService _mailService;
        private readonly IPaperRepository _paperRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentPaperRepository _studentPaperRepository;

        public StudentPaperService(IStudentRepository studentRepository, IStudentPaperRepository studentSubjectRepository, IPaperRepository paperRepository, IMailService mailService, IMapper mapper, IUriService uriService)
        {
            _mapper = mapper;
            _uriService = uriService;
            _mailService = mailService;
            _paperRepository = paperRepository;
            _studentRepository = studentRepository;
            _studentPaperRepository = studentSubjectRepository;
        }
        public async Task<BaseResponse> CreateStudentPaperAsync(Guid studentUserId, Guid paperId)
        {
            var studentUser = await _studentRepository.GetStudentAsync(studentUserId);
            if (studentUser == null) { return new BaseResponse { Message = "Student not found", Success = false }; }

            var paper = await _paperRepository.GetAsync(paperId);
            if (paper == null) { return new BaseResponse { Message = "This Paper Dosn't exist", Success = false }; }

            if (paper.PaperStatus == PaperStatus.Ended) { return new BaseResponse { Message = "This Paper has been ended", Success = false }; }

            if (paper.PaperStatus == PaperStatus.Pending) { return new BaseResponse { Message = "This Paper has not Started yet", Success = false }; }

            if (paper.PaperStatus == PaperStatus.Terminated) { return new BaseResponse { Message = "This Paper has been Terminated", Success = false }; }

            if (paper.Exam.IsEnded) { return new BaseResponse { Message = "Exam Season Already Ended", Success = false }; }

            var exist = await _studentPaperRepository.ExistsAsync(x => x.StudentId == studentUser.Id && x.PaperId == paperId);
            if (exist) { return new BaseResponse { Message = "Exam paper has been taking by you already", Success = false }; }

            var studentPaper = new StudentPaper
            {
                StudentId = studentUser.Id,
                PaperId = paper.Id,
                Score = 0,
                Student = studentUser,
                Paper = paper
            };
            await _studentPaperRepository.CreateAsync(studentPaper);
            await _studentPaperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Successfully Created", Success = true };
        }

        public async Task<Response<StudentPapersDto>> GetStudentPaper(Guid studentId, Guid paperId)
        {
            var student = await _studentRepository.GetAsync(studentId);
            if (student == null) { return new Response<StudentPapersDto> { Message = "Subject not found", Success = false }; }

            var paper = await _paperRepository.GetAsync(paperId);
            if (paper == null) { return new Response<StudentPapersDto> { Message = "Paper not found", Success = false }; }

            var studentSubject = await _studentPaperRepository.GetStudentPaperByStudentId(studentId, paperId);
            if (studentSubject == null) { return new Response<StudentPapersDto> { Message = "No Student has done this exam", Success = false }; }

            var studentSubjectDtoData = _mapper.Map<StudentPapersDto>(studentSubject);
            return new Response<StudentPapersDto> { Message = "Successful", Success = true, Data = studentSubjectDtoData };
        }

        public async Task<Results<StudentPapersDto>> GetStudentsPapersAsync(Guid paperId)
        {
            var paper = await _paperRepository.GetAsync(paperId);
            if (paper is null) { return new Results<StudentPapersDto> { Message = "No paper found", Success = false }; }

            var studentPapers = await _studentPaperRepository.GetStudentPaperAsync(paperId);
            if (studentPapers.IsNullOrEmpty()) { return new Results<StudentPapersDto> { Message = "No student has taking this Exam", Success = false }; }

            var studentPaperDtoData = _mapper.Map<List<StudentPapersDto>>(studentPapers);
            //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //var totalRecords = await _studentPaperRepository.CountAsync(x => x.PaperId == paperId);
            //var pagedReponse = PaginationHelper.CreatePagedReponse<StudentPapersDto>(studentPaperDtoData, validFilter, totalRecords, _uriService, route);
            return new Results<StudentPapersDto> { Message = "Papers found", Success = true, Data = studentPaperDtoData };
        }

        public async Task<BaseResponse> ReleasePaperResults(Guid paperId)
        {
            var paper = await _paperRepository.GetAsync(paperId);
            if (paper == null) { return new BaseResponse { Message = "Paper not found", Success = false }; }


            var studentPaper = await _studentPaperRepository.GetAllAsync(paperId);
            if (studentPaper.IsNullOrEmpty()) { return new BaseResponse { Message = "No Student sat for this Paper", Success = false }; }

            string htmlContent = File.ReadAllText(@"..\Persistence\File\PaperResultOutEmail.html") ?? throw new NullReferenceException();
            var mailRequests = studentPaper.Select(x => new MailRequest
            {
                Subject = "Result Release: Check Your Exam Score",
                ToEmail = x.Student.User.Email,
                ToName = x.Student.User.FullName,
                HtmlContent = htmlContent.Replace("{{NAME}}", x.Student.User.FullName).Replace("{{SCORE}}", x.Score.ToString())
            }).ToList();
            BackgroundJob.Enqueue(() => _mailService.GetRecievers(mailRequests));
            paper.IsReleased = true;
            await _studentPaperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper Results Successfully Released", Success = true };
        }
    }
}