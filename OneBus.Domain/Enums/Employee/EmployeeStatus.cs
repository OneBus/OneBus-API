using System.Text.Json.Serialization;

namespace OneBus.Domain.Enums.Employee
{
    public enum EmployeeStatus : byte
    {
        Ativo,
        Férias,
        Licença,
        Desligado,
        Folga,
        Ausente,
        [JsonStringEnumMemberName("Em Processo de Contratação")]
        Processo_Contratação
    }
}
