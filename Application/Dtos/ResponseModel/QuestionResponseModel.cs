using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class QuestionResponseModel : BaseResponse
    {
        public QuestionDto Data { get; set; }
    }
    public class QuestionsResponseModel : BaseResponse
    {
        public List<QuestionDto> Data { get; set; }
    }
}