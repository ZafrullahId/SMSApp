using Domain.Contracts;
using System;

namespace Domain.Entity
{
    public class ExamSubjects : AuditableEntity
    {
        public Guid SubjectId { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public Subject Subject { get; set; }
    }
}