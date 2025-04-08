using FluentValidation;
using OneBus.Application.DTOs.LineTariff;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using OneBus.Domain.Interfaces.Repositories;

namespace OneBus.Application.Services
{
    public class LineTariffService : BaseService<LineTariff, CreateLineTariffDTO, ReadLineTariffDTO, UpdateLineTariffDTO, BaseFilter>,
        ILineTariffService
    {
        public LineTariffService(
            IBaseRepository<LineTariff, BaseFilter> baseRepository, 
            IValidator<CreateLineTariffDTO> createValidator, 
            IValidator<UpdateLineTariffDTO> updateValidator) 
            : base(baseRepository, createValidator, updateValidator)
        {
        }
    }
}
