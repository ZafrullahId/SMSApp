using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Abstractions
{
    public interface IJWTAuthenticationManager
    {
        string GenerateToken(string key, string issuer, UserDto user);
        // static bool IsTokenValid(string key, string issuer, string token);
    }
}
