﻿using Microsoft.AspNetCore.Http;

namespace Application.Dtos.RequestModel
{
    public class UpdateUserRequestModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
