using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel
{
    public class CreateUserRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        public IFormFile? ProfileUpload { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}