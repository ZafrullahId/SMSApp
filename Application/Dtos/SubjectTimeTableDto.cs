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
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string Location { get; set; }
        public TimeSpan Duration { get; set; }
        public SubjectDto SubjectDto { get; set; }

    }
}
