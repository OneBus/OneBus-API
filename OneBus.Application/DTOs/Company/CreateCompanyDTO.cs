using OneBus.Application.DTOs.User;

namespace OneBus.Application.DTOs.Company
{
    public class CreateCompanyDTO : BaseCreateDTO
    {
        public CreateCompanyDTO()
        {
            Name = string.Empty;
            Cnpj = string.Empty;
            Email = string.Empty;
            CreateUser = default!;
        }

        public string Name { get; set; }

        public string Cnpj { get; set; }

        public string Email { get; set; }

        public CreateUserDTO CreateUser { get; set; }           
    }
}
