using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class SubjectTimeTableDto
    {
        public Guid TimeTableId { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public SubjectDto SubjectDto { get; set; }

    }
}
