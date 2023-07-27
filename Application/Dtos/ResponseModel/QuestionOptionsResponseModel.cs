using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class QuestionOptionsResponseModel : BaseResponse
    {
        public QuestionOptionsDto Data { get; set; }
    }
    public class QuestionsOptionsResponseModel : BaseResponse
    {
        public List<QuestionOptionsDto> Data { get; set; }
    }
}