using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tryitter.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace tryitter.Services
{
  public class TokenGenerator
  {
    public string Generate(Student student)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
  
      var tokenDescriptor = new SecurityTokenDescriptor()
      {
          Subject = AddClaims(student),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SegredoSuperSecreto!")), SecurityAlgorithms.HmacSha256Signature),
          Expires = DateTime.Now.AddDays(1)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }

    private ClaimsIdentity AddClaims(Student student)
    {
      var claim = new ClaimsIdentity();
      var email = new Claim(ClaimTypes.Email, student.Email);
      var moduleId = new Claim(ClaimTypes.UserData, student.ModuleId.ToString());

      var claimsCollection = new List<Claim>();
      claimsCollection.Add(email);
      claimsCollection.Add(moduleId);
      claim.AddClaims(claimsCollection);
      return claim;
    }
  }
}