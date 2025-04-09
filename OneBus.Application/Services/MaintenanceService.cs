using FluentValidation;
using OneBus.Application.DTOs.Maintenance;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class MaintenanceService : BaseService<Maintenance, CreateMaintenanceDTO, ReadMaintenanceDTO, UpdateMaintenanceDTO, BaseFilter>,
        IMaintenanceService
    {
        public MaintenanceService(
            IBaseRepository<Maintenance, BaseFilter> baseRepository, 
            IValidator<CreateMaintenanceDTO> createValidator, 
            IValidator<UpdateMaintenanceDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        protected override void UpdateFields(Maintenance entity, UpdateMaintenanceDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
