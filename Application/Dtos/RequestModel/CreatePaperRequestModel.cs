using System;

namespace Application.Dtos.RequestModel
{
    public class CreatePaperRequestModel
    {
        public string SubjectName { get; set; } = default!;
        public string LevelName { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instruction { get; set; } = default!;
        public string Location { get; set; } = default!;
    }
}