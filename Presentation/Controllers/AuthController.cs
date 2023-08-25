using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Mvc;


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
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromForm]LoginRequestModel model)
        {
            var logging = await _userService.LoginAsync(model);
            return logging.Success ? Ok(logging) : BadRequest(logging);
        }
    }
}
