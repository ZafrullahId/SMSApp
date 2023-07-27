using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class ExamResponseModel : BaseResponse
    {
        public ExamDto Data { get; set; }
    }
    public class ExamsResponseModel : BaseResponse
    {
        public List<ExamDto> Data { get; set; }
    }
}