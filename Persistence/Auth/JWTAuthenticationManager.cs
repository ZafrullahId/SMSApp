using Application.Abstractions;
using Application.AppConstants.CliamTypes;
using Application.Dtos;
using Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Auth
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        public string GenerateToken(string key, string issuer, UserDto user)
        {
            _ = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Role, user.Role.Name), 
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddHours(5), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
        public string GenerateToken(string key, string issuer, StudentDto student)
        {
            _ = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, student.User.Id.ToString()),
                new Claim(ClaimTypes.Email, student.User.Email ?? ""),
                new Claim(ClaimTypes.Name, student.User.FullName ?? ""),
                new Claim(ClaimTypes.MobilePhone, student.User.PhoneNumber ?? ""),
                new Claim(ClaimTypes.Role, student.User.Role.Name ?? ""), 
                new Claim(ClaimTypes.DateOfBirth, student.DateOfBirth.ToString() ?? ""), 
                new Claim(ApplicationConstant.ImageClaimsType, student.User.ProfileImage ?? ""), 
                new Claim(ApplicationConstant.AdmissionNoClaimsType, student.AdmissionNo ?? ""), 
                new Claim(ApplicationConstant.DepartmentClaimsType, student.Department.Name ?? ""), 
                new Claim(ApplicationConstant.NextOfKinClaimsType, student.NextOfKin ?? ""), 
                new Claim(ApplicationConstant.LevelClaimsType, student.Level.Name ?? ""), 
                new Claim(ApplicationConstant.LevelIdClaimsType, student.Level.Id.ToString() ?? ""), 

            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddHours(5), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
        public string GenerateNotCompletedProfileToken(string key, string issuer, UserDto user)
        {
            _ = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Role, user.Role.Name), 
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.AddHours(5), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
        public static bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static Guid GetLoginId(string? token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Retrieve the ID from the claims
            var idClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (idClaim != null)
            {
                string userId = idClaim.Value;

                // Use the userId as needed
                return Guid.Parse(userId);
            }
            else
            {
                // Handle the case when the ID claim is not present in the token
                return Guid.Empty;
            }
        }
    }
}
