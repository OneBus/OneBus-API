using FluentValidation;
using OneBus.Application.DTOs.Vehicle;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class VehicleService : BaseService<Vehicle, CreateVehicleDTO, ReadVehicleDTO, UpdateVehicleDTO, BaseFilter>,
        IVehicleService
    {
        public VehicleService(
            IBaseRepository<Vehicle, BaseFilter> baseRepository, 
            IValidator<CreateVehicleDTO> createValidator, 
            IValidator<UpdateVehicleDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(Vehicle entity, UpdateVehicleDTO updateDTO)
        {
            entity.Year = updateDTO.Year;
            entity.Brand = updateDTO.Brand;
            entity.Model = updateDTO.Model;
            entity.Plate = updateDTO.Plate;
            entity.Color = updateDTO.Color;
            entity.Image = updateDTO.Image;
            entity.Prefix = updateDTO.Prefix;
            entity.Status = updateDTO.Status;
            entity.Renavam = updateDTO.Renavam;
            entity.FuelType = updateDTO.FuelType;
            entity.AxesNumber = updateDTO.AxesNumber;
            entity.NumberDoors = updateDTO.NumberDoors;
            entity.NumberSeats = updateDTO.NumberSeats;
            entity.EngineNumber = updateDTO.EngineNumber;
            entity.NumberChassis = updateDTO.NumberChassis;
            entity.BusChassisYear = updateDTO.BusChassisYear;
            entity.BusServiceType = updateDTO.BusServiceType;
            entity.BusHasLowFloor = updateDTO.BusHasLowFloor;
            entity.IpvaExpiration = updateDTO.IpvaExpiration;
            entity.BodyworkNumber = updateDTO.BodyworkNumber;
            entity.BusChassisBrand = updateDTO.BusChassisBrand;
            entity.BusChassisModel = updateDTO.BusChassisModel;
            entity.AcquisitionDate = updateDTO.AcquisitionDate;
            entity.BusHasLeftDoors = updateDTO.BusHasLeftDoors;
            entity.HasAccessibility = updateDTO.HasAccessibility;
            entity.TransmissionType = updateDTO.TransmissionType;
            entity.LicensingExpiration = updateDTO.LicensingExpiration;
            entity.BusFumigateExpiration = updateDTO.BusFumigateExpiration;
            entity.BusInsuranceExpiration = updateDTO.BusInsuranceExpiration;
        }
    }
}
