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
        public async Task<IActionResult> CreateAsync([FromBody]CreateQuestionRequestModel model, Guid paperId)
        {
            var question = await _questionService.CreateQuestionAsync(model, paperId);
            if (question.Success == true)
            {
                return Ok(question);
            }
            return BadRequest(question);
        }
        [HttpGet("GetQuestion/{id}")]
        public async Task<IActionResult> GetQuestionByIdAsync([FromRoute] Guid id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            if (question.Success == true)
            {
                return Ok(question);
            }
            return BadRequest(question);    
        }
        [HttpGet("GetAllQuestions/{paperId}")]
        public async Task<IActionResult> GetAllQuestionAsync([FromRoute] Guid paperId)
        {
            var questions = await _questionService.GetAllQuestionsByPaperIdAsync(paperId);
            if (questions.Success == true)
            {
                return Ok(questions);
            }
            return BadRequest(questions);
        }
        [HttpPut("UpdateQuestion/{optionId}")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateQuestionRequestModel model, Guid optionId)
        {
            var question = await _questionService.UpdateAsync(optionId, model);
            if (question.Success == true)
            {
                return Ok(question);
            } 
            return BadRequest(question);
        }
        [HttpDelete("DeleteQuestion/{questionId}")]
        public async Task<IActionResult> DeleteAsync(Guid questionId)
        {
            var question = await _questionService.DeletAsync(questionId);
            if(question.Success == true)
            {
                return Ok(question);
            }
            return BadRequest(question);
        }
    }
}
