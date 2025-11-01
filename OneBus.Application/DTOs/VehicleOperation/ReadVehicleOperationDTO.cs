using System.Text.Json.Serialization;

namespace OneBus.Application.DTOs.VehicleOperation
{
    public class ReadVehicleOperationDTO : BaseReadDTO
    {
        public long LineTimeId { get; set; }

        public TimeOnly? LineTimeTime { get; set; }

        public byte? LineTimeDayType { get; set; }
        
        public string? LineTimeDayTypeName { get; set; }

        public byte? LineTimeDirectionType { get; set; }
        
        public string? LineTimeDirectionTypeName { get; set; }

        [JsonPropertyName("lineId")]
        public long? LineTimeLineId { get; set; }

        [JsonPropertyName("lineDirectionType")]
        public byte? LineTimeLineDirectionType { get; set; }

        [JsonPropertyName("lineDirectionTypeName")]
        public string? LineTimeLineDirectionTypeName { get; set; }

        [JsonPropertyName("lineType")]
        public byte? LineTimeLineType { get; set; }

        [JsonPropertyName("lineTypeName")]
        public string? LineTimeLineTypeName { get; set; }

        [JsonPropertyName("lineNumber")]
        public string? LineTimeLineNumber { get; set; }

        [JsonPropertyName("lineName")]
        public string? LineTimeLineName { get; set; }

        public long EmployeeWorkdayId { get; set; }

        public TimeOnly? EmployeeWorkdayStartTime { get; set; }

        public TimeOnly? EmployeeWorkdayEndTime { get; set; }

        public byte? EmployeeWorkdayDayType { get; set; }
        
        public string? EmployeeWorkdayDayTypeName { get; set; }

        [JsonPropertyName("employeeId")]
        public long? EmployeeWorkdayEmployeeId { get; set; }

        [JsonPropertyName("employeeName")]
        public string? EmployeeWorkdayEmployeeName { get; set; }

        [JsonPropertyName("employeeImage")]
        public byte[]? EmployeeWorkdayEmployeeImage { get; set; }

        [JsonPropertyName("employeeCpf")]
        public string? EmployeeWorkdayEmployeeCpf { get; set; }

        [JsonPropertyName("employeeCode")]
        public string? EmployeeWorkdayEmployeeCode { get; set; }

        public long VehicleId { get; set; }

        public string? VehiclePrefix { get; set; }

        public byte? VehicleType { get; set; }
       
        public string? VehicleTypeName { get; set; }
    }
}
