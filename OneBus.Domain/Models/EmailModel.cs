namespace OneBus.Domain.Models
{
    public class EmailModel
    {
        public EmailModel()
        {
            To = [];
            Body = string.Empty;
            From = string.Empty;
            Subject = string.Empty;
            BodyPath = string.Empty;
            FromName = string.Empty;
            Variables = new Dictionary<string, string>();
        }

        public string FromName { get; set; }

        public string From { get; set; }

        public string[] To { get; set; }

        public string Subject { get; set; }

        public string BodyPath { get; set; }

        public string Body { get; set; }

        public bool IsCid { get; set; }

        public string? FileName { get; set; }

        public string? FilePath { get; set; }

        public string? FileType { get; set; }

        public MemoryStream? FileStream { get; set; }

        public IDictionary<string, string> Variables { get; set; }        
    }
}
