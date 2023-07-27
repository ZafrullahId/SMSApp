using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class StudentPaperResponseModel : BaseResponse
    {
        public StudentPapersDto Data { get; set; }
    }
    public class StudentsPapersResponseModel : BaseResponse
    {
        public List<StudentPapersDto> Data { get; set; }
    }
}