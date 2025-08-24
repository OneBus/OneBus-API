using System.Reflection;

namespace OneBus.Domain.Models
{
    public class TokenModel
    {
        public TokenModel(
            long userId,
            string name,
            string email,
            string token,
            DateTime created,
            DateTime expiration,
            string refreshToken)
        {
            Name = name;
            Email = email;
            Token = token;
            UserId = userId;
            Created = created;
            Expiration = expiration;
            RefreshToken = refreshToken;
        }

        public long UserId { get; }

        public string Email { get; }

        public string Name { get; }

        public string Token { get; }

        public string RefreshToken { get; }

        public string Version
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return $"{version?.Major}.{version?.Minor}.{version?.Build}";
            }
        }

        public DateTime Created { get; }

        public DateTime Expiration { get; }

        public double DurationInSeconds { get { return (Expiration - Created).TotalSeconds; } }
    }
}
