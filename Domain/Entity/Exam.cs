using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Contracts;
using Domain.Enum;

namespace Domain.Entity
{
    public class Exam : AuditableEntity
    {
        public bool IsEnded { get; set; } = false;
        [Required]
        public Term Term { get; set; }
        [Required]
        public int Year { get; set; }
        public List<Paper> Papers = new List<Paper>();
        public List<ExamSubjects> Subjects {get; set; } = new List<ExamSubjects>();
    }
}