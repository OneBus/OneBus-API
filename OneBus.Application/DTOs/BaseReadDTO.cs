using System.Text.Json.Serialization;

namespace OneBus.Application.DTOs
{
    public abstract class BaseReadDTO
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime CreatedAt { get; set; }
    }
}
