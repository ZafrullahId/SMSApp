using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService, IOptions<JwtBearerOptions> jwtBearerOptions)
        {
            _examService = examService;
        }
        [HttpPost("CreateExam"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CreateAsync([FromForm]CreateExamRequestModel model)
        {
            var exam = await _examService.CreateExamAsync(model);
            return exam.Success ? Ok(exam) : BadRequest(exam);
        }
        [HttpGet("GetAllExams"), Authorize]
        public async Task<IActionResult> GetAllExamAsync()
        {
            var exams = await _examService.GetAllExamsAsync();
            return exams.Success ? Ok(exams) : BadRequest(exams);
        }
        [HttpGet("GetAllOngoingExams"), Authorize]
        public async Task<IActionResult> GetOngoingExamsAsync()
        {
            var exams = await _examService.GetAllOngoingExamsAsync();
            return exams.Success ? Ok(exams) : BadRequest(exams);
        }
        [HttpPut("UpdateExamStatus/{id}"), Authorize]
        public async Task<IActionResult> ChangeExamStatusAsync(Guid id)
        {
            var exam = await _examService.ChangeExamStateAsync(id);
            return exam.Success ? BadRequest(exam) : (IActionResult)BadRequest(exam);
        }
    }
}
