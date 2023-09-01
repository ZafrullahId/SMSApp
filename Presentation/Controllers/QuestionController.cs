using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;
using NSwag.Annotations;

namespace Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("{paperId}")]
        [OpenApiOperation("Create Question", "")]
        public async Task<IActionResult> CreateAsync([FromForm]CreateQuestionRequestModel model, Guid paperId)
        {
            var question = await _questionService.CreateQuestionAsync(model, paperId);
            return question.Success ? Ok(question) : BadRequest(question);
        }

        [HttpGet("{id}")]
        [OpenApiOperation("Get a specific question type by id.", "")]
        public async Task<IActionResult> GetQuestionByIdAsync([FromRoute] Guid id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            return question.Success ? Ok(question) : BadRequest(question);
        }

        [HttpGet("{paperId}/questions")]
        [OpenApiOperation("Get all questions by a paperId.", "")]
        public async Task<IActionResult> GetAllQuestionAsync([FromRoute] Guid paperId)
        {
            var questions = await _questionService.GetAllQuestionsByPaperIdAsync(paperId);
            return questions.Success ? Ok(questions) : BadRequest(questions);
        }

        [HttpPut("{optionId}")]
        [OpenApiOperation("Update question by optionId.", "")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateQuestionRequestModel model, Guid optionId)
        {
            var question = await _questionService.UpdateAsync(optionId, model);
            return question.Success ? Ok(question) : BadRequest(question);
        }

        [HttpDelete("{questionId}")]
        [OpenApiOperation("Delete question by questionId.", "")]
        public async Task<IActionResult> DeleteAsync(Guid questionId)
        {
            var question = await _questionService.DeletAsync(questionId);
            return question.Success ? Ok(question) : BadRequest(question);
        }
    }
}
