using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel
{
    public class CreateStudentRequestModel
    {
        [Required]
        public string PhoneNumber { get; set; } = default!;
        public string LevelName { get; set; } = default!;
        public Guid DepartmentId { get; set; }
    }
}