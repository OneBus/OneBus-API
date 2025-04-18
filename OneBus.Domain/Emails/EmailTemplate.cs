namespace OneBus.Domain.Emails
{
    public class EmailTemplate
    {
        public EmailTemplate()
        {
            FromName = string.Empty;
            From = string.Empty;
            To = [];
            Subject = string.Empty;
            Body = string.Empty;
            FileName = string.Empty;
            FilePath = string.Empty;
            FileType = string.Empty;
            FileStream = new();
            Variables = new Dictionary<string, string>();
        }

        public string FromName { get; set; }

        public string From { get; set; }

        public string[] To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsHtml { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string FileType { get; set; }

        public MemoryStream FileStream { get; set; }

        public IDictionary<string, string> Variables { get; set; }        
    }
}
