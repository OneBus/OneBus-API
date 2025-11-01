namespace OneBus.Application.DTOs.VehicleOperation
{
    public class CreateVehicleOperationDTO : BaseCreateDTO
    {
        public long LineTimeId { get; set; }

        public long EmployeeWorkdayId { get; set; }

        public long VehicleId { get; set; }
    }
}
