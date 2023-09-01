using Application.Abstractions.Services;
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
        public async Task<IActionResult> LoginAsync([FromForm]LoginRequestModel model)
        {
            var logging = await _userService.LoginAsync(model);
            return logging.Success ? Ok(logging) : BadRequest(logging);
        }
    }
}
