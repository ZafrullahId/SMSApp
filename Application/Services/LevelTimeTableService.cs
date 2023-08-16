using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Dtos.ResponseModel;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LevelTimeTableService : ILevelTimeTableService
    {
        private readonly ILevelTimeTableRepository _levelTimeTableRepository;
        private readonly ILevelRepository _levelRepository;
        private readonly ISubjectTimeTableRepository _subjectTimeTableRepository;
        private readonly IMapper _mapper;

        public LevelTimeTableService(ILevelTimeTableRepository levelTimeTableRepository, ISubjectTimeTableRepository subjectTimeTableRepository, IMapper mapper, ILevelRepository levelRepository)
        {
            _levelTimeTableRepository = levelTimeTableRepository;
            _subjectTimeTableRepository = subjectTimeTableRepository;
            _mapper = mapper;
            _levelRepository = levelRepository;
        }
        public async Task<LevelTimeTableResponseModel> GetLevelTimeTableAsync(Guid levelId, Term term, string seasion)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == levelId);
            if (level == null) { return new LevelTimeTableResponseModel { Message = "Level not found", Success = false }; }

            var timeTable = await _levelTimeTableRepository.GetAsync(levelId,term,seasion);
            if (timeTable is null) { return new LevelTimeTableResponseModel { Message = string.Empty, Success = false }; }

            var subjectTmeTable = await _subjectTimeTableRepository.GetSubjectTimeTableAsync(timeTable.TimeTableId);
            var subjectTmeTableData = _mapper.Map<IEnumerable<SubjectTimeTableDto>>(subjectTmeTable);
            var levelTimeTableData = _mapper.Map<LevelTimeTableDto>(timeTable);
            levelTimeTableData.TimeTableSubject = subjectTmeTableData;

            return new LevelTimeTableResponseModel { Message = $"Time Table for {level.Name} {term} {seasion} successfully retrieved", Success = true, Data = levelTimeTableData };
        }
    }
}
