using System.Collections.Generic;
namespace Application.Dtos
{
    public class StaffLevelDto
    {
        public StaffDto StaffDto { get; set; }
        public List<LevelDto> LevelDtos { get; set; }
    }
}