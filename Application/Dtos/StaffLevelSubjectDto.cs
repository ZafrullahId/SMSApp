using System.Collections.Generic;
namespace Application.Dtos
{
    public class StaffLevelSubjectDto
    {
        public UserDto User { get; set; }
        public List<SubjectDto> Subject { get; set; }
        public List<LevelDto> Level { get; set; }
    }
}