using System;
using System.Collections.Generic;
using Domain.Contracts;
using Domain.Enum;
namespace Domain.Entity
{
    public class Paper : AuditableEntity
    {
        public PaperStatus PaperStatus { get; set; } = PaperStatus.Pending;
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instruction { get; set; }
        public bool IsReleased { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<StudentsPapers> StudentsSubject { get; set; } = new List<StudentsPapers>();
    }
}