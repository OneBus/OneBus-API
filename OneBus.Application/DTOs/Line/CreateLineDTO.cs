namespace OneBus.Application.DTOs.Line
{
    public class CreateLineDTO : BaseCreateDTO
    {
        public CreateLineDTO()
        {
            Name = string.Empty;
            Number = string.Empty;
        }

        public string Number { get; set; }

        public string Name { get; set; }

        public byte Type { get; set; }

        public TimeOnly TravelTime { get; set; }

        public decimal Mileage { get; set; }

        public byte DirectionType { get; set; }
    }
}
