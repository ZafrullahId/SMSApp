using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpPost("CreateOptions/{questionId}"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CreateAsync([FromBody]List<CreateOptionRequestModel> models, Guid questionId)
        {
            var options = await _optionService.CreateOptionsAsync(models, questionId);
            return options.Success ? Ok(options) : BadRequest(options);
        }

        [HttpGet("GetOptionsByQuestionId/{questionId}"), Authorize]
        public async Task<IActionResult> GetOptionsByQuestionId(Guid questionId)
        {
            var options = await _optionService.GetOptionByQuestionIdAsync(questionId);
            return options.Success ? Ok(options) : BadRequest(options);
        }

        [HttpGet("CheckOption/{optionId}/{questionId}/{studentId}")]
        public async Task<IActionResult> CheckOptionAsync(Guid optionId, Guid questionId, Guid studentId)
        {
            var option = await _optionService.CheckOptionAsync(optionId, questionId, studentId);
            return option.Success ? Ok(option) : BadRequest(option);
        }

        [HttpPut("UpdateOption/{optionId}"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> UpdateAsync(Guid optionId, [FromForm]UpdateOptionRequestModel model)
        {
            var option = await _optionService.UpdateAsync(optionId, model);
            return option.Success ? Ok(option) : BadRequest(option);
        }

        [HttpDelete("DeleteOption/{optionId}"), Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteAsync(Guid optionId)
        {
            var option = await _optionService.DeleteAsync(optionId);
            return option.Success ? Ok(option) : BadRequest(option);
        }

    }
}
