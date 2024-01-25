using Adopt_Pet.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Adopt_Pet.Api.Services;

public class TokenService 
{
    private IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration  = configuration;
    }

    public string GenerateTokenTutor(TutorModel model)
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

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdadauiohdiauydiisa65"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(30),
            claims: claims,
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
            
    }
    public string GenerateTokenAbrigo(AbrigoModel model)
    {
        Claim[] claims = new Claim[]
        {
              new Claim("id",model.Id),
              new Claim("username",model.UserName),
              new Claim("city",model.City),
              new Claim("state",model.State),
              new Claim("email",model.Email),
              new Claim("phoneNumber",model.PhoneNumber),
              new Claim("cnpj",model.CNPJ),

        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdadauiohdiauydiisa65"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(30),
            claims: claims,
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
