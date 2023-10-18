using Microsoft.AspNetCore.Http;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace SMSApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        [OpenApiOperation("Create Role","")]
        public async Task<IActionResult> CreateAsync([FromForm]CreateRoleRequestModel model)
        {
            var role = await _roleService.Create(model);
            return role.Success ? Ok(role) : BadRequest(role);
        }

        [HttpGet("{name}")]
        [OpenApiOperation("Get Role By A Specific Name", "")]
        public async Task<IActionResult> GetRoleAsync([FromRoute]string name)
        {
            var role = await _roleService.GetRoleAsync(name);
            return role.Success ? Ok(role) : BadRequest(role);
        }

        [HttpGet("roles")]
        [OpenApiOperation("Get All Roles", "")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var roles = await _roleService.GetRolesAsync();
            return roles.Success ? Ok(roles) : BadRequest(roles);
        }
    }
}
