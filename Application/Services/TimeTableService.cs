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
using Application.Abstractions;

namespace Application.Services
{

    public class TimeTableService : ITimeTableService
    {
        private readonly IMapper _mapper;
        private readonly ILevelRepository _levelRepository;
        private readonly IPdfGeneratorService _pfGeneratorService;
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly ILevelTimeTableRepository _levelTimeTableRepository;
        private readonly ISubjectTimeTableRepository _subjectTimeTableRepository;

        public TimeTableService(ITimeTableRepository timeTableRepository, ILevelRepository levelRepository, ILevelTimeTableRepository levelTimeTableRepository, IMapper mapper, ISubjectTimeTableRepository subjectTimeTableRepository, IPdfGeneratorService pfGeneratorService)
        {
            _mapper = mapper;
            _levelRepository = levelRepository;
            _pfGeneratorService = pfGeneratorService;
            _timeTableRepository = timeTableRepository;
            _levelTimeTableRepository = levelTimeTableRepository;
            _subjectTimeTableRepository = subjectTimeTableRepository;
        }

        public async Task<BaseResponse> CreateTimeTableAsync(CreateTimeTableRequestModel model, Guid levelId)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == levelId);

            var exist = await _levelTimeTableRepository
                .ExistsAsync(x => x.Level.Name.Equals(level.Name) && x.TimeTable.Seasion.Equals(model.Seasion) && x.TimeTable.Term.Equals(model.Term));
            if (exist) { return new BaseResponse { Message = $"Time Table for {level.Name} {model.Term} {model.Seasion} already exist" }; }

            var timeTable = _mapper.Map<TimeTable>(model);
            await _timeTableRepository.CreateAsync(timeTable);
            var levelTimeTable = new LevelTimeTable
            {
                LevelId = levelId,
                TimeTableId = timeTable.Id,
            };
            await _levelTimeTableRepository.CreateAsync(levelTimeTable);
            await _timeTableRepository.SaveChangesAsync();
            return new BaseResponse { Message = "Time Table Successfully created", Success = true };
        }
        public async Task<BaseResponse> DownloadTimeTable(Guid levelId, Term term, string seasion)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == levelId);
            if (level == null) { return new Response<LevelTimeTableDto> { Message = "Level not found", Success = false }; }

            var timeTable = await _levelTimeTableRepository.GetAsync(levelId, term, seasion);
            if (timeTable is null) { return new Response<LevelTimeTableDto> { Message = string.Empty, Success = false }; }

            var subjectTmeTable = await _subjectTimeTableRepository.GetSubjectTimeTableAsync(timeTable.TimeTableId);
            var subjectTmeTableData = _mapper.Map<IEnumerable<SubjectTimeTableDto>>(subjectTmeTable);
            string fileName = Guid.NewGuid().ToString() + ".pdf";
            List<string> columns = new List<string> { "Subject", "Date", "Time", "Duration", "Location" };
            var isDownloaded = await _pfGeneratorService.GeneratePdf(fileName, $"Time Table {timeTable.TimeTable.Seasion} {(int)timeTable.TimeTable.Term}st Term {level.Name}", subjectTmeTableData, columns);
            return new BaseResponse { Message = isDownloaded ? "Successfully download" : "Something went wrong", Success = isDownloaded };
        }
    }
}
