using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class JwtTokenBL : IJwtTokenBL
    {
        private readonly IConfiguration _configuration;
        public JwtTokenBL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public string GenerateToken(string username)
        //{
        //    var jwtSettings = _configuration.GetSection("JwtSettings");
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //    new Claim(ClaimTypes.Name, username),
        //    new Claim(ClaimTypes.Role, "User")
        //    };

        //    var token = new JwtSecurityToken(
        //        issuer: jwtSettings["Issuer"],
        //        audience: jwtSettings["Audience"],
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"])),
        //        signingCredentials: credentials
        //    );
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        public string GenerateJwtToken(string id, string role)
        {
            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(JwtRegisteredClaimNames.Sub, id),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
