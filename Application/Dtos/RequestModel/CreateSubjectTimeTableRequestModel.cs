using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.RequestModel
{
    public class CreateSubjectTimeTableRequestModel
    {
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string SubjectName { get; set; }
    }
}
