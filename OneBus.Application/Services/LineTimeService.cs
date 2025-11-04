using FluentValidation;
using OneBus.Application.DTOs.LineTime;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Enums;
using OneBus.Domain.Enums.Line;
using OneBus.Domain.Extensions;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class LineTimeService : BaseService<LineTime, CreateLineTimeDTO, ReadLineTimeDTO, UpdateLineTimeDTO, LineTimeFilter>,
        ILineTimeService
    {
        public LineTimeService(
            IBaseRepository<LineTime, LineTimeFilter> baseRepository, 
            IValidator<CreateLineTimeDTO> createValidator, 
            IValidator<UpdateLineTimeDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        public async override Task<Result<Pagination<ReadLineTimeDTO>>> GetPaginedAsync(
            LineTimeFilter filter, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetPaginedAsync(filter, dbQueryOptions, cancellationToken);

            if (!result.Sucess)
                return result;

            foreach (var lineTime in result.Value!.Items)
            {
                lineTime.DayTypeName = ((DayType)lineTime.DayType).ToString().Localize();
                lineTime.LineDirectionTypeName = ((DirectionType)lineTime.LineDirectionType).ToString().Localize();
            }

            return result;
        }

        public async override Task<Result<ReadLineTimeDTO>> GetByIdAsync(
            long id, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetByIdAsync(id, dbQueryOptions, cancellationToken);

            if (!result.Sucess)
                return result;

            var lineTime = result.Value!;
            lineTime.DayTypeName = ((DayType)lineTime.DayType).ToString().Localize();
            lineTime.LineDirectionTypeName = ((DirectionType)lineTime.LineDirectionType).ToString().Localize();

            return result;
        }

        protected override void UpdateFields(LineTime entity, UpdateLineTimeDTO updateDTO)
        {
            entity.Time = updateDTO.Time;
            entity.DayType = updateDTO.DayType;
        }
    }
}
