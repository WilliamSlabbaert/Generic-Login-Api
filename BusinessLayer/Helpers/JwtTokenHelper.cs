
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BusinessLayer.Helpers
{
    internal static class JwtTokenHelper
    {
        internal static string GetJwtToken(this IConfiguration config, string audienceType = "User-Management")
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["MY_KEY"]));
            var keyCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(
              issuer: "Central-Login",
              audience: audienceType,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: keyCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }
    }
}
