using Domain.Contracts;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class SchoolProfile : AuditableEntity
    {
        public decimal SchoolFee { get; set; }
        public string Session { get; set; }
        public Term Term { get; set; }
    }
}
