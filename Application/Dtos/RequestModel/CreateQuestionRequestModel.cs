
using Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestModel
{
    public class CreateQuestionRequestModel
    {
        [Required]
        public string Text { get; set; } = default!;
        public OptionType OptionType { get; set; }
        public double Marks { get; set; }
        public List<CreateOptionRequestModel> Options { get; set; }
    }
    public class CreateQuestionImageRequestModel
    {
        public IFormFile? QuestionIMage { get; set; }
    }
}