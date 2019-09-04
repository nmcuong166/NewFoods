using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewsFood.Core.Dto;
using NewsFood.Core.Interface.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewFood.Infurstructure.Auth
{
    public class JWTFactory : IJWTFactory
    {
        private IConfiguration _configuration;
        public JWTFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Token> GenerateToken(long id, string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JWT:JwtExpireDays"]));

            var jwt = new JwtSecurityToken(
                issuer: _configuration["JWT:JwtIssuer"],
                audience: _configuration["JWT:JwtIssuer"],
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            var encoded = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new Token(id, encoded, expires.Second);
        }
    }
}
