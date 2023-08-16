using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Mvc;


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
        [HttpPost("Add")]
        public async Task<IActionResult> CreateAsync([FromForm]CreateStudentRequestModel model)
        {
            var student = await _studentService.CreateAsync(model);
            if (student.Success ==  true)
            {
                return Ok(student);
            }
            return BadRequest(student);
        }
        [HttpGet("GetStudentById/{userId}")]
        public async Task<IActionResult> GetStudentAsync(Guid userId)
        {
            var student = await _studentService.GetStudentByUserIdAsync(userId);
            if (student.Success == true)
            {
                return Ok(student);
            }
            return BadRequest(student);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _studentService.GetAllStudentsAsync();
            if (students.Success == true)
            {
                return Ok(students);
            }
            return BadRequest(students);
        }
        [HttpPut("UpdateStudent/{userId}")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateStudentRequestModel model ,Guid userId)
        {
            var student = await _studentService.UpdateStudentAsync(userId, model);
            if (student.Success == true)
            {
                return Ok(student);
            }
            return BadRequest(student);
        }
    }
}
