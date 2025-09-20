namespace OneBus.Application.DTOs.Employee
{
    public class ReadRoleDTO
    {
        public ReadRoleDTO()
        {
            Name = string.Empty;
        }

        public byte Value { get; set; }

        public string Name { get; set; }
    }
}
