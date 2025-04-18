using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.EmployeeGarage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Garagens dos Funcionários")]
    public class EmployeeGarageController : BaseController<EmployeeGarage, CreateEmployeeGarageDTO, ReadEmployeeGarageDTO, UpdateEmployeeGarageDTO, BaseFilter>
    {
        public EmployeeGarageController(
            IBaseService<EmployeeGarage, CreateEmployeeGarageDTO, ReadEmployeeGarageDTO, UpdateEmployeeGarageDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova garagem do funcionário 
        /// </summary>
        /// <remarks>
        /// POST de Garagem do Funcionário
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar garagem do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem do Funcionário cadastrada</returns>
        /// <response code="200">Garagem do Funcionário cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadEmployeeGarageDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateEmployeeGarageDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar garagem do funcionário 
        /// </summary>
        /// <remarks>
        /// PUT de Garagem do Funcionário
        /// </remarks>
        /// <param name="id">Id da garagem do funcionário</param>
        /// <param name="updateDTO">Campos para atualizar garagem do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem do Funcionário atualizada</returns>
        /// <response code="200">Garagem do Funcionário atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Garagem do Funcionário não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadEmployeeGarageDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadEmployeeGarageDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadEmployeeGarageDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateEmployeeGarageDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Habilitar garagem do funcionário 
        /// </summary>
        /// <remarks>
        /// PUT para habilitar garagem do funcionário 
        /// </remarks>
        /// <param name="id">Id da garagem do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem do Funcionário habilitada</returns>
        /// <response code="200">Garagem do Funcionário habilitada com sucesso</response>
        /// <response code="404">Garagem do Funcionário não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> EnableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.EnableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Desabilitar garagem do funcionário
        /// </summary>
        /// <remarks>
        /// DELETE de Garagem do Funcionário 
        /// </remarks>
        /// <param name="id">Id da garagem do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem do Funcionário deletada</returns>
        /// <response code="200">Garagem do Funcionário deletada com sucesso</response>
        /// <response code="404">Garagem do Funcionário não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DisableAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DisableAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter garagens dos funcionários paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Garagem do Funcionário
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagens dos Funcionários paginadas e filtradas</returns>
        /// <response code="200">Garagens dos Funcionários paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadEmployeeGarageDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter garagem do funcionário por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da garagem do funcionário
        /// </remarks>
        /// <param name="id">Id da garagem do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem do Funcionário encontrada</returns>
        /// <response code="200">Garagem do Funcionário encontrada com sucesso</response>
        /// <response code="404">Garagem do Funcionário não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadEmployeeGarageDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
