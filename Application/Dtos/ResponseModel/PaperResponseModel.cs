using System.Collections.Generic;

namespace Application.Dtos.ResponseModel
{
    public class PaperResponseModel : BaseResponse
    {
        public PaperDto Data { get; set; }
    }
    public class PapersResponseModel : BaseResponse
    {
        public List<PaperDto> Data { get; set; }
    }
}
