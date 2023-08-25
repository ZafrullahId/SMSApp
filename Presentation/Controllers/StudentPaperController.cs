using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Auth;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPaperController : ControllerBase
    {
        private readonly IStudentPaperService _studentPaperService;

        public StudentPaperController(IStudentPaperService studentPaperService)
        {
            _studentPaperService = studentPaperService;
        }

        [HttpPost("CreateStudentPapers/{paperId}")]
        public async Task<IActionResult> CreateAsync(Guid paperId)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
            var userId = JWTAuthenticationManager.GetLoginId(token);
            var studentPaper = await _studentPaperService.CreateStudentPaperAsync(userId, paperId);
            return studentPaper.Success ? Ok(studentPaper) : BadRequest(studentPaper);
        }
        [HttpGet("GetStudentPaper/{studentId}/{paperId}")]
        public async Task<IActionResult> GetStudentPaper(Guid studentId, Guid paperId)
        {
            var studentPaper = await _studentPaperService.GetStudentPaper(studentId, paperId);
            return studentPaper.Success ? Ok(studentPaper) : BadRequest(studentPaper);
        }
        [HttpGet("GetAllStudentPaper/{paperId}")]
        public async Task<IActionResult> GetAllStudentPaper(Guid paperId)
        {
            var studentsPapers = await _studentPaperService.GetStudentsPapersAsync(paperId);
            return studentsPapers.Success ? Ok(studentsPapers) : BadRequest(studentsPapers);
        }
        [HttpGet("ReleaseResult/paperId"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReleasePaperResults(Guid paperId)
        {
            var result = await _studentPaperService.ReleasePaperResults(paperId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
