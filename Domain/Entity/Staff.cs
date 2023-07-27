using System.Collections.Generic;
using System;
using Domain.Contracts;
using Domain.Entity.Identity;

namespace Domain.Entity
{
    public class Staff : AuditableEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<StaffsSubjects> StaffsSubjects { get; set; } = new List<StaffsSubjects>();
        public List<StaffsLevels> StaffsLevels { get; set; } = new List<StaffsLevels>();
    }
}