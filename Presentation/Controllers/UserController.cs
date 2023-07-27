using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Mvc;


namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromForm]LoginRequestModel model)
        {
            var logging = await _userService.LoginAsync(model);
            if (logging.Success ==  true)
            {
                return Ok(logging);
            }
            return BadRequest(logging);
        }
    }
}
