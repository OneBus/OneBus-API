namespace OneBus.Application.DTOs.Login
{
    public class LoginDTO
    {
        public LoginDTO()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
