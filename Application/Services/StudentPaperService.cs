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

            if (paper.Exam.IsEnded) { return new BaseResponse { Message = "Exam Already Ended", Success = false }; }

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

        public async Task<StudentsPapersResponseModel> GetStudentPapersBySubjectIdAsync(Guid subjectId, Guid levelId, Guid examId)
        {
            var level = await _levelRepository.GetAsync(levelId);
            if (level == null) { return new StudentsPapersResponseModel { Message = "Level not found", Success = false }; }

            var subject = await _subjectRepository.GetAsync(subjectId);
            if (subject == null) { return new StudentsPapersResponseModel { Message = "Subject not found", Success = false }; }

            var exam = await _examRepository.GetAsync(examId);
            if (exam == null) { return new StudentsPapersResponseModel { Message = "Exam not found", Success = false }; }

            var papers = await _paperRepository.GetExamPapersBySubjectIdAsync(examId, subjectId, levelId);
            if (papers.Count == 0) { return new StudentsPapersResponseModel { Message = "No Papaers found", Success = false }; }

            List<StudentsPapers> studentsPapers = new();
            foreach (var paper in papers)
            {
                var studentPaper = await _studentPaperRepository.GetStudentPaperAsync(paper.ExamId, paper.Id);
                studentsPapers.Add(studentPaper);
            }
            if (studentsPapers.Count == 0) { return new StudentsPapersResponseModel { Message = "No student has taking this Exam", Success = false }; }

            var studentSubjectDtoDatas = _mapper.Map<List<StudentPapersDto>>(studentsPapers);
            return new StudentsPapersResponseModel { Message = "Papers found", Success = true, Data = studentSubjectDtoDatas };
        }

        public async Task<BaseResponse> ReleasePaperResults(Guid paperId)
        {
            var paper = await _paperRepository.GetAsync(paperId);
            if (paper == null) { return new BaseResponse { Message = "Paper not found", Success = false }; }

            var students = await _studentRepository.GetStudentsByLevelIdAsync(paper.LevelId);
            if (students.Count == 0) { return new BaseResponse { Message = "No Student found for this Level", Success = false }; }

            string htmlContent = File.ReadAllText(@"..\..\Infrastructure\File\.html");
            if (htmlContent == null) { return new BaseResponse { Message = "Html Content is empty", Success = false }; }

            var mailRequests = students.Select(x => new MailRequest
            {
                Subject = "",
                ToEmail = x.User.Email,
                ToName = x.User.FullName,
                HtmlContent = htmlContent.Replace("{{FirstName}}", x.User.FullName).Replace("{{Subject}}", paper.Subject.Name)
            }).ToList();
            BackgroundJob.Enqueue(() => _mailService.GetRecievers(mailRequests));
            return new BaseResponse { Message = "Paper Results Successfully Released", Success = true };
        }
    }
}