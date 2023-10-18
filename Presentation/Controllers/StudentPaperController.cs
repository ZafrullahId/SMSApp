using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Application.Filter;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
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

        [HttpPost("{paperId}")]
        [OpenApiOperation("Create Student Paper by paperId", "")]
        public async Task<IActionResult> CreateAsync(Guid paperId)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
            var userId = JWTAuthenticationManager.GetLoginId(token);
            var studentPaper = await _studentPaperService.CreateStudentPaperAsync(userId, paperId);
            return studentPaper.Success ? Ok(studentPaper) : BadRequest(studentPaper);
        }
        [HttpGet("{studentId}/{paperId}")]
        [OpenApiOperation("Get Student Paper by StudentId and PaperId", "")]
        public async Task<IActionResult> GetStudentPaper(Guid studentId, Guid paperId)
        {
            var studentPaper = await _studentPaperService.GetStudentPaper(studentId, paperId);
            return studentPaper.Success ? Ok(studentPaper) : BadRequest(studentPaper);
        }
        [HttpGet("{paperId}/studentpapers")]
        [OpenApiOperation("Get All Student Paper by PaperId ", "")]
        public async Task<IActionResult> GetAllStudentPaper(Guid paperId)
        {
            var studentsPapers = await _studentPaperService.GetStudentsPapersAsync(paperId);
            return studentsPapers.Success ? Ok(studentsPapers) : BadRequest(studentsPapers);
        }
        [HttpGet("{paperId}/release"), Authorize(Roles = "Admin")]
        [OpenApiOperation("Release student result by paperId", "")]
        public async Task<IActionResult> ReleasePaperResults(Guid paperId)
        {
            var result = await _studentPaperService.ReleasePaperResults(paperId);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
