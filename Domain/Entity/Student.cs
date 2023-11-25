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
        public DateTime? DateOfBirth { get; set; }
        public string AdmissionNo { get; set; } = "AD" + Guid.NewGuid().ToString()[..7].Replace("-", "").Replace("_", "").ToUpper();
        public string? NextOfKin { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public IEnumerable<PaymentRequest> Payment { get; set; }
        public IEnumerable<StudentPaper> StudentPaper { get; set; } = new List<StudentPaper>();
    }
}