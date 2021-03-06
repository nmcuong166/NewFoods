﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewsFood.Core.Common.Extension;
using NewsFood.Core.Dto;
using NewsFood.Core.Interface.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
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

        public async Task<Token> GenerateToken(long id, string userName, [Optional]List<Claim> claims)
        {
            var localClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
            };

            if (!claims.IsNullOrEmpty())
            {
                claims.ForEach(s => localClaims.Add(s));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.Now.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(localClaims),
                Expires = expires,
                SigningCredentials = creds
                
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encoded = tokenHandler.WriteToken(token);
            return new Token(id, encoded, expires.Day);
        }

    }
}
