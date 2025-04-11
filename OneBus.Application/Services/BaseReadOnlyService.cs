using Mapster;
using OneBus.Application.DTOs;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public abstract class BaseReadOnlyService<TEntity, TReadDTO, TFilter> : IBaseReadOnlyService<TEntity, TReadDTO, TFilter>
        where TEntity : BaseEntity
        where TReadDTO : BaseReadDTO
        where TFilter : BaseFilter
    {
        protected readonly IBaseReadOnlyRepository<TEntity, TFilter> _baseReadOnlyRepository;

        protected BaseReadOnlyService(IBaseReadOnlyRepository<TEntity, TFilter> baseReadOnlyRepository)
        {
            _baseReadOnlyRepository = baseReadOnlyRepository;
        }

        public virtual async Task<Result<Pagination<TReadDTO>>> GetPaginedAsync(
            TFilter filter,
            CancellationToken cancellationToken = default)
        {
            ulong totalItems = await _baseReadOnlyRepository.LongCountAsync(filter, dbQueryOptions: null, cancellationToken);

            if (totalItems < 1)
            {
                return SuccessResult<Pagination<TReadDTO>>
                    .Create(new Pagination<TReadDTO>(items: [], totalItems, filter.CurrentPage, filter.PageSize));
            }

            IEnumerable<TEntity> entities = await _baseReadOnlyRepository.GetPaginedAsync(filter, dbQueryOptions: null, cancellationToken);

            IEnumerable<TReadDTO> entitiesDTO = entities.Adapt<IEnumerable<TReadDTO>>();

            return SuccessResult<Pagination<TReadDTO>>
                .Create(new Pagination<TReadDTO>(entitiesDTO, totalItems, filter.CurrentPage, filter.PageSize));
        }

        public virtual async Task<Result<TReadDTO>> GetByIdAsync(
            ulong id,
            CancellationToken cancellationToken = default)
        {
            TEntity? entity = await _baseReadOnlyRepository.GetOneAsync(c => c.Id == id, dbQueryOptions: null, cancellationToken);

            if (entity is null)
                return NotFoundResult<TReadDTO>.Create();

            return SuccessResult<TReadDTO>.Create(entity.Adapt<TReadDTO>());
        }
    }
}
