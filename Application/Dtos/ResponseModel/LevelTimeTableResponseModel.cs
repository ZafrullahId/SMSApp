
namespace Application.Dtos.ResponseModel
{
    public class LevelTimeTableResponseModel : BaseResponse
    {
        public LevelTimeTableDto Data { get; set; }
    }
    public class LevelsTimeTableResponseModel : BaseResponse
    {
        public List<LevelTimeTableDto> Data { get; set; }
    }
}
