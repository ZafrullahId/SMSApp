using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entity.Identity
{
    public class User : AuditableEntity
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string? ProfileImage { get; set; }
        public string PhoneNumber { get; set; }
        public Staff Staff { get; set; }
        public Student Student { get; set; }
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}