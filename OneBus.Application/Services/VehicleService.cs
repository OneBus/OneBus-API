using FluentValidation;
using OneBus.Application.DTOs.Vehicle;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Enums.Vehicle;
using OneBus.Domain.Extensions;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class VehicleService : BaseService<Vehicle, CreateVehicleDTO, ReadVehicleDTO, UpdateVehicleDTO, VehicleFilter>,
        IVehicleService
    {
        public VehicleService(
            IBaseRepository<Vehicle, VehicleFilter> baseRepository,
            IValidator<CreateVehicleDTO> createValidator,
            IValidator<UpdateVehicleDTO> updateValidator)
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        public override async Task<Result<Pagination<ReadVehicleDTO>>> GetPaginedAsync(
            VehicleFilter filter, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetPaginedAsync(filter, cancellationToken: cancellationToken);

            if (!result.Sucess)
                return result;

            foreach (var vehicle in result.Value!.Items)
            {
                vehicle.ColorName = ((Color?)vehicle.Color)?.ToString()?.Localize();
                vehicle.TypeName = ((VehicleType)vehicle.Type).ToString().Localize();
                vehicle.BrandName = ((VehicleBrands)vehicle.Brand).ToString().Localize();
                vehicle.FuelTypeName = ((FuelType)vehicle.FuelType).ToString().Localize();
                vehicle.StatusName = ((VehicleStatus)vehicle.Status).ToString().Localize();
                vehicle.BusServiceTypeName = ((BusServiceType?)vehicle.BusServiceType)?.ToString()?.Localize();
                vehicle.TransmissionTypeName = ((TransmissionType)vehicle.TransmissionType).ToString().Localize();
                vehicle.BusChassisBrandName = ((BusChassisBrands?)vehicle.BusChassisBrand)?.ToString()?.Localize();
            }

            return result;
        }

        public override async Task<Result<ReadVehicleDTO>> GetByIdAsync(
            long id, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetByIdAsync(id, cancellationToken: cancellationToken);

            if (!result.Sucess)
                return result;

            var vehicle = result.Value!;

            vehicle.ColorName = ((Color?)vehicle.Color)?.ToString()?.Localize();
            vehicle.TypeName = ((VehicleType)vehicle.Type).ToString().Localize();
            vehicle.BrandName = ((VehicleBrands)vehicle.Brand).ToString().Localize();
            vehicle.FuelTypeName = ((FuelType)vehicle.FuelType).ToString().Localize();
            vehicle.StatusName = ((VehicleStatus)vehicle.Status).ToString().Localize();
            vehicle.BusServiceTypeName = ((BusServiceType?)vehicle.BusServiceType)?.ToString()?.Localize();
            vehicle.TransmissionTypeName = ((TransmissionType)vehicle.TransmissionType).ToString().Localize();
            vehicle.BusChassisBrandName = ((BusChassisBrands?)vehicle.BusChassisBrand)?.ToString()?.Localize();

            return result;
        }

        public Result<IEnumerable<ReadVehicleStatusDTO>> GetStatus()
        {
            var values = Enum.GetValues<VehicleStatus>();

            List<ReadVehicleStatusDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadVehicleStatusDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadVehicleStatusDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadBrandDTO>> GetBrands()
        {
            var values = Enum.GetValues<VehicleBrands>();

            List<ReadBrandDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadBrandDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadBrandDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadBusChassisBrandDTO>> GetBusChassisBrands()
        {
            var values = Enum.GetValues<BusChassisBrands>();

            List<ReadBusChassisBrandDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadBusChassisBrandDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadBusChassisBrandDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadBusServiceTypeDTO>> GetBusServiceTypes()
        {
            var values = Enum.GetValues<BusServiceType>();

            List<ReadBusServiceTypeDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadBusServiceTypeDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadBusServiceTypeDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadColorDTO>> GetColors()
        {
            var values = Enum.GetValues<Color>();

            List<ReadColorDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadColorDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadColorDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadFuelTypeDTO>> GetFuelTypes()
        {
            var values = Enum.GetValues<FuelType>();

            List<ReadFuelTypeDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadFuelTypeDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadFuelTypeDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadTransmissionTypeDTO>> GetTransmissionTypes()
        {
            var values = Enum.GetValues<TransmissionType>();

            List<ReadTransmissionTypeDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadTransmissionTypeDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadTransmissionTypeDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadTypeDTO>> GetVehicleTypes()
        {
            var values = Enum.GetValues<VehicleType>();

            List<ReadTypeDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadTypeDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadTypeDTO>>.Create(status);
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
            entity.Licensing = updateDTO.Licensing;
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
            entity.BusFumigateExpiration = updateDTO.BusFumigateExpiration;
            entity.BusInsuranceExpiration = updateDTO.BusInsuranceExpiration;
        }
    }
}
