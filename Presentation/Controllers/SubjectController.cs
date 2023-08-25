using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Mvc;


namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IExamSubjectsServices _examSubjectsServices;

        public SubjectController(ISubjectService subjectService, IExamSubjectsServices examSubjectsServices)
        {
            _subjectService = subjectService;
            _examSubjectsServices = examSubjectsServices;
        }

        [HttpPost("CreateSubject")]
        public async Task<IActionResult> CreateAsync([FromForm]CreateSubjectRequestModel model)
        {
            var subject = await _subjectService.CreateAsync(model);
            return subject.Success ? Ok(subject) : BadRequest(subject);
        }

        [HttpGet("GetSubject/{id}")]
        public async Task<IActionResult> GetSubjectAsync(Guid id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            return subject.Success ? Ok(subject) : BadRequest(subject);
        }

        [HttpGet("GetAllSubjects")]
        public async Task<IActionResult> GetSubjectsAsync()
        {
            var subjects = await _subjectService.GetSubjects();
            return subjects.Success ? Ok(subjects) : BadRequest(subjects);
        }

        [HttpGet("GetSubjectByStaffId/{staffId}")]
        public async Task<IActionResult> GetSubjectsByStaffIdAsync(Guid staffId)
        {
            var subjects = await _subjectService.GetSubjectsByStaffIdAsync(staffId);
            return subjects.Success ? Ok(subjects) : BadRequest(subjects);
        }

        [HttpGet("GetExamSubjectsByLevelId/{examId}/{levelId}")]
        public async Task<IActionResult> GetExamSubjectsByLevelIdAsync(Guid examId, Guid levelId)
        {
            var subjects = await _examSubjectsServices.GetExamSubjectsByLevelIdAsync(examId, levelId);
            return subjects.Success ? Ok(subjects) : BadRequest(subjects);
        }
    }
}
