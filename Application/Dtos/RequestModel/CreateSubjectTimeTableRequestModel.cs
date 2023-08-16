using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please Select a location")]
        public string Location { get; set; }
    }
}
