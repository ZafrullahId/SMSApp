using AutoMapper;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.ResponseModel;

namespace Application.Services
{
    public class ExamSubjectsServices : IExamSubjectsServices
    {
        private readonly IExamRepository _examRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly IPaperRepository _paperRepository;
        private readonly IMapper _mapper;

        public ExamSubjectsServices(ILevelRepository levelRepository, IExamRepository examRepository, IPaperRepository paperRepository, IMapper mapper)
        {
            _examRepository = examRepository;
            _levelRepository = levelRepository;
            _paperRepository = paperRepository;
            _mapper = mapper;
        }
        public async Task<ExamSubjectsResponseModel> GetExamSubjectsByLevelIdAsync(Guid examId, Guid levelId)
        {
            var exam = await _examRepository.GetAsync(examId);
            if (exam is null) { return new ExamSubjectsResponseModel { Message = "Exam not found", Success = false }; }

            var level = await _levelRepository.GetAsync(levelId);
            if (level is null) { return new ExamSubjectsResponseModel { Message = "Level not found", Success = false }; }

            var papers = await _paperRepository.GetAllPapersByLevelIdAsync(level.Id, exam.Id);
            if (papers.Count is 0) { return new ExamSubjectsResponseModel { Message = $"No Pappers found for {level.Name} {exam.Term} {exam.Year}", Success = false }; }

            var examDtoData = _mapper.Map<ExamDto>(exam);
            var levelDtoData = _mapper.Map<LevelDto>(level);
            var subjectDtoDatas = _mapper.Map<List<SubjectDto>>(papers);
            return new ExamSubjectsResponseModel
            {
                Message = $"Subject for {level.Name} {exam.Term} {exam.Year} successfully retrieved",
                Success = true,
                Data = new ExamSubjectsDto { ExamDto = examDtoData, LevelDto = levelDtoData, SubjectDtos = subjectDtoDatas }
            };
        }
    }
}