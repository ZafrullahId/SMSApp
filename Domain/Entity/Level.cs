using Domain.Contracts;
using System.Collections.Generic;
namespace Domain.Entity
{
    public class Level : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Paper> Papers { get; set; } = new List<Paper>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<StaffsLevels> StaffsLevels { get; set; } = new List<StaffsLevels>();
        public IEnumerable<LevelTimeTable> LevelTimeTables { get; set; } = new List<LevelTimeTable>();
    }
}