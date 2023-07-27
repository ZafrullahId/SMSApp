using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
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
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly ISubjectTimeTableRepository _subjectTimeTableRepository;

        public SubjectTimeTableService(ISubjectTimeTableRepository subjectTimeTableRepository, ITimeTableRepository timeTableRepository, IMapper mapper, ISubjectRepository subjectRepository)
        {
            _subjectTimeTableRepository = subjectTimeTableRepository;
            _timeTableRepository = timeTableRepository;
            _mapper = mapper;
            _subjectRepository = subjectRepository;
        }
        public async Task<BaseResponse> CreateTimeTableSubjectAsync(CreateSubjectTimeTableRequestModel model, Guid timeTableId)
        {
            var timeTable = await _timeTableRepository.GetAsync(x => x.Id == timeTableId);
            if (timeTable == null) { return new BaseResponse { Message = "Time Table not found", Success = false }; }

            var subject = await _subjectRepository.GetAsync(x => x.Name == model.SubjectName);
            if (subject == null) { return new BaseResponse { Message = "Subject not found", Success = false }; }

            var exist = await _subjectTimeTableRepository.ExistsAsync(x => x.TimeTable == timeTable && x.Subject.Name == model.SubjectName);
            if (exist) { return new BaseResponse { Message = "Already Exist", Success = false }; }

            var subjectTimeTable = _mapper.Map<SubjectTimeTable>(model);
            subjectTimeTable.TimeTableId = timeTableId;
            subjectTimeTable.SubjectId = subject.Id;
            await _subjectTimeTableRepository.CreateAsync(subjectTimeTable);
            await _subjectTimeTableRepository.SaveChangesAsync();
            return new BaseResponse { Message = $"Subject {model.SubjectName} successfully added to time table", Success = true }; 
        }

        public async Task<SubjectsTimeTableResponseModel> GetTimeTableSubjectsAsync(Guid timeTableId)
        {
            var timeTable = await _timeTableRepository.GetAsync(x => x.Id.Equals(timeTableId));
            if (timeTable == null) { return new SubjectsTimeTableResponseModel { Message = "Time Table Subjects not retrieved", Success = false }; }

            var subjectsTimeTable = await _subjectTimeTableRepository.GetSubjectTimeTableAsync(timeTableId);
            var subjectTimeTableDtoData = _mapper.Map<IEnumerable<SubjectTimeTableDto>>(subjectsTimeTable);
            return new SubjectsTimeTableResponseModel { Message = "Time Table Subjects Successfully retrieved", Success = true, Data = subjectTimeTableDtoData };
        }

        public async Task<SubjectsTimeTableResponseModel> GeTimeTableByYearAndTerm(int year, Term term)
        { 
            var timeTable = await _subjectTimeTableRepository.GetSubjectTimeTableAsync(year, term);
            if (!timeTable.Any()) { return new SubjectsTimeTableResponseModel { Message = $"No time table found for {year} {term}", Success = false }; }

            var subjectTimeTableDtoData = _mapper.Map<IEnumerable<SubjectTimeTableDto>>(timeTable);
            return new SubjectsTimeTableResponseModel { Message = $"All Time Tables Subjects Successfully retrieved for {term} {year}", Success = true, Data = subjectTimeTableDtoData };
        }


    }
}
