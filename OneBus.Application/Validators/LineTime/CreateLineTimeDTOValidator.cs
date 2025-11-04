using FluentValidation;
using OneBus.Application.DTOs.LineTime;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.LineTime
{
    public class CreateLineTimeDTOValidator : AbstractValidator<CreateLineTimeDTO>
    {
        private readonly ILineRepository _lineRepository;

        const string LineIdPropertyName = "Id da Linha";

        public CreateLineTimeDTOValidator(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;

            RuleFor(c => c.LineId).GreaterThan(0)
               .OverridePropertyName(LineIdPropertyName);

            RuleFor(c => c.LineId)
                .MustAsync(ExistsAsync)
                .WithMessage(ErrorUtils.EntityNotFound(LineIdPropertyName).Message)
                .OverridePropertyName(LineIdPropertyName);           

            RuleFor(c => c.DayType).Must(ValidationUtils.IsValidEnumValue<DayType>)
              .OverridePropertyName("Dia da Semana");
        }

        private async Task<bool> ExistsAsync(long lineId, CancellationToken ct = default)
        {
            return await _lineRepository.AnyAsync(c => c.Id == lineId, cancellationToken: ct);
        }
    }
}
