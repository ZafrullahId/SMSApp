
using Domain.Enum;

namespace Application.Dtos
{
    public class QuestionOptionsDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public OptionType OptionType { get; set; }
        public double Marks { get; set; }
        public string? IMageUrl { get; set; }
        public List<OptionDto> Options { get; set; }
    }
}