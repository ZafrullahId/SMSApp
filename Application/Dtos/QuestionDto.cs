
using Domain.Enum;

namespace Application.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public OptionType OptionType { get; set; }
        public double Marks { get; set; }
    }
}