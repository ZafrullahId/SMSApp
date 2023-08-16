using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelService _levelService;

        public LevelController(ILevelService levelService)
        {
            _levelService = levelService;
        }
        //[Authorize(Roles = "Admin, Teacher, Staff")]
        [HttpPost("CreateLevel"), Authorize]
        public async Task<IActionResult> CreateAsync([FromForm]CreateLevelRequestModel model)
        {
            var level = await _levelService.CreateLevel(model);
            if(level.Success == true)
            {
                return Ok(level);
            }
            return BadRequest(level);
        }
        [HttpGet("GetAllLevels"), Authorize]
        public async Task<IActionResult> GetAllLevelsAsync()
        {
            var levels = await _levelService.GetLevelsAsync();
            if (levels.Success == true)
            {
                return Ok(levels);
            }
            return BadRequest(levels);
        }
        [HttpGet("GetLevel/{id}"), Authorize]
        public async Task<IActionResult> GetLevelAsync(Guid id)
        {
            var level = await _levelService.GetLevelAsync(id);
            if (level.Success == true)
            {
                return Ok(level);
            }
            return BadRequest(level);
        }
        [HttpDelete("Delete/{id}"), Authorize]
        public async Task<IActionResult> DeleteLevelAsync(Guid id)
        {
            var isDeleted = await _levelService.DeleteLevelAsync(id);
            if (!isDeleted.Success)
            {
                return BadRequest(isDeleted);
            }
            return Ok(isDeleted);
        }
        [HttpGet("GetLevelsByStaffId/{id}"), Authorize]
        public async Task<IActionResult> GetLevelsByStaffIdAsync(Guid id)
        {
            var levels = await _levelService.GetLevelsByStaffId(id);
            if(levels.Success == true)
            {
                return Ok(levels);
            }
            return BadRequest(levels);
        }
    }
}
