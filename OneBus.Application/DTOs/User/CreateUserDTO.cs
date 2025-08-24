namespace OneBus.Application.DTOs.User
{
    public class CreateUserDTO : BaseCreateDTO
    {
        public CreateUserDTO()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty; 
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public long UserTypeId { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
