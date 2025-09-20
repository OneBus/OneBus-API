using FluentValidation;
using OneBus.Application.DTOs.EmployeeWorkday;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Enums;
using OneBus.Domain.Extensions;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class EmployeeWorkdayService : BaseService<EmployeeWorkday, CreateEmployeeWorkdayDTO, ReadEmployeeWorkdayDTO, UpdateEmployeeWorkdayDTO, EmployeeWorkDayFilter>,
        IEmployeeWorkdayService
    {
        public EmployeeWorkdayService(
            IBaseRepository<EmployeeWorkday, EmployeeWorkDayFilter> baseRepository,
            IValidator<CreateEmployeeWorkdayDTO> createValidator,
            IValidator<UpdateEmployeeWorkdayDTO> updateValidator)
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        public override async Task<Result<Pagination<ReadEmployeeWorkdayDTO>>> GetPaginedAsync(
            EmployeeWorkDayFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetPaginedAsync(filter, dbQueryOptions, cancellationToken);

            if (!result.Sucess)
                return result;

            var employeesWorkdays = result.Value!.Items;

            foreach (var employeeWorkday in employeesWorkdays)
            {
                employeeWorkday.DayTypeName = ((DayType)employeeWorkday.DayType).ToString().Localize();
            }

            return result;
        }

        public override async Task<Result<ReadEmployeeWorkdayDTO>> GetByIdAsync(
            long id,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetByIdAsync(id, dbQueryOptions, cancellationToken);

            if (!result.Sucess)
                return result;

            var employeeWorkday = result.Value!;

            employeeWorkday.DayTypeName = ((DayType)employeeWorkday.DayType).ToString().Localize();
            return result;
        }

        public Result<IEnumerable<ReadDayTypeDTO>> GetDaysTypes()
        {
            var values = Enum.GetValues<DayType>();

            List<ReadDayTypeDTO> daysTypes = [];

            foreach (var value in values)
            {
                daysTypes.Add(new ReadDayTypeDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadDayTypeDTO>>.Create(daysTypes);
        }

        protected override void UpdateFields(EmployeeWorkday entity, UpdateEmployeeWorkdayDTO updateDTO)
        {
            entity.StartTime = updateDTO.StartTime;
            entity.EndTime = updateDTO.EndTime;
        }
    }
}
