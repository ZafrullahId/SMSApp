using System;

namespace Application.Dtos
{
    public class StudentDto
    {
        public string AdmissionNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NextOfKin { get; set; }
        public LevelDto Level { get; set; }
        public UserDto User { get; set; }
        public DepartmentDto Department { get; set; }
    }
}