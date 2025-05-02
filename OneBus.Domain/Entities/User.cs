namespace OneBus.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Salt = string.Empty;
            Phone = string.Empty;
        }

        public ulong UserTypeId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string? Image { get; set; }

        public UserType? UserType { get; set; }
    }
}
