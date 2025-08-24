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
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
    }
}
