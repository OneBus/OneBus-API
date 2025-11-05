using FluentValidation;
using OneBus.Application.DTOs.Maintenance;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Enums.Maintenance;
using OneBus.Domain.Extensions;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class MaintenanceService : BaseService<Maintenance, CreateMaintenanceDTO, ReadMaintenanceDTO, UpdateMaintenanceDTO, MaintenanceFilter>,
        IMaintenanceService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public MaintenanceService(
            IBaseRepository<Maintenance, MaintenanceFilter> baseRepository,
            IValidator<CreateMaintenanceDTO> createValidator,
            IValidator<UpdateMaintenanceDTO> updateValidator,
            IVehicleRepository vehicleRepository)
            : base(baseRepository, createValidator, updateValidator)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async override Task<Result<Pagination<ReadMaintenanceDTO>>> GetPaginedAsync(
            MaintenanceFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetPaginedAsync(filter, dbQueryOptions, cancellationToken);

            if (!result.Sucess)
                return result;

            foreach (var maintenance in result.Value!.Items)
            {
                maintenance.SectorName = ((Sector)maintenance.Sector).ToString().Localize();
            }

            return result;
        }

        public async override Task<Result<ReadMaintenanceDTO>> GetByIdAsync(
            long id,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetByIdAsync(id, dbQueryOptions, cancellationToken);

            if (!result.Sucess)
                return result;

            var maintenance = result.Value!;
            maintenance.SectorName = ((Sector)maintenance.Sector).ToString().Localize();

            return result;
        }

        public Result<IEnumerable<ReadSectorDTO>> GetSectors()
        {
            var values = Enum.GetValues<Sector>();

            List<ReadSectorDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadSectorDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadSectorDTO>>.Create(status);
        }

        public async override Task<Result<ReadMaintenanceDTO>> CreateAsync(
            CreateMaintenanceDTO createDTO,
            CancellationToken cancellationToken = default)
        {
            var result = await base.CreateAsync(createDTO, cancellationToken);

            if (!result.Sucess)
                return result;

            await _vehicleRepository.SetStatusAsync([createDTO.VehicleId], Domain.Enums.Vehicle.VehicleStatus.Em_Manutenção, cancellationToken);
            return result;
        }

        protected override void UpdateFields(Maintenance entity, UpdateMaintenanceDTO updateDTO)
        {
            entity.Cost = updateDTO.Cost;
            entity.Sector = updateDTO.Sector;
            entity.EndDate = updateDTO.EndDate;
            entity.StartDate = updateDTO.StartDate;
            entity.Description = updateDTO.Description;
            entity.SurveyExpiration = updateDTO.SurveyExpiration;
        }
    }
}
