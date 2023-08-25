using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Auth;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("Add"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CreateAsync([FromForm]CreateStudentRequestModel model)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
            var staffUserId = JWTAuthenticationManager.GetLoginId(token);
            var student = await _studentService.CreateAsync(model, staffUserId);
            return student.Success ? Ok(student) : BadRequest(student);
        }

        [HttpGet("GetStudentById/{userId}")]
        public async Task<IActionResult> GetStudentAsync(Guid userId)
        {
            var student = await _studentService.GetStudentByUserIdAsync(userId);
            return student.Success == true ? Ok(student) : BadRequest(student);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return students.Success ? Ok(students) : BadRequest(students);
        }

        [HttpPut("UpdateStudent"), Authorize]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateStudentRequestModel model)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
            var studentUserId = JWTAuthenticationManager.GetLoginId(token);
            var student = await _studentService.UpdateStudentAsync(studentUserId, model);
            return student.Success ? Ok(student) : BadRequest(student);
        }

        [HttpPost("UploadStudentList"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] UploadStudentListFileRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var upload = await _studentService.UploadStudentListFileAsync(model.File);
                return upload.Success ? Ok(upload) : BadRequest(upload);
            }
            return BadRequest(model);
        }
    }
}
