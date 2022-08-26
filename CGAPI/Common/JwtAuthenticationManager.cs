using CGAPI.DB.Models;
using CGAPI.VModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CGAPI.Common
{
    public class JwtAuthenticationManager
    {     
        private readonly string _key;
      
        private readonly IDictionary<string, string> _users = new Dictionary<string, string>()
        {
            {"test", "pass" },
            {"test2", "pwd" }
        };

        public JwtAuthenticationManager(string key)
        {            
            _key = key;            
        }

        public string Authenticate(CGUser curUser)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            SecurityTokenDescriptor tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, curUser.Username),
                    new Claim("Id", curUser.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDiscriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
