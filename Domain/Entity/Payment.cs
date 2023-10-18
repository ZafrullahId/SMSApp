using Domain.Contracts;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Payment : AuditableEntity
    {
        public int Amount { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public Term Term { get; set; }
        public string Session { get; set; }
        public string PaymentRef { get; set; }
    } 
}
