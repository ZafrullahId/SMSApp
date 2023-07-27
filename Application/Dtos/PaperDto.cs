

using Domain.Enum;

namespace Application.Dtos
{
    public class PaperDto
    {
        public Guid Id { get; set; }
        public PaperStatus PaperStatus  { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instruction { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
    }
}