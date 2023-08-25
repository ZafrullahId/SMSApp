using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Abstractions.Services;
using Application.Dtos.RequestModel;

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

        [HttpPost("CreateQuestion/{paperId}")]
        public async Task<IActionResult> CreateAsync(CreateQuestionRequestModel model, Guid paperId)
        {
            var question = await _questionService.CreateQuestionAsync(model, paperId);
            return question.Success ? Ok(question) : BadRequest(question);
        }

        [HttpGet("GetQuestion/{id}")]
        public async Task<IActionResult> GetQuestionByIdAsync([FromRoute] Guid id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            return question.Success ? Ok(question) : BadRequest(question);
        }

        [HttpGet("GetAllQuestions/{paperId}")]
        public async Task<IActionResult> GetAllQuestionAsync([FromRoute] Guid paperId)
        {
            var questions = await _questionService.GetAllQuestionsByPaperIdAsync(paperId);
            return questions.Success ? Ok(questions) : BadRequest(questions);
        }

        [HttpPut("UpdateQuestion/{optionId}")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateQuestionRequestModel model, Guid optionId)
        {
            var question = await _questionService.UpdateAsync(optionId, model);
            return question.Success ? Ok(question) : BadRequest(question);
        }

        [HttpDelete("DeleteQuestion/{questionId}")]
        public async Task<IActionResult> DeleteAsync(Guid questionId)
        {
            var question = await _questionService.DeletAsync(questionId);
            return question.Success ? Ok(question) : BadRequest(question);
        }
    }
}
