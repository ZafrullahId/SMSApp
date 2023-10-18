using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using NSwag.Annotations;

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

        [HttpPost]
        [OpenApiOperation("Create Staff.", "")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateStaffRequestModel model)
        {
            var staff = await _staffService.Create(model);
            return staff.Success ? Ok(staff) : BadRequest(staff);
        }

        [HttpGet("{id}")]
        [OpenApiOperation("Get staff By A specific Id .", "")]
        public async Task<IActionResult> GetStaffAsync([FromRoute] Guid id)
        {
            var staff = await _staffService.GetAsync(id);
            return staff.Success ? Ok(staff) : BadRequest(staff);
        }

        [HttpPut("{userId}")]
        [OpenApiOperation("Update staff by userId.", "")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateStaffRequestModel model, Guid userId)
        {
            var staff = await _staffService.UpdateAsync(userId, model);
            return staff.Success ? Ok(staff) : BadRequest(staff);
        }

        [HttpDelete("{id}")]
        [OpenApiOperation("Delete staff By id", "")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _staffService.DeleteAsync(id);
            return !isDeleted.Success ? BadRequest(isDeleted) : Ok(isDeleted);
        }
    }
}
