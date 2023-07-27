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
    public class PaperService : IPaperService
    {
        private readonly IPaperRepository _paperRepository;
        private readonly IExamRepository _examRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly IExamSubjectsRepository _examSubjectsRepository;
        private readonly IStaffLevelRepository _staffLevelRepository;
        private readonly IStaffSubjectRepository _staffSubjectRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public PaperService(IPaperRepository paperRepository, IExamRepository examRepository, ISubjectRepository subjectRepository, ILevelRepository levelRepository, IExamSubjectsRepository examSubjectsRepository, IStaffLevelRepository staffLevelRepository, IStaffSubjectRepository staffSubjectRepository, IStudentRepository studentRepository, IMailService mailService, IMapper mapper)
        {
            _mapper = mapper;
            _mailService = mailService;
            _examRepository = examRepository;
            _levelRepository = levelRepository;
            _paperRepository = paperRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _staffLevelRepository = staffLevelRepository;
            _staffSubjectRepository = staffSubjectRepository;
            _examSubjectsRepository = examSubjectsRepository;
        }
        public async Task<BaseResponse> Create(CreatePaperRequestModel model, Guid examId, Guid staffId)
        {
            var exam = await _examRepository.GetAsync(x => x.Id == examId && x.IsEnded == false && x.IsDeleted == false);
            if (exam is null) { return new BaseResponse { Message = "Exam might have been ended", Success = false }; }

            var level = await _levelRepository.GetAsync(x => x.Name == model.LevelName);
            if (level is null) { return new BaseResponse { Message = "Level not found", Success = false }; }

            var levels = await _staffLevelRepository.GetAsync(x => x.StaffId == staffId && x.LevelId == level.Id);
            if (levels is null) { return new BaseResponse { Message = $"Sorry you have to be a staff of {level.Name} to create paper for them", Success = false }; }

            var subject = await _subjectRepository.GetAsync(x => x.Name == model.SubjectName);
            if (subject is null) { return new BaseResponse { Message = "Subject not found", Success = false }; }

            var subjects = await _staffSubjectRepository.GetAsync(x => x.StaffId == staffId && x.SubjectId == subject.Id);
            if (subjects is null) { return new BaseResponse { Message = $"Sorry you have to be a staff of {subject.Name} to create paper for them", Success = false }; }

            var exist = await _paperRepository.ExistsAsync(x => x.Subject.Name.Equals(model.SubjectName) && x.Exam.Term.Equals(exam.Term));
            if (exist) { return new BaseResponse { Message = $"{model.SubjectName} paper has already been created", Success = false }; }

            var paper = _mapper.Map<Paper>(model);
            paper.LevelId = level.Id;
            paper.ExamId = examId;
            paper.SubjectId = subject.Id;
            var pap = await _paperRepository.CreateAsync(paper);
            var examSubject = new ExamSubjects { ExamId = pap.ExamId, SubjectId = pap.SubjectId, };
            await _examSubjectsRepository.CreateAsync(examSubject);
            await _paperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper Successfully created", Success = true };
        }

        public async Task<PaperResponseModel> GetPaperByIdAsync(Guid id)
        {
            var paper = await _paperRepository.GetByIdAsync(id);
            if (paper is null) { return new PaperResponseModel { Message = "Paper not found", Success = false }; }

            var data = _mapper.Map<PaperDto>(paper);
            return new PaperResponseModel { Message = $"{paper.Subject.Name} paper found successfully", Success = true, Data = data };
        }

        public async Task<BaseResponse> UpdatePaperAync(Guid Id, UpdatePaperRequestModel model)
        {
            var paper = await _paperRepository.GetAsync(Id);
            if (paper is null) { return new BaseResponse { Message = "Paper not found", Success = false }; }

            var level = await _levelRepository.GetAsync(model.LevelId);
            if (level is null) { return new BaseResponse { Message = "Level not found", Success = false }; }

            var subject = await _subjectRepository.GetAsync(model.SubjectId);
            if (subject is null) { return new BaseResponse { Message = "Subject not found", Success = false }; }

            paper.SubjectId = subject.Id;
            paper.LevelId = level.Id;
            paper.Instruction = model.Instruction ?? paper.Instruction;
            paper.Duration = model.Duration;
            paper.StartDate = model.StartDate;
            await _paperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper Successfully Updated", Success = true };
        }

        public async Task<PapersResponseModel> GetAllPapersByLevelIdAsync(Guid LevelId, Guid ExamId)
        {
            var papers = await _paperRepository.GetAllAsync(x => x.LevelId == LevelId && x.ExamId == ExamId);
            if (papers.IsNullOrEmpty()) { return new PapersResponseModel { Message = "No paper found", Success = false }; }

            var papersDtoData = _mapper.Map<List<PaperDto>>(papers);
            return new PapersResponseModel { Message = "paper successfully found", Success = true, Data = papersDtoData };
        }

        public async Task<BaseResponse> StartPaperAsync(Guid paperId)
        {
            var paper = await _paperRepository.GetByIdAsync(paperId);
            if (paper is null) { return new BaseResponse { Message = "Paper not found", Success = false }; }

            if (paper.StartDate > DateTime.Now) { return new BaseResponse { Message = $"Exam is scheduled for Date: {paper.StartDate.ToLongDateString()} Time: {paper.StartDate.ToLongTimeString()}", Success = false }; }

            var students = await _studentRepository.GetStudentsByLevelIdAsync(paper.LevelId);
            if (students.IsNullOrEmpty()) { return new BaseResponse { Message = "No Student found to take this paper", Success = false }; }

            string htmlContent = File.ReadAllText(@"..\SMSApp\Infrastructure\File\ExamPaperStartEmailTemplate.html");
            if (htmlContent is null) { return new BaseResponse { Message = "Html Content is empty", Success = false }; }


            var mailRequests = students.Select(x => new MailRequest
            {
                Subject = "Attention: Exam Paper Currently in Session",
                ToEmail = x.User.Email,
                ToName = x.User.FullName,
                HtmlContent = htmlContent.Replace("{{FirstName}}", x.User.FullName).Replace("{{Subject}}", paper.Subject.Name)
            }).ToList();
            BackgroundJob.Enqueue(() => _mailService.GetRecievers(mailRequests));
            paper.PaperStatus = PaperStatus.Started;
            await _paperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper has started", Success = true };
        }

        public async Task<BaseResponse> EndPaperAsync(Guid paperId)
        {
            var paper = await _paperRepository.GetAsync(x => x.Id == paperId);
            if (paper is null) { return new BaseResponse { Message = "Paper not found", Success = false }; }

            paper.PaperStatus = PaperStatus.Ended;
            await _paperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper has started", Success = true };
        }

        public async Task<BaseResponse> TerminatePaperAsync(Guid paperId)
        {
            var paper = await _paperRepository.GetAsync(x => x.Id == paperId);
            if (paper is null) { return new BaseResponse { Message = "Paper not found", Success = false }; }

            paper.PaperStatus = PaperStatus.Terminated;
            await _paperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper has Successfully been Terminated", Success = true };
        }
    }
}