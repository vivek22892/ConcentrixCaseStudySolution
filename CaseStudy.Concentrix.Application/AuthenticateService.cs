using CaseStudy.Concentrix.Abstraction.Interface;
using CaseStudy.Concentrix.Abstraction.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CaseStudy.Concentrix.Application
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IConfiguration _config;
        public AuthenticateService(IConfiguration config)
        {
                _config = config;
        }
        //<summary> Authenticate the existing user</ summary >
        /// <returns>jwt token</returns>
        public JwtToken AuthenticateUser(User user)
        {
            var jwtToken = new JwtToken();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = CreateClaims(user);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"], 
            claims,
             expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
            var tokenData = new JwtSecurityTokenHandler().WriteToken(token);
            jwtToken.Token = tokenData;
            jwtToken.Authenticated = true;
            return jwtToken;
        }

        /// <summary>Adding claims </summary>
        /// <returns>claims</returns>
        private IEnumerable<Claim> CreateClaims(User user)
        {
            var claims = new[]
            {
                new Claim("UserId",user.Id.ToString()),
                new Claim("Email",user.Email),
                 new Claim("UserName",user.UserName),

            };
            return claims;
        }
    }
}
