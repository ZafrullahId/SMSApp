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
    public class PaperService : IPaperService
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IMailService _mailService;
        private readonly IExamRepository _examRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly IPaperRepository _paperRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly IStaffLevelRepository _staffLevelRepository;
        private readonly IStaffSubjectRepository _staffSubjectRepository;
        private readonly IExamSubjectsRepository _examSubjectsRepository;
        private readonly ILevelTimeTableRepository _levelTimeTableRepository;
        private readonly ISubjectTimeTableRepository _subjectTimeTableRepository;

        public PaperService(IPaperRepository paperRepository, IExamRepository examRepository, ISubjectRepository subjectRepository, ILevelRepository levelRepository, IExamSubjectsRepository examSubjectsRepository, IStaffLevelRepository staffLevelRepository, IStaffSubjectRepository staffSubjectRepository, IStudentRepository studentRepository, IMailService mailService, IMapper mapper, ITimeTableRepository timeTableRepository, ISubjectTimeTableRepository subjectTimeTableRepository, IUriService uriService, ILevelTimeTableRepository levelTimeTableRepository)
        {
            _mapper = mapper;
            _uriService = uriService;
            _mailService = mailService;
            _examRepository = examRepository;
            _levelRepository = levelRepository;
            _paperRepository = paperRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _timeTableRepository = timeTableRepository;
            _staffLevelRepository = staffLevelRepository;
            _staffSubjectRepository = staffSubjectRepository;
            _examSubjectsRepository = examSubjectsRepository;
            _levelTimeTableRepository = levelTimeTableRepository;
            _subjectTimeTableRepository = subjectTimeTableRepository;
        }
        // Check for time less than DateTime.Now
        // Check if time clashes with another schedule
        public async Task<BaseResponse> Create(CreatePaperRequestModel model, Guid examId, Guid staffId, Guid timeTableId)
        {
            var exam = await _examRepository.GetAsync(x => x.Id == examId && x.IsEnded == false && x.IsDeleted == false);
            if (exam is null) { return new BaseResponse { Message = "Exam might have been ended", Success = false }; }

            var level = await _levelRepository.GetAsync(x => x.Name == model.LevelName);
            if (level is null) { return new BaseResponse { Message = "Level not found", Success = false }; }

            var levels = await _staffLevelRepository.GetAsync(x => x.StaffId == staffId && x.LevelId == level.Id);
            if (levels is null) { return new BaseResponse { Message = $"Sorry you have to be a staff of {level.Name} to create paper for them", Success = false }; }

            var subject = await _subjectRepository.GetAsync(x => x.Name == model.SubjectName);
            if (subject is null) { return new BaseResponse { Message = "Subject not found", Success = false }; }

            var levelTimetable = await _levelTimeTableRepository.GetAsync(x => x.TimeTableId == timeTableId && x.LevelId == level.Id);
            if (levelTimetable == null) { return new BaseResponse { Message = $"No time table has been created for {level.Name}", Success = false}; }  

            var timeTableExist = await _subjectTimeTableRepository.ExistsAsync(x => x.TimeTableId == levelTimetable.TimeTableId && x.SubjectId == subject.Id);
            if (timeTableExist) { return new BaseResponse { Message = $"{subject.Name} Subject Already Exist on TimeTable", Success = false }; }

            var subjects = await _staffSubjectRepository.GetAsync(x => x.StaffId == staffId && x.SubjectId == subject.Id);
            if (subjects is null) { return new BaseResponse { Message = $"Sorry you have to be a staff of {subject.Name} to create paper for them", Success = false }; }

            var paperExist = await _paperRepository.ExistsAsync(x => x.Subject.Name.Equals(model.SubjectName) && x.Exam.Term.Equals(exam.Term) && x.Level.Name.Equals(model.LevelName));
            if (paperExist) { return new BaseResponse { Message = $"{model.SubjectName} paper has already been created for {model.LevelName}", Success = false }; }


            var paper = _mapper.Map<Paper>(model);
            paper.LevelId = level.Id;
            paper.ExamId = examId;
            paper.SubjectId = subject.Id;
            var pap = await _paperRepository.CreateAsync(paper);
            var examSubject = new ExamSubjects { ExamId = pap.ExamId, SubjectId = pap.SubjectId, };
            await _examSubjectsRepository.CreateAsync(examSubject);

            var subjectTimeTable = _mapper.Map<SubjectTimeTable>(model);
            subjectTimeTable.TimeTableId = timeTableId;
            subjectTimeTable.SubjectId = subject.Id;
            await _subjectTimeTableRepository.CreateAsync(subjectTimeTable);
            await _paperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper Successfully created and added to time table", Success = true };
        }

        public async Task<Response<PaperDto>> GetPaperByIdAsync(Guid id)
        {
            var paper = await _paperRepository.GetByIdAsync(id);
            if (paper is null) { return new Response<PaperDto> { Message = "Paper not found", Success = false }; }

            var data = _mapper.Map<PaperDto>(paper);
            return new Response<PaperDto> { Message = $"{paper.Subject.Name} paper found successfully", Success = true, Data = data };
        }

        public async Task<BaseResponse> UpdatePaperAync(Guid Id, UpdatePaperRequestModel model)
        {
            var paper = await _paperRepository.GetAsync(Id);
            if (paper is null) { return new BaseResponse { Message = "Paper not found", Success = false }; }

            var level = await _levelRepository.GetAsync(model.LevelId);

            var subject = await _subjectRepository.GetAsync(x => x.Name == model.Subject);

            paper.SubjectId = subject == null ? paper.SubjectId : subject.Id;
            paper.LevelId = level == null ? paper.LevelId : level.Id;
            paper.Instruction = model.Instruction ?? paper.Instruction;
            paper.Duration = model.Duration;
            paper.StartDate = model.StartDate;
            await _paperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper Successfully Updated", Success = true };
        }

        public async Task<Results<PaperDto>> GetAllPapersByLevelIdAsync(Guid levelId, Guid examId)
        {
            var papers = await _paperRepository.GetAllPapersByLevelIdAsync(levelId, examId);
            if (papers.IsNullOrEmpty()) { return new Results<PaperDto> { Message = "No paper found", Success = false }; }

            var papersDtoData = _mapper.Map<List<PaperDto>>(papers);
            //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //var totalRecords = await _levelRepository.CountAsync();
            //var pagedReponse = PaginationHelper.CreatePagedReponse<PaperDto>(papersDtoData, validFilter, totalRecords, _uriService, route);
            return new Results<PaperDto> { Message = "paper successfully found", Success = true, Data = papersDtoData };
        }

        // Can the admin start the paper before the paper start date ???
        public async Task<BaseResponse> StartPaperAsync(Guid paperId)
        {
            var paper = await _paperRepository.GetPaperAsync(paperId);
            if (paper is null) { return new BaseResponse { Message = "Paper not found", Success = false }; }

            if (paper.PaperStatus == PaperStatus.Ended || paper.Exam.IsEnded) { return new BaseResponse { Success = false, Message = "Paper has already ended" }; }

            //if (paper.StartDate > DateTime.Now) { return new BaseResponse { Message = $"Exam Paper is scheduled for Date: {paper.StartDate.ToLongDateString()} Time: {paper.StartDate.ToLongTimeString()}", Success = false }; }

            var onGoingPapers = await _paperRepository.GetAllAsync(x => x.PaperStatus == PaperStatus.Started && x.Level == paper.Level && x.Subject.Department == paper.Subject.Department);
            if (!onGoingPapers.IsNullOrEmpty()) { return new BaseResponse { Message = $"A {paper.Subject.Department.Name} Paper for {paper.Level.Name} is current ongoing ", Success=false }; }

            var students = await _studentRepository.GetStudentsByLevelIdAsync(paper.LevelId);
            if (students.IsNullOrEmpty()) { return new BaseResponse { Message = "No Student found to take this paper", Success = false }; }

            string htmlContent = File.ReadAllText(@"..\Persistence\File\ExamPaperStartEmailTemplate.html");
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
            return new BaseResponse { Message = "Paper Started Successfully", Success = true };
        }

        // A mail should be sent for this method
        public async Task<BaseResponse> EndPaperAsync(Guid paperId)
        {
            var paper = await _paperRepository.GetAsync(x => x.Id == paperId);
            if (paper is null) { return new BaseResponse { Message = "Paper not found", Success = false }; }

            if (paper.PaperStatus != PaperStatus.Started)
            { return new BaseResponse { Message = "Exam paper has to start", Success = false }; }

            paper.PaperStatus = PaperStatus.Ended;
            await _paperRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Paper Ended Successfully", Success = true };
        }

        // A mail should be sent for this method
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