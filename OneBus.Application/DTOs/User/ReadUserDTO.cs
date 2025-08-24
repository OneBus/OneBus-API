namespace OneBus.Application.DTOs.User
{
    public class ReadUserDTO : BaseReadDTO
    {
        public ReadUserDTO()
        {
            Name = string.Empty;
            Email = string.Empty;
        }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
