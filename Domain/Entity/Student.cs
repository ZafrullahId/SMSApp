using System;
using System.Collections.Generic;
using Domain.Contracts;
using Domain.Entity.Identity;

namespace Domain.Entity
{
    public class Student : AuditableEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NextOfKin { get; set; }
        public Guid LevelId { get; set; }
       public Level Level { get; set; }
        public List<StudentsPapers> StudentsPapers { get; set; } = new List<StudentsPapers>();
    }
}