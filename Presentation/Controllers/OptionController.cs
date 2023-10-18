using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

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

        [HttpPost("{questionId}"), Authorize(Roles = "Teacher")]
        [OpenApiOperation("Create Question ", "")]
        public async Task<IActionResult> CreateAsync([FromBody]List<CreateOptionRequestModel> models, Guid questionId)
        {
            var options = await _optionService.CreateOptionsAsync(models, questionId);
            return options.Success ? Ok(options) : BadRequest(options);
        }

        [HttpGet("{questionId}/options"), Authorize]
        [OpenApiOperation("Get options of a Question by question id", "")]
        public async Task<IActionResult> GetOptionsByQuestionId(Guid questionId)
        {
            var options = await _optionService.GetOptionByQuestionIdAsync(questionId);
            return options.Success ? Ok(options) : BadRequest(options);
        }

        [HttpGet("/{optionId}/{questionId}/{studentId}")]
        [OpenApiOperation("Check if option is correct by optioniId,studentId and questionId ", "")]
        public async Task<IActionResult> CheckOptionAsync(Guid optionId, Guid questionId, Guid studentId)
        {
            var option = await _optionService.CheckOptionAsync(optionId, questionId, studentId);
            return option.Success ? Ok(option) : BadRequest(option);
        }

        [HttpPut("{optionId}/option"), Authorize(Roles = "Teacher")]
        [OpenApiOperation("Updates an option by id ", "")]
        public async Task<IActionResult> UpdateAsync(Guid optionId, [FromForm]UpdateOptionRequestModel model)
        {
            var option = await _optionService.UpdateAsync(optionId, model);
            return option.Success ? Ok(option) : BadRequest(option);
        }

        [HttpDelete("{optionId}/option"), Authorize(Roles = "Teacher")]
        [OpenApiOperation("Deletes an option by id ", "")]
        public async Task<IActionResult> DeleteAsync(Guid optionId)
        {
            var option = await _optionService.DeleteAsync(optionId);
            return option.Success ? Ok(option) : BadRequest(option);
        }

    }
}
