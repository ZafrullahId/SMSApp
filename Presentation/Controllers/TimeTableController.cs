using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Domain.Entity;
using Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("CreateTimeTable/{levelId}")]
        public async Task<IActionResult> CreateTimeTableAsync([FromForm]CreateTimeTableRequestModel model, Guid levelId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var timeTable = await _timeTableService.CreateTimeTableAsync(model, levelId: levelId);
            if (timeTable.Success) return Ok(timeTable);
            return BadRequest(timeTable);
        
        }
        //[HttpPost("CreateTimeTableSubject/{timeTableId}")]
        //public async Task<IActionResult> CreateTimeTableSubjectAsync([FromForm] CreateSubjectTimeTableRequestModel model, Guid timeTableId)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    var timeTable = await _subjectTimeTableService.CreateTimeTableSubjectAsync(model, timeTableId);
        //    if (timeTable.Success) return Ok(timeTable);
        //    return BadRequest(timeTable);
        //}
        [HttpGet("GetTimeTableSubjects/{timeTableId}"), Authorize]
        public async Task<IActionResult> GetTimeTableSubjectsAsync(Guid timeTableId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var timeTable = await _subjectTimeTableService.GetTimeTableSubjectsAsync(timeTableId);
            if (timeTable.Success) return Ok(timeTable);
            return BadRequest(timeTable);
        }
        [HttpGet("GeTimeTableByYearAndTerm/{seasion}/{term}")]
        public async Task<IActionResult> GeTimeTableByYearAndTermAsync(string seasion, Term term)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var timeTable = await _subjectTimeTableService.GeTimeTableByYearAndTerm(seasion, term);
            if (timeTable.Success) return Ok(timeTable);
            return BadRequest(timeTable);
        }
        [HttpGet("GetLevelTimeTable/{levelId}/{term}/{seasion}")]
        public async Task<IActionResult> GetLevelTimeTableAsync(Guid levelId, Term term, string seasion)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var timeTable = await _levelTimeTableService.GetLevelTimeTableAsync(levelId, term, seasion);
            if (timeTable.Success) return Ok(timeTable);
            return BadRequest(timeTable);
        }
    }
}
