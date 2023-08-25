using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Hangfire;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class StudentPaperService : IStudentPaperService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IPaperRepository _paperRepository;
        private readonly IStudentPaperRepository _studentPaperRepository;
        private readonly IExamRepository _examRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public StudentPaperService(IStudentRepository studentRepository, IStudentPaperRepository studentSubjectRepository, IExamRepository examRepository, IPaperRepository paperRepository, ISubjectRepository subjectRepository, ILevelRepository levelRepository, IMailService mailService, IMapper mapper)
        {
            _examRepository = examRepository;
            _studentRepository = studentRepository;
            _studentPaperRepository = studentSubjectRepository;
            _paperRepository = paperRepository;
            _subjectRepository = subjectRepository;
            _levelRepository = levelRepository;
            _mailService = mailService;
            _mapper = mapper;
        }
        public async Task<BaseResponse> CreateStudentPaperAsync(Guid studentUserId, Guid paperId)
        {
            var studentUser = await _studentRepository.GetStudentAsync(studentUserId);
            if (studentUser == null) { return new BaseResponse { Message = "Student not found", Success = false }; }

            var paper = await _paperRepository.GetPaperAsync(paperId);
            if (paper == null) { return new BaseResponse { Message = "This Paper Dosn't exist", Success = false }; }

            if (paper.PaperStatus == PaperStatus.Ended) { return new BaseResponse { Message = "This Paper has been ended", Success = false }; }

            if (paper.PaperStatus == PaperStatus.Pending) { return new BaseResponse { Message = "This Paper has not Started yet", Success = false }; }

            if (paper.PaperStatus == PaperStatus.Terminated) { return new BaseResponse { Message = "This Paper has been Terminated", Success = false }; }

            if (paper.Exam.IsEnded) { return new BaseResponse { Message = "Exam Season Already Ended", Success = false }; }

            var exist = await _studentPaperRepository.ExistsAsync(x => x.StudentId == studentUser.Id && x.PaperId == paperId);
            if (exist) { return new BaseResponse { Message = "Exam paper has been taking by you already", Success = false }; }

            var studentPaper = new StudentsPapers
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

        public async Task<StudentPaperResponseModel> GetStudentPaper(Guid studentId, Guid paperId)
        {
            var student = await _studentRepository.GetAsync(studentId);
            if (student == null) { return new StudentPaperResponseModel { Message = "Subject not found", Success = false }; }

            var paper = await _paperRepository.GetAsync(paperId);
            if (paper == null) { return new StudentPaperResponseModel { Message = "Paper not found", Success = false }; }

            var studentSubject = await _studentPaperRepository.GetStudentPaperByStudentId(studentId, paperId);
            if (studentSubject == null) { return new StudentPaperResponseModel { Message = "No Student has done this exam", Success = false }; }

            var studentSubjectDtoData = _mapper.Map<StudentPapersDto>(studentSubject);
            return new StudentPaperResponseModel { Message = "Successful", Success = true, Data = studentSubjectDtoData };
        }

        public async Task<StudentsPapersResponseModel> GetStudentsPapersAsync(Guid paperId)
        {
            var paper = await _paperRepository.GetAsync(paperId);
            if (paper is null) { return new StudentsPapersResponseModel { Message = "No paper found", Success = false }; }

            var studentPapers = await _studentPaperRepository.GetStudentPaperAsync(paperId);
            if (studentPapers.IsNullOrEmpty()) { return new StudentsPapersResponseModel { Message = "No student has taking this Exam", Success = false }; }

            var studentSubjectDtoDatas = _mapper.Map<List<StudentPapersDto>>(studentPapers);
            return new StudentsPapersResponseModel { Message = "Papers found", Success = true, Data = studentSubjectDtoDatas };
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