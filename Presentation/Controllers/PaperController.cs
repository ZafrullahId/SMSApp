using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("CreatePaper/{examId}/{staffId}/{timeTableId}"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CreateAsync([FromForm]CreatePaperRequestModel model, Guid examId, Guid staffId, Guid timeTableId)
        {
            var paper = await _paperService.Create(model, examId, staffId, timeTableId);
            if (paper.Success ==  true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
        [HttpGet("GetPaper/{id}"), Authorize]
        public async Task<IActionResult> GetPaperByIdAsync(Guid id)
        {
            var paper = await _paperService.GetPaperByIdAsync(id);
            if (paper.Success == true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
        [HttpGet("GetAllPaper/{examId}/{levelId}")]
        public async Task<IActionResult> GetAllPaperAsync(Guid examId, Guid levelId)
        {
            var papers = await _paperService.GetAllPapersByLevelIdAsync(levelId, examId);
            if (papers.Success == true)
            {
                return Ok(papers);
            }
            return BadRequest(papers);
        }
        [HttpPut("UpdatedPaper/{paperId}"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> UpadetAsync(Guid paperId, [FromForm]UpdatePaperRequestModel model)
        {
            var paper = await _paperService.UpdatePaperAync(paperId, model);
            if (paper.Success == true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
        [HttpPut("StartPaper/{paperId}"), Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> StartPaper(Guid paperId)
        {
            var paper = await _paperService.StartPaperAsync(paperId);
            if (paper.Success == true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
        [HttpPut("EndPaper/{paperId}"), Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> EndPaper(Guid paperId)
        {
            var paper = await _paperService.EndPaperAsync(paperId);
            if (paper.Success == true) { return Ok(paper); }
            return BadRequest(paper);
        }
        [HttpPut("TerminatePaper/{paperId}"), Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> TerminatePaper(Guid paperId)
        {
            var paper = await _paperService.TerminatePaperAsync(paperId);
            if (paper.Success == true) { return Ok(paper); }
            return BadRequest(paper);
        }
        [HttpPut("SubmitPaper"), Authorize]
        public async Task<IActionResult> SubmitAsync([FromBody] List<string> selectedOptions)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
            var studentUserId = JWTAuthenticationManager.GetLoginId(token);
            var paper = await _optionService.SubmitPaperAsync(selectedOptions, studentUserId);
            if (paper.Success == true) { return Ok(paper); }
            return BadRequest(paper);
        }
    }
}
