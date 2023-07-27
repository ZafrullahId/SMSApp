using Domain.Contracts;

using System;

namespace Domain.Entity
{
    public class StudentsPapers : AuditableEntity
    {
        public double Score { get; set; }
        public string TeachersComment { get; set; }
        public Guid PaperId { get; set; }  
        public Guid StudentId { get; set; }  
        public Student Student { get; set; }
        public Paper Paper { get; set; }
    }
}