using FluentValidation;
using OneBus.Application.DTOs.Line;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class LineService : BaseService<Line, CreateLineDTO, ReadLineDTO, UpdateLineDTO, BaseFilter>,
        ILineService
    {
        public LineService(
            IBaseRepository<Line, BaseFilter> baseRepository, 
            IValidator<CreateLineDTO> createValidator, 
            IValidator<UpdateLineDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
