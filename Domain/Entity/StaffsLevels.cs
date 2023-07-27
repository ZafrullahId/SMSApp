using Domain.Contracts;
using System;

namespace Domain.Entity
{
    public class StaffsLevels : AuditableEntity
    {
        public Guid StaffId { get; set; }
        public Staff Staff { get; set; }
        public Guid LevelId { get; set; }
        public Level Level { get; set; }
    }
}