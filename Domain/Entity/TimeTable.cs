using Domain.Contracts;
using Domain.Enum;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class TimeTable : AuditableEntity
    {
        public Term Term { get; set; }
        public int Year { get; set; }
        public IEnumerable<SubjectTimeTable> SubjectTimeTables { get; set; } = new List<SubjectTimeTable>();
        public IEnumerable<LevelTimeTable> LevelTimeTables { get; set; } = new List<LevelTimeTable>();
    }
}
