using System;

namespace Application.Dtos.RequestModel
{
    public class UpdateStudentRequestModel : UpdateUserRequestModel
    {
        public DateTime? DateOfBirth { get; set; }
        public string? NextOfKin { get; set; }
        //public UpdateUserRequestModel? User { get; set; }
    }
}
