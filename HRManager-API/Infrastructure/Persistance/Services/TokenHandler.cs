using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Persistance.Services
{
	public class TokenHandler : ITokenHandler
    {
        public Token CreateAccessToken(AppUser user)
        {
            var token = new Token();
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bir berber bir berbere gel beraber bir berber dukkani acalim demis"));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.UtcNow.AddMinutes(1);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                audience: "www.ahmet.com",
                issuer: "www.myapi.com",
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) }
                );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}

