namespace Application.Dtos.RequestModel
{
    public class CreateOptionRequestModel
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
    public class UpdateOptionRequestModel
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}