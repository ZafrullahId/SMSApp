using Domain.Contracts;
using System;

namespace Domain.Entity
{
    public class StaffsSubjects : AuditableEntity
    {
        public Guid StaffId { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Staff Staff { get; set; }
    }
}