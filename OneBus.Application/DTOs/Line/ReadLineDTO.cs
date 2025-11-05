namespace OneBus.Application.DTOs.Line
{
    public class ReadLineDTO : BaseReadDTO
    {
        public ReadLineDTO()
        {
            Name = string.Empty;
            Number = string.Empty;
        }

        public string Number { get; set; }

        public string Name { get; set; }

        public byte Type { get; set; }

        public string? TypeName { get; set; }

        public TimeOnly TravelTime { get; set; }

        public decimal Mileage { get; set; }

        public byte DirectionType { get; set; }

        public string? DirectionTypeName { get; set; }
    }
}
