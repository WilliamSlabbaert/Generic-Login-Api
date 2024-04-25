using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Generic_Login_Api.Helpers
{
    internal static class JwtTokenHelper
    {
        internal static string GetJwtToken(IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["MY_KEY"]));
            var keyCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(
              issuer: "Central-Login",
              audience: "User-Management",
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: keyCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }
    }
}
