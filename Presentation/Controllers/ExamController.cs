using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Application.Filter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSwag.Annotations;

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
        [HttpPost]
        [OpenApiOperation("Create Exam .", "")]
        public async Task<IActionResult> CreateAsync([FromForm]CreateExamRequestModel model)
        {
            var exam = await _examService.CreateExamAsync(model);
            return exam.Success ? Ok(exam) : BadRequest(exam);
        }
        [HttpGet]
        [OpenApiOperation("Get all Exam")]
        public async Task<IActionResult> GetAllExamAsync([FromQuery]PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var exams = await _examService.GetAllExamsAsync(filter, route);
            return exams.Success ? Ok(exams) : BadRequest(exams);
        }
        [HttpGet("state"), Authorize]
        [OpenApiOperation("Get all ongoing exam")]
        public async Task<IActionResult> GetOngoingExamsAsync([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var exams = await _examService.GetAllOngoingExamsAsync(filter, route);
            return exams.Success ? Ok(exams) : BadRequest(exams);
        }
        [HttpPut("{id}/status"), Authorize]
        [OpenApiOperation("update exam status by Id.", "")]
        public async Task<IActionResult> ChangeExamStatusAsync(Guid id)
        {
            var exam = await _examService.ChangeExamStateAsync(id);
            return exam.Success ? BadRequest(exam) : (IActionResult)BadRequest(exam);
        }
    }
}
