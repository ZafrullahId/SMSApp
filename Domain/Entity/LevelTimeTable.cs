using Domain.Contracts;
using System;

namespace Domain.Entity
{
    public class LevelTimeTable : AuditableEntity
    {
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
        public Guid TimeTableId { get; set; }
        public TimeTable TimeTable { get; set; }
    }
}
