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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SubjectTimeTableService : ISubjectTimeTableService
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly ILevelRepository _levelRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly ILevelTimeTableRepository _levelTimeTableRepository;
        private readonly ISubjectTimeTableRepository _subjectTimeTableRepository;

        public SubjectTimeTableService(ISubjectTimeTableRepository subjectTimeTableRepository, ITimeTableRepository timeTableRepository, IMapper mapper, ISubjectRepository subjectRepository, IUriService uriService, ILevelRepository levelRepository, ILevelTimeTableRepository levelTimeTableRepository)
        {
            _mapper = mapper;
            _uriService = uriService;
            _levelRepository = levelRepository;
            _subjectRepository = subjectRepository;
            _timeTableRepository = timeTableRepository;
            _levelTimeTableRepository = levelTimeTableRepository;
            _subjectTimeTableRepository = subjectTimeTableRepository;
        }
        //public async Task<BaseResponse> CreateTimeTableSubjectAsync(CreateSubjectTimeTableRequestModel model, Guid timeTableId)
        //{
        //    var timeTable = await _timeTableRepository.GetAsync(x => x.Id == timeTableId);
        //    if (timeTable == null) { return new BaseResponse { Message = "Time Table not found", Success = false }; }

        //    var subject = await _subjectRepository.GetAsync(x => x.Name == model.SubjectName);
        //    if (subject == null) { return new BaseResponse { Message = "Subject not found", Success = false }; }

        //    var exist = await _subjectTimeTableRepository.ExistsAsync(x => x.TimeTable == timeTable && x.Subject.Name == model.SubjectName);
        //    if (exist) { return new BaseResponse { Message = "Already Exist", Success = false }; }

        //    var subjectTimeTable = _mapper.Map<SubjectTimeTable>(model);
        //    subjectTimeTable.TimeTableId = timeTableId;
        //    subjectTimeTable.SubjectId = subject.Id;
        //    await _subjectTimeTableRepository.CreateAsync(subjectTimeTable);
        //    await _subjectTimeTableRepository.SaveChangesAsync();
        //    return new BaseResponse { Message = $"Subject {model.SubjectName} successfully added to time table", Success = true }; 
        //}

        public async Task<Responses<SubjectTimeTableDto>> GetTimeTableSubjectsAsync(PaginationFilter filter, string route, Guid timeTableId)
        {
            var timeTable = await _timeTableRepository.GetAsync(x => x.Id.Equals(timeTableId));
            if (timeTable == null) { return new Responses<SubjectTimeTableDto> { Message = "Time Table Subjects not retrieved", Success = false }; }

            var subjectsTimeTable = await _subjectTimeTableRepository.GetSubjectTimeTableAsync(timeTableId, filter.PageNumber, filter.PageSize);
            var subjectTimeTableDtoData = _mapper.Map<List<SubjectTimeTableDto>>(subjectsTimeTable);
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalRecords = await _subjectTimeTableRepository.CountAsync(x => x.TimeTableId == timeTableId);
            var pagedReponse = PaginationHelper.CreatePagedReponse<SubjectTimeTableDto>(subjectTimeTableDtoData, validFilter, totalRecords, _uriService, route);
            return new Responses<SubjectTimeTableDto> { Message = "Time Table Subjects Successfully retrieved", Success = true, Data = pagedReponse };
        }

        public async Task<Results<IEnumerable<SubjectTimeTableDto>>> GetTimeTableByYearAndTerm(string seasion, Term term)
        {
            List<IEnumerable<SubjectTimeTableDto>> subjectTimeTableDtos = new();
            var levels = await _levelRepository.GetAllAsync();
            foreach (var level in levels)
            {
                var timeTable = await _levelTimeTableRepository.GetAsync(x => x.LevelId == level.Id && x.TimeTable.Seasion == seasion && x.TimeTable.Term == term);
                if (timeTable is not null)
                {
                    var subjectTimeTable = await _subjectTimeTableRepository.GetSubjectTimeTableAsync(timeTable.TimeTableId);
                    var subjectTimeTableDtoData = _mapper.Map<IEnumerable<SubjectTimeTableDto>>(subjectTimeTable);
                    subjectTimeTableDtos.Add(subjectTimeTableDtoData);

                }

            }

            return new Results<IEnumerable<SubjectTimeTableDto>> { Message = $"All Time Tables Subjects Successfully retrieved for {term} {seasion}", Success = true, Data = subjectTimeTableDtos };
        }


    }
}
