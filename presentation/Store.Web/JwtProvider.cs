﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Store.Web
{
    public class JwtProvider(IOptions<JwtOptions> jwtoptions):IJwtProvider
    {
        private JwtOptions Jwtoptions { get; } = jwtoptions.Value;

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userid", user.Id.ToString()), new("userEmail", user.Email)];

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwtoptions.SecretKey)),
                SecurityAlgorithms.Aes128CbcHmacSha256);
            var token = new JwtSecurityToken(
                claims:claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(Jwtoptions.ExpitesHours)
                );
           
            var tokenValue= new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue; 
        }
    }
}
