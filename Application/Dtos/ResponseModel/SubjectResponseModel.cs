using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class SubjectResponseModel : BaseResponse
    {
        public SubjectDto Data { get; set; }
    }
    public class SubjectsResponseModel : BaseResponse
    {
        public List<SubjectDto> Data { get; set; }
    }
}