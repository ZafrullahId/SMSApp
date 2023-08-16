using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.RequestModel
{
    public class CreateTimeTableRequestModel
    {
        [Required(ErrorMessage = "Please Select a term")]
        public Term Term { get; set; }
        [Required(ErrorMessage = "Please Select a year")]
        public string Seasion { get; set; }
        
    }
}
