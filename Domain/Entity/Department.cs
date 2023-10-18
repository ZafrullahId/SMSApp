using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Student> Students { get; set; } = new HashSet<Student>();
        public IEnumerable<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
