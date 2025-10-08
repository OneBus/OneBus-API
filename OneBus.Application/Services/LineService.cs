using FluentValidation;
using OneBus.Application.DTOs.Line;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Enums.Line;
using OneBus.Domain.Extensions;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class LineService : BaseService<Line, CreateLineDTO, ReadLineDTO, UpdateLineDTO, LineFilter>,
        ILineService
    {
        public LineService(
            IBaseRepository<Line, LineFilter> baseRepository, 
            IValidator<CreateLineDTO> createValidator, 
            IValidator<UpdateLineDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }

        public override async Task<Result<Pagination<ReadLineDTO>>> GetPaginedAsync(
            LineFilter filter, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetPaginedAsync(filter, cancellationToken: cancellationToken);

            if (!result.Sucess)
                return result;

            foreach (var line in result.Value!.Items)
            {
                line.TypeName = ((LineType)line.Type).ToString().Localize();
                line.DirectionTypeName = ((DirectionType)line.DirectionType).ToString().Localize();
            }

            return result;
        }

        public override async Task<Result<ReadLineDTO>> GetByIdAsync(
            long id, 
            DbQueryOptions? dbQueryOptions = null, 
            CancellationToken cancellationToken = default)
        {
            var result = await base.GetByIdAsync(id, cancellationToken: cancellationToken);

            if (!result.Sucess)
                return result;

            var line = result.Value!;
            line.TypeName = ((LineType)line.Type).ToString().Localize();
            line.DirectionTypeName = ((DirectionType)line.DirectionType).ToString().Localize();

            return result;
        }

        public Result<IEnumerable<ReadLineTypeDTO>> GetLineTypes()
        {
            var values = Enum.GetValues<LineType>();

            List<ReadLineTypeDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadLineTypeDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadLineTypeDTO>>.Create(status);
        }

        public Result<IEnumerable<ReadDirectionTypeDTO>> GetDirectionTypes()
        {
            var values = Enum.GetValues<DirectionType>();

            List<ReadDirectionTypeDTO> status = [];

            foreach (var value in values)
            {
                status.Add(new ReadDirectionTypeDTO { Value = (byte)value, Name = value.ToString().Localize() });
            }

            return SuccessResult<IEnumerable<ReadDirectionTypeDTO>>.Create(status);
        }

        protected override void UpdateFields(Line entity, UpdateLineDTO updateDTO)
        {
            entity.Name = updateDTO.Name;
            entity.Number = updateDTO.Number;
            entity.Mileage = updateDTO.Mileage;
            entity.TravelTime = updateDTO.TravelTime;
            entity.DirectionType = updateDTO.DirectionType;
        }
    }
}
