namespace OneBus.Domain.Settings
{
    public class TokenSettings
    {
        public TokenSettings()
        {
            Audience = string.Empty;
            Issuer = string.Empty;
            Key = string.Empty;
        }

        public string Audience { get; set; }

        public string Issuer { get; set; }

        public string Key { get; set; }

        public int DaysUntilExpires { get; set; }
    }
}
