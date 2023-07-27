using System;
using Domain.Contracts;
using Domain.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Subject : AuditableEntity
    {
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Paper> Papers { get; set; } = new List<Paper>();
        public List<ExamSubjects> ExamSubjects { get; set; } = new List<ExamSubjects>();
        public List<StaffsSubjects> StaffsSubjects { get; set; } = new List<StaffsSubjects>();
        public IEnumerable<SubjectTimeTable> SubjectTimeTables { get; set; } = new List<SubjectTimeTable>();

    }
}