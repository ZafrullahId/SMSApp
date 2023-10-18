using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.ResponseModel;
using Application.Filter;
using Application.Helpers;
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
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly ILevelRepository _levelRepository;
        private readonly ILevelTimeTableRepository _levelTimeTableRepository;
        private readonly ISubjectTimeTableRepository _subjectTimeTableRepository;

        public LevelTimeTableService(ILevelTimeTableRepository levelTimeTableRepository, ISubjectTimeTableRepository subjectTimeTableRepository, IMapper mapper, ILevelRepository levelRepository, IUriService uriService)
        {
            _levelTimeTableRepository = levelTimeTableRepository;
            _subjectTimeTableRepository = subjectTimeTableRepository;
            _mapper = mapper;
            _levelRepository = levelRepository;
            _uriService = uriService;
        }
        public async Task<Response<LevelTimeTableDto>> GetLevelTimeTableAsync(Guid levelId, Term term, string seasion)
        {
            var level = await _levelRepository.GetAsync(x => x.Id == levelId);
            if (level == null) { return new Response<LevelTimeTableDto> { Message = "Level not found", Success = false }; }

            var timeTable = await _levelTimeTableRepository.GetAsync(levelId,term,seasion);
            if (timeTable is null) { return new Response<LevelTimeTableDto> { Message = string.Empty, Success = false }; }

            var subjectTmeTable = await _subjectTimeTableRepository.GetSubjectTimeTableAsync(timeTable.TimeTableId);
            var subjectTmeTableData = _mapper.Map<IEnumerable<SubjectTimeTableDto>>(subjectTmeTable);
            var levelTimeTableData = _mapper.Map<LevelTimeTableDto>(timeTable);
            levelTimeTableData.TimeTableSubject = subjectTmeTableData;

            //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            //var totalRecords = await _levelRepository.CountAsync();
            //var pagedReponse = PaginationHelper.CreatePagedReponse<SubjectTimeTableDto>(levelTimeTableData.TimeTableSubject.ToList(), validFilter, totalRecords, _uriService, route);

            return new Response<LevelTimeTableDto> { Message = $"Time Table for {level.Name} {term} {seasion} successfully retrieved", Success = true, Data = levelTimeTableData };
        }
    }
}
