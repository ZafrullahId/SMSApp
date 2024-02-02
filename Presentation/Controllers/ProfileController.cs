using Application.Abstractions.Services;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ISchoolProfileService _schoolProfileService;
        public ProfileController(ISchoolProfileService schoolProfileService)
        {
            _schoolProfileService = schoolProfileService;
        }
        [HttpGet]
        public async Task<ActionResult<SchoolProfileDto>> GetProfileAsync()
        {
            var profile = await _schoolProfileService.GetSchoolProfileAsync();
            return profile.Success ? Ok(profile) : StatusCode(500, profile);
        }
    }
}
