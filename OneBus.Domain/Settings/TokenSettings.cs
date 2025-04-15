namespace OneBus.Domain.Settings
{
    public class TokenSettings
    {
        public TokenSettings()
        {
            Audience = string.Empty;
            Issuer = string.Empty;
        }

        public string Audience { get; set; }

        public string Issuer { get; set; }
    }
}
