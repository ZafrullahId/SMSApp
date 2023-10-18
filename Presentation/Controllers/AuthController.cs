using Application.Abstractions.Services;
using Application.Dtos;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Access")]
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
    }
}
