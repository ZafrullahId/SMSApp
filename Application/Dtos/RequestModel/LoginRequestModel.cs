using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel
{
    public class LoginRequestModel
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
    public class StudentLoginRequestModel
    {
        public string AdmissionNo { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
    public class UpdateAuthCredentialsRequestModel
    {
        public string NewPassword { get; set; } = default!;
        public string CurrentPassword { get; set; } = default!;
    }
}