using System.Collections.Generic;
namespace Application.Dtos.ResponseModel
{
    public class UserResponseModel : BaseResponse
    {
        public UserDto Data { get; set; }
    }
    public class UsersResponseModel : BaseResponse
    {
        public List<UserDto> Data { get; set; }
    }
}