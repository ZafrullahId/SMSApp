using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsProfileComplete { get; set; }
        public RoleDto Role { get; set; }
    }
}