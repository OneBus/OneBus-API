using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Employee;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Funcionários")]
    public class EmployeeController : BaseController<Employee, CreateEmployeeDTO, ReadEmployeeDTO, UpdateEmployeeDTO, BaseFilter>
    {
        public EmployeeController(
            IBaseService<Employee, CreateEmployeeDTO, ReadEmployeeDTO, UpdateEmployeeDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar novo funcionário 
        /// </summary>
        /// <remarks>
        /// POST de Funcionário
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionário cadastrado</returns>
        /// <response code="200">Funcionário cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadEmployeeDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateEmployeeDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar funcionário 
        /// </summary>
        /// <remarks>
        /// PUT de Funcionário
        /// </remarks>
        /// <param name="id">Id do funcionário</param>
        /// <param name="updateDTO">Campos para atualizar funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionário atualizado</returns>
        /// <response code="200">Funcionário atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Funcionário não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadEmployeeDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadEmployeeDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadEmployeeDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateEmployeeDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }        

        /// <summary>
        /// Deletar funcionário
        /// </summary>
        /// <remarks>
        /// DELETE de Funcionário 
        /// </remarks>
        /// <param name="id">Id do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionário deletado</returns>
        /// <response code="200">Funcionário deletado com sucesso</response>
        /// <response code="404">Funcionário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DeleteAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter funcionários paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Funcionários
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionários paginados e filtrados</returns>
        /// <response code="200">Funcionários paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadEmployeeDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter funcionário por id
        /// </summary>
        /// <remarks>
        /// GET pelo id do funcionário
        /// </remarks>
        /// <param name="id">Id do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Funcionário encontrado</returns>
        /// <response code="200">Funcionário encontrado com sucesso</response>
        /// <response code="404">Funcionário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadEmployeeDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
