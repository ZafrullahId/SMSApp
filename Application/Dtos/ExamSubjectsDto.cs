
using System.Collections.Generic;

namespace Application.Dtos
{
    public class ExamSubjectsDto
    {
        public ExamDto ExamDto { get; set; }
        public LevelDto LevelDto { get; set; }
        public List<SubjectDto> SubjectDtos { get; set; }
    }
}