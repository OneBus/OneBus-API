namespace OneBus.Application.DTOs.VehicleOperation
{
    public class UpdateVehicleOperationDTO : BaseUpdateDTO
    {
        public long LineTimeId { get; set; }

        public long EmployeeWorkdayId { get; set; }

        public long VehicleId { get; set; }
    }
}
