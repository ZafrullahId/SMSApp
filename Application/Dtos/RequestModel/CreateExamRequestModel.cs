using System.ComponentModel.DataAnnotations;
using System;
using Domain.Enum;

namespace Application.Dtos.RequestModel
{
    public class CreateExamRequestModel
    {
        [Required]
        public Term Term { get; set; }
        [Required]
        public int Year { get; set; }
    }
}