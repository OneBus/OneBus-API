using Mapster;
using Ardalis.Result;
using FluentValidation;
using OneBus.Domain.Filters;
using OneBus.Domain.Entities;
using OneBus.Application.DTOs;
using FluentValidation.Results;
using Ardalis.Result.FluentValidation;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Application.Interfaces.Services;

namespace OneBus.Application.Services
{
    public abstract class BaseService<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter> : BaseReadOnlyService<TEntity, TReadDTO, TFilter>,
        IBaseService<TEntity, TCreateDTO, TReadDTO, TUpdateDTO, TFilter>
        where TEntity    : BaseEntity
        where TCreateDTO : BaseCreateDTO
        where TReadDTO   : BaseReadDTO
        where TUpdateDTO : BaseUpdateDTO
        where TFilter    : BaseFilter
    {
        protected readonly IBaseRepository<TEntity, TFilter> _baseRepository;
        protected readonly IValidator<TCreateDTO> _createValidator;
        protected readonly IValidator<TUpdateDTO> _updateValidator;

        protected BaseService(
            IBaseRepository<TEntity, TFilter> baseRepository,
            IValidator<TCreateDTO> createValidator,
            IValidator<TUpdateDTO> updateValidator) : base(baseRepository)
        {
            _baseRepository = baseRepository;           
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public virtual async Task<Result<TReadDTO>> CreateAsync(TCreateDTO createDTO, CancellationToken cancellationToken = default)
        {
            ValidationResult validation = await _createValidator.ValidateAsync(createDTO, cancellationToken);

            if (!validation.IsValid)
                return Result.Invalid(validation.AsErrors());

            TEntity entity = createDTO.Adapt<TEntity>();
            entity = await _baseRepository.CreateAsync(entity, cancellationToken);

            return Result.Success(entity.Adapt<TReadDTO>());
        }

        public virtual async Task<Result<TReadDTO>> UpdateAsync(TUpdateDTO updateDTO, CancellationToken cancellationToken = default)
        {
            ValidationResult validation = await _updateValidator.ValidateAsync(updateDTO, cancellationToken);

            if (!validation.IsValid)
                return Result.Invalid(validation.AsErrors());

            TEntity entity = updateDTO.Adapt<TEntity>();
            entity = await _baseRepository.UpdateAsync(entity, cancellationToken);

            return Result.Success(entity.Adapt<TReadDTO>());
        }
        
        public virtual async Task<Result<bool>> DisableAsync(ulong id, CancellationToken cancellationToken = default)
        {
            TEntity? entity = await _baseReadOnlyRepository.GetOneAsync(c => c.Id == id, dbQueryOptions: null, cancellationToken);

            if (entity is null)
                return Result.NotFound();

            entity.Disable();
            await _baseRepository.UpdateAsync(entity, cancellationToken);

            return Result.Success();
        }

        public virtual async Task<Result<bool>> EnableAsync(ulong id, CancellationToken cancellationToken = default)
        {
            //To enable an entity the query filter need to be ignored
            TEntity? entity = await _baseReadOnlyRepository.GetOneAsync(c => c.Id == id && c.DeletedAt != null, 
                new(ignoreQueryFilter: true), 
                cancellationToken);

            if (entity is null)
                return Result.NotFound();

            entity.Enable();
            await _baseRepository.UpdateAsync(entity, cancellationToken);

            return Result.Success();
        }
    }
}
