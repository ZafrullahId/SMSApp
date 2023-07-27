using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;
namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;
        public ExamService(IExamRepository examRepository, IMapper mapper)
        {
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> CreateExamAsync(CreateExamRequestModel model)
        {
            var exam = _mapper.Map<Exam>(model);

            await _examRepository.CreateAsync(exam);
            await _examRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Exam Successfully created", Success = true };
        }
        public async Task<ExamsResponseModel> GetAllExamsAsync()
        {
            var exams = await _examRepository.GetAllAsync();
            if (exams.IsNullOrEmpty()) { return new ExamsResponseModel { Message = "No Exam written yet", Success = false }; }

            var data = _mapper.Map<List<ExamDto>>(exams);
            return new ExamsResponseModel { Message = "Exams retrived successfully", Success = true, Data = data };
        }
        public async Task<ExamsResponseModel> GetAllOngoingExamsAsync()
        {
            var exams = await _examRepository.GetAllOngoingExamsAsync();
            if (exams.IsNullOrEmpty()) { return new ExamsResponseModel { Message = "No Ongoing Exam", Success = false }; }

            var data = _mapper.Map<List<ExamDto>>(exams);
            return new ExamsResponseModel { Message = "Ongoing Exams retrived successfully", Success = true, Data = data };
        }
        public async Task<BaseResponse> ChangeExamStateAsync(Guid id)
        {
            var exam = await _examRepository.GetAsync(id);
            if (exam is null) { return new BaseResponse { Message = "Exam not found", Success = false }; }

            exam.IsEnded = exam.IsEnded != true;
            await _examRepository.UpdateAsync(exam);
            return new BaseResponse { Message = "Exam successfully Updated", Success = true };
        }
    }
}