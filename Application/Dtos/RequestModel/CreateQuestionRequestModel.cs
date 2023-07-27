
using Domain.Enum;

namespace Application.Dtos.RequestModel
{
    public class CreateQuestionRequestModel
    {
        public string Text { get; set; }
        public OptionType OptionType { get; set; }
        public double Marks { get; set; }
        public List<CreateOptionRequestModel> Options { get; set; }
    }
}