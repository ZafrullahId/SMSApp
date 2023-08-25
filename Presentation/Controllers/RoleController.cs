using Microsoft.AspNetCore.Http;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateAsync([FromForm]CreateRoleRequestModel model)
        {
            var role = await _roleService.Create(model);
            return role.Success ? Ok(role) : BadRequest(role);
        }

        [HttpGet("GetRole/{name}")]
        public async Task<IActionResult> GetRoleAsync([FromRoute]string name)
        {
            var role = await _roleService.GetRoleAsync(name);
            return role.Success ? Ok(role) : BadRequest(role);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var roles = await _roleService.GetRolesAsync();
            return roles.Success ? Ok(roles) : BadRequest(roles);
        }
    }
}
