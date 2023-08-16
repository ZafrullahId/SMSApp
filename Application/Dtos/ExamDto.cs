
using Domain.Enum;

namespace Application.Dtos
{
    public class ExamDto
    {
        public Guid Id { get; set; }
        public bool IsEnded { get; set; }
        public Term Term { get; set; }
        public string Seasion { get; set; }
    }
}