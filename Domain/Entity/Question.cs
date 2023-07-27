using System;
using System.Collections.Generic;
using Domain.Contracts;
using Domain.Enum;

namespace Domain.Entity
{
    public class Question : AuditableEntity
    {
        public string Text { get; set; }
        public OptionType OptionType { get; set; }
        public double Marks { get; set; }
        public Guid PaperId { get; set; }
        public Paper Paper { get; set; }
        public List<Choice> Options { get; set; }
    }
}