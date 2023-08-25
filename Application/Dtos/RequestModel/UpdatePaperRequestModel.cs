using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel
{
    public class UpdatePaperRequestModel
    {
        [Required]
        public Guid LevelId { get; set; }
        [Required]
        public string? Subject { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public string Instruction { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
    }
}
