using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class SchoolProfileDto
    {
        public Term Term { get; set; }
        public string Session { get; set; }
        public decimal SchoolFee { get; set; }
    }
}
