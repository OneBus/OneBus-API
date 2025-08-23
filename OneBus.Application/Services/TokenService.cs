using System.Text;
using OneBus.Domain.Models;
using OneBus.Domain.Settings;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Options;
using OneBus.Application.DTOs.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using OneBus.Application.Interfaces.Services;

namespace OneBus.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> options)
        {
            _tokenSettings = options.Value;
        }

        public TokenModel Generate(ReadUserDTO user)
        {
            var claims = new List<Claim>
            {
                new("company_id", user.CompanyId.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.NameId, user.Id.ToString()!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
            };

            ClaimsIdentity identity = new(new GenericIdentity(user.Email, "login"), claims);

            DateTime createdAt = DateTime.UtcNow;
            DateTime expiresAt = createdAt.AddDays(_tokenSettings.DaysUntilExpires);

            return new TokenModel(Create(
                key: Encoding.ASCII.GetBytes(_tokenSettings.Key),
                identity,
                createdAt,
                expiresAt)
            );
        }

        private string Create(byte[] key, ClaimsIdentity identity, DateTime createdAt, DateTime expiresAt)
        {
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(
                handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenSettings.Issuer,
                    Audience = _tokenSettings.Audience,
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature),
                    Subject = identity,
                    NotBefore = createdAt,
                    Expires = expiresAt,
                })
            );
        }
    }
}
