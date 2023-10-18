using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDepartmentRequestModel model)
        {
            var request = await _departmentService.CreateAsync(model);
            if( request.Success ) { return Ok(request); }
            return BadRequest(request);
        }
        [HttpGet("Departments")]
        public async Task<IActionResult> GetAllAsync()
        {
            var request = await _departmentService.GetAllAsync();
            if( request.Success ) { return Ok(request); }
            return BadRequest(request);
        }
        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> DeleteAsync(Guid departmentId)
        {
            var request = await _departmentService.DeleteAsync(departmentId);
            if( request.Success ) { return Ok(request); }
            return BadRequest(request);
        }

    }
}
