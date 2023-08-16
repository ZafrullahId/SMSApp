using Domain.Contracts;
using System;

namespace Domain.Entity
{
    public class SubjectTimeTable : AuditableEntity
    {
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Location { get; set; }
        public Guid TimeTableId { get; set; }
        public TimeTable TimeTable { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
