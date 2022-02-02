using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Models;

namespace UsersAPI.Services
{
  public class TokenService
  {
    public Token CreateToken(IdentityUser<int> usuario)
    {
      Claim[] directivesUser = new Claim[]
      {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString())
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn"));
      var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
          claims: directivesUser,
          signingCredentials: credencials,
          expires: DateTime.UtcNow.AddHours(1)
          ); ;

      var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
      return new Token(tokenString);
    }
  }
}