using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Company;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Empresas")]
    public class CompanyController : BaseController<Company, CreateCompanyDTO, ReadCompanyDTO, UpdateCompanyDTO, BaseFilter>
    {
        public CompanyController(
            IBaseService<Company, CreateCompanyDTO, ReadCompanyDTO, UpdateCompanyDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova empresa 
        /// </summary>
        /// <remarks>
        /// POST de Empresa
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar empresa</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Empresa cadastrada</returns>
        /// <response code="200">Empresa cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadCompanyDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadCompanyDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateCompanyDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar empresa 
        /// </summary>
        /// <remarks>
        /// PUT de Empresa
        /// </remarks>
        /// <param name="id">Id da empresa</param>
        /// <param name="updateDTO">Campos para atualizar empresa</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Empresa atualizada</returns>
        /// <response code="200">Empresa atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Empresa não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadCompanyDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadCompanyDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadCompanyDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadCompanyDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateCompanyDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar empresa 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar empresa 
        /// </remarks>
        /// <param name="id">Id da empresa</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Empresa habilitada</returns>
        /// <response code="200">Empresa habilitada com sucesso</response>
        /// <response code="404">Empresa não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar empresa
        /// </summary>
        /// <remarks>
        /// DELETE de Empresa 
        /// </remarks>
        /// <param name="id">Id da empresa</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Empresa deletada</returns>
        /// <response code="200">Empresa deletada com sucesso</response>
        /// <response code="404">Empresa não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter empresas paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Empresas
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Empresas paginadas e filtradas</returns>
        /// <response code="200">Empresas paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadCompanyDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter empresa por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da empresa
        /// </remarks>
        /// <param name="id">Id da empresa</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Empresa encontrada</returns>
        /// <response code="200">Empresa encontrada com sucesso</response>
        /// <response code="404">Empresa não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadCompanyDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadCompanyDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
