﻿using OneBus.Domain.Enums.Bus;

namespace OneBus.Domain.Entities
{
    public class Bus : BaseEntity
    {
        public Bus()
        {
            ChassisBrand = string.Empty;
            ChassisModel = string.Empty;
        }

        public ulong VehicleId { get; set; }

        public ServiceType ServiceType { get; set; }

        public string ChassisBrand { get; set; }

        public string ChassisModel { get; set; }

        public ushort ChassisYear { get; set; }

        public bool HasLowFloor { get; set; }

        public bool HasLeftDoors { get; set; }

        public DateOnly InsuranceExpiration { get; set; }

        public DateOnly FumigateExpiration { get; set; }

        public Vehicle? Vehicle { get; set; }

        public ICollection<BusOperation>? BusOperations { get; set; }

        public ICollection<BusAudit>? BusAudits { get; set; }
    }
}
