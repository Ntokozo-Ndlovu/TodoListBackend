using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.JwtAuthorization
{
    public class JwtAuthorization: IJwtAuthorization
    {
        public static readonly TimeSpan TokenLifeTime = TimeSpan.FromMinutes(30);
        public static string TokenSecret = "BLQwsfgtFG8jio+N2N++6DhfN2BrKi55A++WUnt2GsGTZIAZIbm34URzuFcepEPD";

        public string GenerateJwtToken(Guid userId)
        {


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new ("userId",userId.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };




            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);


            return jwt;
        }

        public string DecodeJwtToken(string token)
        {
            var key = Encoding.ASCII.GetBytes(TokenSecret);
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);

            return claims.FindFirst(p => p.Type == "userId").Value;
        }
    }
}
