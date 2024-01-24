using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Host.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("access")]
        [OpenApiOperation("Gets access to send request", "Gets access to send request")]
        public async Task<ActionResult<LoginDto>> LoginAsync([FromBody]LoginRequestModel model)
        {
            var logging = await _userService.LoginAsync(model);
            return logging.Success ? Ok(logging) : BadRequest(logging);
        }
        [AllowAnonymous]
        [HttpPost("student")]
        [OpenApiOperation("Gets access to send request", "Gets access to send request")]
        public async Task<ActionResult<LoginDto>> LoginAsync([FromBody] StudentLoginRequestModel model)
        {
            var logging = await _userService.LoginAsync(model);
            return logging.Success ? Ok(logging) : BadRequest(logging);
        }
        [Authorize]
        [HttpPatch("update/{Id}")]
        public async Task<IActionResult> UpdateAuthCredentials([FromBody] UpdateAuthCredentialsRequestModel model, Guid Id)
        {
            var passwordChange = await _userService.UpdateAuthCredentialsAsync(model, Id);
            return Ok(passwordChange);
        }
    }
}
