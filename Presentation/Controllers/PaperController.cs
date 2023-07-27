using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaperController : ControllerBase
    {
        private readonly IPaperService _paperService;

        public PaperController(IPaperService paperService)
        {
            _paperService = paperService;
        }
        [HttpPost("CreatePaper/{examId}/{staffId}")]
        public async Task<IActionResult> CreateAsync([FromForm]CreatePaperRequestModel model, Guid examId, Guid staffId)
        {
            var paper = await _paperService.Create(model, examId, staffId);
            if (paper.Success ==  true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
        [HttpGet("GetPaper/{id}")]
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
        [HttpPut("UpdatedPaper/{paperId}")]
        public async Task<IActionResult> UpadetAsync(Guid paperId, [FromForm]UpdatePaperRequestModel model)
        {
            var paper = await _paperService.UpdatePaperAync(paperId, model);
            if (paper.Success == true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
        [HttpPut("StartPaper/{paperId}")]
        public async Task<IActionResult> StartPaper(Guid paperId)
        {
            var paper = await _paperService.StartPaperAsync(paperId);
            if (paper.Success == true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
        [HttpPut("EndPaper/{paperId}")]
        public async Task<IActionResult> EndPaper(Guid paperId)
        {
            var paper = await _paperService.StartPaperAsync(paperId);
            if (paper.Success == true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
    }
}
