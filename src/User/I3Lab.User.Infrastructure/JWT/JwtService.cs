using I3Lab.Users.Application.Contract;
using I3Lab.Users.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace I3Lab.Users.Infrastructure.JWT
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _jwtSettings;

        public JwtService(IOptions<JwtOptions> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenegateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Users"),
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var signingCredentials = new SigningCredentials(
                secretKey,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                //issuer: _jwtSettings.Issuer,
                //audience: _jwtSettings.Audience,    
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresTime)); ;

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
