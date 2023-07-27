using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    public class TimeTableService : ITimeTableService
    {
        private readonly IMapper _mapper;
        private readonly ILevelRepository _levelRepository;
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly ILevelTimeTableRepository _levelTimeTableRepository;

        public TimeTableService(ITimeTableRepository timeTableRepository, ILevelRepository levelRepository, ILevelTimeTableRepository levelTimeTableRepository, IMapper mapper)
        {
            _mapper = mapper;
            _levelRepository = levelRepository;
            _timeTableRepository = timeTableRepository;
            _levelTimeTableRepository = levelTimeTableRepository;
        }

        public async Task<BaseResponse> CreateTimeTableAsync(CreateTimeTableRequestModel model, Guid levelId)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == levelId);

            var exist = await _levelTimeTableRepository
                .ExistsAsync(x => x.Level.Name.Equals(level.Name) && x.TimeTable.Year.Equals(model.Year) && x.TimeTable.Term.Equals(model.Term));
            if (exist) { return new BaseResponse { Message = $"Time Table for {level.Name} {model.Term} {model.Year} already exist" }; }

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
    }
}
