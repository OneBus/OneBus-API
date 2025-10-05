namespace OneBus.Application.DTOs.Vehicle
{
    public class ReadBusChassisBrandDTO
    {
        public ReadBusChassisBrandDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
