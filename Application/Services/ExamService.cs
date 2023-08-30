using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using Application.Filter;
using Application.Helpers;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using Twilio.Http;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IMapper _mapper;
        private readonly IUriService uriService;
        private readonly IExamRepository _examRepository;
        public ExamService(IExamRepository examRepository, IMapper mapper, IUriService uriService)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            this.uriService = uriService;
        }

        public async Task<BaseResponse> CreateExamAsync(CreateExamRequestModel model)
        {
            var exam = _mapper.Map<Exam>(model);

            await _examRepository.CreateAsync(exam);
            await _examRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Exam Successfully created", Success = true };
        }
        public async Task<Responses<ExamDto>> GetAllExamsAsync(PaginationFilter filter, string route)
        {
            var exams = await _examRepository.GetFilterAsync(filter.PageNumber, filter.PageSize);
            if (exams.IsNullOrEmpty()) { return new Responses<ExamDto> { Message = "No Exam written yet", Success = false }; }

            var pagedData = _mapper.Map<List<ExamDto>>(exams);
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = await _examRepository.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<ExamDto>(pagedData, validFilter, totalRecords, uriService, route);

            return new Responses<ExamDto> { Message = "Exams retrived successfully", Success = true, Data = pagedReponse };
        }
        public async Task<Responses<ExamDto>> GetAllOngoingExamsAsync(PaginationFilter filter, string route)
        {
            var exams = await _examRepository.GetFilterAsync(filter.PageNumber, filter.PageSize, x => !x.IsEnded);
            if (exams.IsNullOrEmpty()) { return new Responses<ExamDto> { Message = "No Ongoing Exam", Success = false }; }

            var pagedData = _mapper.Map<List<ExamDto>>(exams);
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = await _examRepository.CountAsync(x => !x.IsEnded);
            var pagedReponse = PaginationHelper.CreatePagedReponse<ExamDto>(pagedData, validFilter, totalRecords, uriService, route);
            return new Responses<ExamDto> { Message = "Ongoing Exams retrived successfully", Success = true, Data = pagedReponse };
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