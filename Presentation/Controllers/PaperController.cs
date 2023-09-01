using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Application.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Persistence.Auth;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaperController : ControllerBase
    {
        private readonly IPaperService _paperService;
        private readonly IOptionService _optionService;
        public PaperController(IPaperService paperService, IOptionService optionService)
        {
            _paperService = paperService;
            _optionService = optionService;
        }

        [HttpPost("{examId}/{staffId}/{timeTableId}"), Authorize(Roles = "Teacher")]
        [OpenApiOperation("Create paper by examId ,staffid and timetableId ", "")]
        public async Task<IActionResult> CreateAsync([FromForm]CreatePaperRequestModel model, Guid examId, Guid staffId, Guid timeTableId)
        {
            var paper = await _paperService.Create(model, examId, staffId, timeTableId);
            return paper.Success ? Ok(paper) : BadRequest(paper);
        }

        [HttpGet("{id}"), Authorize]
        [OpenApiOperation("Gets paper by Id", "")]
        public async Task<IActionResult> GetPaperByIdAsync(Guid id)
        {
            var paper = await _paperService.GetPaperByIdAsync(id);
            return paper.Success ? Ok(paper) : BadRequest(paper);
        }

        [HttpGet("{examId}/{levelId}/papers")]
        [OpenApiOperation("Gets all papers by examId and levelId ", "")]
        public async Task<IActionResult> GetAllPaperAsync([FromQuery]PaginationFilter filter,Guid examId, Guid levelId)
        {
            var route = Request.Path.Value;
            var papers = await _paperService.GetAllPapersByLevelIdAsync(filter, route, levelId, examId);
            return papers.Success ? Ok(papers) : BadRequest(papers);
        }

        [HttpPut("{paperId}"), Authorize(Roles = "Teacher")]
        [OpenApiOperation("Update Paper by id"," ")]
        public async Task<IActionResult> UpadetAsync(Guid paperId, [FromForm]UpdatePaperRequestModel model)
        {
            var paper = await _paperService.UpdatePaperAync(paperId, model);
            return paper.Success ? Ok(paper) : BadRequest(paper);
        }

        [HttpPut("{paperId}/startstatus"), Authorize(Roles = "Teacher,Admin")]
        [OpenApiOperation("Start a paper","")]
        public async Task<IActionResult> StartPaper(Guid paperId)
        {
            var paper = await _paperService.StartPaperAsync(paperId);
            return paper.Success ? Ok(paper) : BadRequest(paper);
        }

        [HttpPut("{paperId}/endstatus"), Authorize(Roles = "Teacher,Admin")]
        [OpenApiOperation("End a Paper  ", "")]
        public async Task<IActionResult> EndPaper(Guid paperId)
        {
            var paper = await _paperService.EndPaperAsync(paperId);
            return paper.Success ? Ok(paper) : BadRequest(paper);
        }

        [HttpPut("{paperId}/terminate"), Authorize(Roles = "Teacher,Admin")]
        [OpenApiOperation("Terminate paper ")]
        public async Task<IActionResult> TerminatePaper(Guid paperId)
        {
            var paper = await _paperService.TerminatePaperAsync(paperId);
            return paper.Success ? Ok(paper) : BadRequest(paper);
        }

        [HttpPut("SubmitPaper"), Authorize]
        [OpenApiOperation("Submit paper")]
        public async Task<IActionResult> SubmitAsync([FromBody] List<string> selectedOptions)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
            var studentUserId = JWTAuthenticationManager.GetLoginId(token);
            var paper = await _optionService.SubmitPaperAsync(selectedOptions, studentUserId);
            return paper.Success ? Ok(paper) : BadRequest(paper);
        }
    }
}
