using FluentValidation;
using OneBus.Application.DTOs.Line;
using OneBus.Domain.Commons;
using OneBus.Domain.Enums.Line;
using OneBus.Domain.Interfaces.Repositories;
using OneBus.Domain.Utils;

namespace OneBus.Application.Validators.Line
{
    public class CreateLineDTOValidator : AbstractValidator<CreateLineDTO>
    {
        private readonly ILineRepository _lineRepository;

        //TODO: Não deixar a mesma linha pode pode ter sentido de ida e volta, mas não de circular e
        //uma linha circular não pode ter outro cadastro com sentido de ida ou volta
        public CreateLineDTOValidator(ILineRepository lineRepository)
        {
            _lineRepository = lineRepository;

            RuleFor(c => c.Type)
               .Must(ValidationUtils.IsValidEnumValue<LineType>)
               .OverridePropertyName("Tipo");
            
            RuleFor(c => c.DirectionType)
               .Must(ValidationUtils.IsValidEnumValue<DirectionType>)
               .OverridePropertyName("Tipo de Direção");

            RuleFor(c => c.Number)
               .MustAsync(async (line, number, ct) => !await IsNumberInUse(number, line.Type, line.DirectionType, ct))
               .WithMessage(ErrorUtils.AlreadyExists("Número").Message)
               .NotEmpty()
               .OverridePropertyName("Número");

            RuleFor(c => c.Name)
                .NotEmpty()
                .OverridePropertyName("Nome");
        }

        private async Task<bool> IsNumberInUse(string number, byte type, byte directionType, CancellationToken cancellationToken = default)
        {
            return await _lineRepository.AnyAsync(c => c.Number.ToLower().Equals(number.ToLower()) && c.Type == type && c.DirectionType == directionType,
                cancellationToken: cancellationToken);
        }
    }
}
