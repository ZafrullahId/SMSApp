using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Application.Filter;
using Domain.Entity;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
        private readonly ITimeTableService _timeTableService;
        private readonly ISubjectTimeTableService _subjectTimeTableService;
        private readonly ILevelTimeTableService _levelTimeTableService;

        public TimeTableController(ITimeTableService timeTableService, ISubjectTimeTableService subjectTimeTableService, ILevelTimeTableService levelTimeTableService)
        {
            _timeTableService = timeTableService;
            _subjectTimeTableService = subjectTimeTableService;
            _levelTimeTableService = levelTimeTableService;
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("{levelId}")]
        [OpenApiOperation("Create TimeTable By LevelId.", "")]
        public async Task<IActionResult> CreateTimeTableAsync([FromForm]CreateTimeTableRequestModel model, Guid levelId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var timeTable = await _timeTableService.CreateTimeTableAsync(model, levelId: levelId);
            if (timeTable.Success) return Ok(timeTable);
            return BadRequest(timeTable);
        
        }
        [HttpGet("{timeTableId}/timetablesubjects"), Authorize]
        [OpenApiOperation("Get TimeTable subjects by TimeTableId.", "")]
        public async Task<IActionResult> GetTimeTableSubjectsAsync(Guid timeTableId)
        {
            var timeTable = await _subjectTimeTableService.GetTimeTableSubjectsAsync(timeTableId);
            if (timeTable.Success) return Ok(timeTable);
            return BadRequest(timeTable);
        }
        [HttpGet("{seasion}/{term}")]
        [OpenApiOperation("GeTimeTableByYearAndTerm By Season And Term.", "")]
        public async Task<IActionResult> GeTimeTableByYearAndTermAsync(string seasion, Term term)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var timeTable = await _subjectTimeTableService.GetTimeTableByYearAndTerm(System.Net.WebUtility.UrlDecode(seasion), term);
            if (timeTable.Success) return Ok(timeTable);
            return BadRequest(timeTable);
        }
        [HttpGet("{levelId}/{term}/{seasion}")]
        [OpenApiOperation("Get a level TimeTable By LevelId,Term and Season ", "")]
        public async Task<IActionResult> GetLevelTimeTableAsync(Guid levelId, Term term, string seasion)
        {
            var timeTable = await _levelTimeTableService.GetLevelTimeTableAsync(levelId, term, System.Net.WebUtility.UrlDecode(seasion));
            if (timeTable.Success) return Ok(timeTable);
            return BadRequest(timeTable);
        }
    }
}
