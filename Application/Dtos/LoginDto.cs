using System.Collections.Generic;

namespace Application.Dtos
{
    public class LoginDto
    {
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
