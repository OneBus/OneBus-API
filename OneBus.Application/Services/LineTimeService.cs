using FluentValidation;
using OneBus.Application.DTOs.LineTime;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class LineTimeService : BaseService<LineTime, CreateLineTimeDTO, ReadLineTimeDTO, UpdateLineTimeDTO, BaseFilter>,
        ILineTimeService
    {
        public LineTimeService(
            IBaseRepository<LineTime, BaseFilter> baseRepository, 
            IValidator<CreateLineTimeDTO> createValidator, 
            IValidator<UpdateLineTimeDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
