using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class StudentResponseModel : BaseResponse
    {
        public StudentDto Data { get; set; }
    }
    public class StudentsResponseModel : BaseResponse
    {
        public List<StudentDto> Data { get; set; }
    }
}