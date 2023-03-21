using Meetup.Core.Models;
using Meetup.Core.Services;
using Meetup.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Meetup.Api.Services
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public JWTTokenService(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public JWTToken Authenticate(string userName, string password)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

            if (user == null)
            {
                return null;
            }

            var tokenhandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var tkey = Encoding.UTF8.GetBytes(_configuration["JWTToken:key"]);
            var ToeknDescp = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(ToeknDescp);

            return new JWTToken { Token = tokenhandler.WriteToken(token) };

        }
    }
}
