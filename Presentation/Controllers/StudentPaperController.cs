using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
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
            if (studentPaper.Success ==  true)
            {
                return Ok(studentPaper);
            }
            return BadRequest(studentPaper);
        }
        [HttpGet("GetStudentPaper/{studentId}/{paperId}")]
        public async Task<IActionResult> GetStudentPaper(Guid studentId, Guid paperId)
        {
            var studentPaper = await _studentPaperService.GetStudentPaper(studentId, paperId);
            if (studentPaper.Success == true)
            {
                return Ok(studentPaper);
            }
            return BadRequest(studentPaper);
        }
        [HttpGet("GetAllStudentPaper/{studentId}/{paperId}")]
        public async Task<IActionResult> GetAllStudentPaper(Guid subjectId, Guid levelId, Guid examId)
        {
            var studentsPapers = await _studentPaperService.GetStudentPapersBySubjectIdAsync(subjectId, levelId, examId);
            if (studentsPapers.Success == true)
            {
                return Ok(studentsPapers);
            }
            return BadRequest(studentsPapers);
        }
    }
}
