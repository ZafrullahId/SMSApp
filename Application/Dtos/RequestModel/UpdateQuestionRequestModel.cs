

using Domain.Enum;

namespace Application.Dtos.RequestModel
{
    public class UpdateQuestionRequestModel
    {
        public string Text { get; set; }
        public OptionType OptionType { get; set; }
        public double Marks { get; set; }
    }
}