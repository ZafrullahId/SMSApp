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
        [HttpPost("CreateOptions/{questionId}")]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> CreateAsync([FromBody]List<CreateOptionRequestModel> models, Guid questionId)
        {
            var options = await _optionService.CreateOptionsAsync(models, questionId);
            if (options.Success == true)
            {
                return Ok(options);
            }
            return BadRequest(options);
        }
        [HttpGet("GetOptionsByQuestionId/{questionId}")]
        public async Task<IActionResult> GetOptionsByQuestionId(Guid questionId)
        {
            var options = await _optionService.GetOptionByQuestionIdAsync(questionId);
            if (options.Success == true)
            {
                return Ok(options);
            }
            return BadRequest(options);
        }
        [HttpGet("CheckOption/{optionId}/{questionId}/{studentId}")]
        public async Task<IActionResult> CheckOptionAsync(Guid optionId, Guid questionId, Guid studentId)
        {
            var option = await _optionService.CheckOptionAsync(optionId, questionId, studentId);
            if (option.Success == true)
            {
                return Ok(option);
            }
            return BadRequest(option);
        }
        [HttpPut("UpdateOption/{optionId}")]
        public async Task<IActionResult> UpdateAsync(Guid optionId, [FromForm]UpdateOptionRequestModel model)
        {
            var option = await _optionService.UpdateAsync(optionId, model);
            if (option.Success == true)
            {
                return Ok(option);
            }
            return BadRequest(option);
        }
        [HttpDelete("DeleteOption/{optionId}")]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> DeleteAsync(Guid optionId)
        {
            var option = await _optionService.DeleteAsync(optionId);
            if (option.Success == true)
            {
                return Ok(option);
            }
            return BadRequest(option);
        }
        [HttpPut("SubmitPaper/{studentId}")]
        public async Task<IActionResult> SubmitAsync(Guid studentId, [FromQuery]List<Guid> ids)
        {
            var paper = await _optionService.SubmitPaperAsync(ids, studentId);
            if (paper.Success == true)
            {
                return Ok(paper);
            }
            return BadRequest(paper);
        }
    }
}
