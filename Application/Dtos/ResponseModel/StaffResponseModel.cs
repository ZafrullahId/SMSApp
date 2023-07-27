using System.Collections.Generic;

namespace Application.Dtos.ResponseModel
{
    public class StaffResponseModel : BaseResponse
    {
        public StaffDto Data { get; set; }
    }
    public class StaffsResponseModel : BaseResponse
    {
        public List<StaffDto> Data { get; set; }
    }
}