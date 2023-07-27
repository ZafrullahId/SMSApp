using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class LevelResponseModel : BaseResponse
    {
        public LevelDto Data { get; set; }
    }
    public class LevelsResponseModel : BaseResponse
    {
        public List<LevelDto> Data { get; set; }
    }
}