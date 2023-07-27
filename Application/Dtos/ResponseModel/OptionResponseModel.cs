using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class OptionResponseModel : BaseResponse
    {
        public OptionDto Data { get; set; }
    }
    public class OptionsResponseModel : BaseResponse
    {   
        public List<OptionDto> Data { get; set; }
    }
}