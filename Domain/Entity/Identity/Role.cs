using Domain.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Identity
{
    public class Role : AuditableEntity
    {
        [Required]
        public string Name {get; set;}
        public string Description {get; set;}
        public List<UserRole> UserRoles {get; set;} = new List<UserRole>();
    }
}