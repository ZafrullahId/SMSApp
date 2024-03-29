using System.Collections.Generic;

namespace Application.Dtos.RequestModel
{
    public class CreateStaffRequestModel : CreateUserRequestModel
    {
        public List<string> Roles { get; set; }
        public List<string> Subjects { get; set; }
        public List<string> Levels { get; set; }
    }
}