using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RaqamliAvlod.Domain.Entities.Users;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Infrastructure.Service.Services.Common
{
    public class AuthManager : IAuthManager
    {
        private readonly IConfigurationSection _configuration;

        public AuthManager(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("Jwt");
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescription = new JwtSecurityToken(_configuration["Issuer"], _configuration["Audience"], claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Lifetime"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescription);
        }
    }
}
