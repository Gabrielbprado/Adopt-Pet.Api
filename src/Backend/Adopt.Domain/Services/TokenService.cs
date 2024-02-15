using Adopt.Domain.Services;
using Adopt_Pet.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Adopt_Pet.Api.Services;

public class TokenService 
{
  
    public virtual string GenerateTokenTutor(TutorModel model)
    {
        Claim[] claims = new Claim[]
        {
              new Claim("id",model.Id),
              new Claim("username",model.UserName),
              new Claim("city",model.City),
              new Claim("state",model.State),
              new Claim("email",model.Email),
              new Claim("phoneNumber",model.PhoneNumber),
               
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfoijsdfknlsudfls8789sdjfhso8d7ofdsjhu"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(30),
            claims: claims,
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
            
    }

    public virtual string GenerateTokenAbrigo(AbrigoModel model)
    {
        Claim[] claims = new Claim[]
        {
              new Claim("id",model.id.ToString()),
              new Claim("username",model.UserName),
              new Claim("city",model.City),
              new Claim("state",model.State),
              new Claim("email",model.Email),
              new Claim("phoneNumber",model.PhoneNumber),

        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfoijsdfknlsudfls8789sdjfhso8d7ofdsjhu"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(30),
            claims: claims,
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
