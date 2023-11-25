using System.Collections.Generic;

namespace Application.Dtos.RequestModel
{
    public class CreateStaffRequestModel : CreateUserRequestModel
    {
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Subjects { get; set; } = new List<string>();
        public List<string> Levels { get; set; } = new List<string>();
    }
}