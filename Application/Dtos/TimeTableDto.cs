using Domain.Enum;

namespace Application.Dtos
{
    public class TimeTableDto
    {
        public Guid Id { get; set; }
        public Term Term { get; set; }
        public int Year { get; set; }
    }
}
