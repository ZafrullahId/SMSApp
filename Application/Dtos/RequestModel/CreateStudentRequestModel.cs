using System;

namespace Application.Dtos.RequestModel
{
    public class CreateStudentRequestModel
    {
        public DateTime? DateOfBirth { get; set; }
        public string? NextOfKin { get; set; }
        public string Class { get; set; }
        public CreateUserRequestModel User { get; set; }
    }
}