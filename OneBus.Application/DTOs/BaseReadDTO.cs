using System.Text.Json.Serialization;

namespace OneBus.Application.DTOs
{
    public abstract class BaseReadDTO
    {
        public ulong Id { get; set; }

        public DateTime CreatedAt { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DeletedAt { get; set; }
    }
}
