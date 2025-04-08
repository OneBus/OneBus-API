using Ardalis.Result;
using Mapster;
using OneBus.Application.DTOs;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public abstract class BaseReadOnlyService<TEntity, TReadDTO, TFilter> : IBaseReadOnlyService<TEntity, TReadDTO, TFilter>
        where TEntity  : BaseEntity
        where TReadDTO : BaseReadDTO
        where TFilter  : BaseFilter
    {
        protected readonly IBaseReadOnlyRepository<TEntity, TFilter> _baseReadOnlyRepository;

        protected BaseReadOnlyService(IBaseReadOnlyRepository<TEntity, TFilter> baseReadOnlyRepository)
        {
            _baseReadOnlyRepository = baseReadOnlyRepository;
        }

        public virtual async Task<Result<Pagination<TReadDTO>>> GetPaginedAsync(
            TFilter filter,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            ulong totalItems = await _baseReadOnlyRepository.LongCountAsync(filter, dbQueryOptions, cancellationToken);

            if (totalItems < 1)
                return Result.Success(new Pagination<TReadDTO>(items: [], totalItems, filter.CurrentPage, filter.PageSize));

            IEnumerable<TEntity> entities = await _baseReadOnlyRepository.GetPaginedAsync(filter, dbQueryOptions, cancellationToken);

            IEnumerable<TReadDTO> entitiesDTO = entities.Adapt<IEnumerable<TReadDTO>>();

            return Result.Success(new Pagination<TReadDTO>(entitiesDTO, totalItems, filter.CurrentPage, filter.PageSize));
        }

        public virtual async Task<Result<TReadDTO>> GetByIdAsync(
            ulong id,
            DbQueryOptions? dbQueryOptions = null,
            CancellationToken cancellationToken = default)
        {
            TEntity? entity = await _baseReadOnlyRepository.GetOneAsync(c => c.Id == id, dbQueryOptions, cancellationToken);

            if (entity is null)
                return Result.NotFound();

            return entity.Adapt<TReadDTO>();
        }
    }
}
