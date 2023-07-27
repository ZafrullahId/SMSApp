using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class LevelTimeTableDto
    {
        public TimeTableDto TimeTable { get; set; }
        public IEnumerable<SubjectTimeTableDto> TimeTableSubject { get; set; }
    }
}
