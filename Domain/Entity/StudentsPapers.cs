using Domain.Contracts;

using System;

namespace Domain.Entity
{
    public class StudentPaper : AuditableEntity
    {
        public double Score { get; set; }
        public string? TeachersComment { get; set; }
        public bool IsTerminated { get; set; }
        public Guid StudentId { get; set; }  
        public Student Student { get; set; }
        public Guid PaperId { get; set; }  
        public Paper Paper { get; set; }
    }
}