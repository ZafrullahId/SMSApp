using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        [HttpPost("CreateStaff")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateStaffRequestModel model)
        {
            var staff = await _staffService.Create(model);
            if (staff.Success == true)
            {
                return Ok(staff);
            }
            return BadRequest(staff);
        }
        [HttpGet("GetStaffById/{id}")]
        public async Task<IActionResult> GetStaffAsync([FromRoute] Guid id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);
            if (staff.Success == true)
            {
                return Ok(staff);
            }
            return BadRequest(staff);
        }
        [HttpPut("UpdateStaff/{userId}")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateStaffRequestModel model, Guid userId)
        {
            var staff = await _staffService.UpdateAsync(userId, model);
            if (staff.Success == true)
            {
                return Ok(staff);
            }
            return BadRequest(staff);
        }
        [HttpDelete("DeleteSaff/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _staffService.DeleteAsync(id);
            if (!isDeleted.Success)
            {
                return BadRequest(isDeleted);
            }
            return Ok(isDeleted);
        }
    }
}
