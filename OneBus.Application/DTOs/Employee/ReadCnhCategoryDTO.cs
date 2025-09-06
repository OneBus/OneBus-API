namespace OneBus.Application.DTOs.Employee
{
    public class ReadCnhCategoryDTO
    {
        public ReadCnhCategoryDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
