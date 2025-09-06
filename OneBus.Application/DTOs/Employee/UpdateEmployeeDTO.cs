namespace OneBus.Application.DTOs.Employee
{
    public class UpdateEmployeeDTO : BaseUpdateDTO
    {
        public UpdateEmployeeDTO()
        {
            Name = string.Empty;
            Rg = string.Empty;
            Cpf = string.Empty;
            Code = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
        }

        public string Name { get; set; }

        public string Rg { get; set; }

        public string Cpf { get; set; }

        public byte? BloodType { get; set; }

        public string Code { get; set; }

        public byte Role { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateOnly HiringDate { get; set; }

        public string? CnhNumber { get; set; }

        public byte? CnhCategory { get; set; }

        public DateOnly? CnhExpiration { get; set; }

        public byte Status { get; set; }

        public byte[]? Image { get; set; }
    }
}
