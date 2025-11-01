namespace OneBus.Domain.Filters
{
    public class VehicleOperationFilter : BaseFilter
    {
        public byte? EmployeeStatus { get; set; }

        public byte? EmployeeRole { get; set; }

        public byte? EmployeeBloodType { get; set; }

        public byte? EmployeeWorkDayDayType { get; set; }

        public byte? LineType { get; set; }

        public byte? LineDirectionType { get; set; }

        public byte? LineTimeDirectionType { get; set; }

        public byte? LineTimeDayType { get; set; }

        public byte? VehicleStatus { get; set; }

        public byte? VehicleType { get; set; }

        public byte? VehicleBrand { get; set; }

        public byte? VehicleBusChassisBrand { get; set; }

        public byte? VehicleBusServiceType { get; set; }

        public byte? VehicleColor { get; set; }

        public byte? VehicleFuelType { get; set; }

        public byte? VehicleTransmissionType { get; set; }
    }
}
