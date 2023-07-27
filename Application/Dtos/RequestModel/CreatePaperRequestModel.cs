using System;

namespace Application.Dtos.RequestModel
{
    public class CreatePaperRequestModel
    {
        public string SubjectName { get; set; }
        public string LevelName { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instruction { get; set; }
    }
}