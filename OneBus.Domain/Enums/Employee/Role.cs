using System.Text.Json.Serialization;

namespace OneBus.Domain.Enums.Employee
{
    public enum Role : byte
    {
        Fiscal,
        Supervisor,
        Cobrador,
        Motorista,
        [JsonStringEnumMemberName("Motorista e Cobrador")]
        Motorista_Cobrador
    }
}
