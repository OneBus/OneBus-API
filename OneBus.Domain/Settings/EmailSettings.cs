namespace OneBus.Domain.Settings
{
    public class EmailSettings
    {
        public EmailSettings()
        {
            MailUser = string.Empty;
            MailPassword = string.Empty;
            MailHost = string.Empty;
            MailPort = string.Empty;
            MailEnableSsl = string.Empty;
        }
        
        // SMTP Mail Service Configuration
        public string MailUser { get; set; }

        public string MailPassword { get; set; }

        public string MailHost { get; set; }

        public string MailPort { get; set; }

        public string MailEnableSsl { get; set; }
    }
}
