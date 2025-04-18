using OneBus.Domain.Extensions;
using System.Text.Json.Serialization;

namespace OneBus.Application.DTOs.Token
{
    public class TokenDTO
    {
        public const int DaysUntilExpire = 7;

        public TokenDTO(ulong companyId, ulong userId, string userEmail)
        {
            UserId = userId;
            CompanyId = companyId;
            UserEmail = userEmail;
            
            Token = string.Empty;
            Expiration = DateTime.UtcNow.ToBrazilianDateTime().AddDays(DaysUntilExpire);
        }

        [JsonIgnore]
        public ulong CompanyId { get; }

        [JsonIgnore]
        public ulong UserId { get; }

        [JsonIgnore]
        public string UserEmail { get; }

        public DateTime Expiration { get; }
        
        public string Token { get; set; }            
    }
}
