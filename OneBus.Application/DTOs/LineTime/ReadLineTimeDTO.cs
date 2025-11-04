namespace OneBus.Application.DTOs.LineTime
{
    public class ReadLineTimeDTO : BaseReadDTO
    {
        public long LineId { get; set; }

        public string? LineNumber { get; set; }

        public string? LineName { get; set; }

        public byte LineDirectionType { get; set; }

        public string? LineDirectionTypeName { get; set; }

        public TimeOnly Time { get; set; }

        public byte DayType { get; set; }

        public string? DayTypeName { get; set; }
    }
}
