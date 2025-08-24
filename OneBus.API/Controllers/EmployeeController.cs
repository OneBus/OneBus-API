using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs.Employee;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [NonController]
    [Route("api/v1/employees")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [SwaggerTag("Controlador responsável por gerenciar Funcionários")]
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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
        [HttpPost]
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadEmployeeDTO>), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEmployeeDTO createDTO, CancellationToken cancellationToken = default)
        {
            return (await _employeeService.CreateAsync(createDTO, cancellationToken)).ToActionResult();
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
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadEmployeeDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadEmployeeDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadEmployeeDTO>), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UpdateEmployeeDTO updateDTO, CancellationToken cancellationToken = default)
        {
            if (id != updateDTO.Id)
                return ConflictResult<ReadEmployeeDTO>.Create(ErrorUtils.IdConflict()).ToActionResult();

            return (await _employeeService.UpdateAsync(updateDTO, cancellationToken)).ToActionResult();
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
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _employeeService.DeleteAsync(id, cancellationToken)).ToActionResult();
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
        [HttpGet]
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadEmployeeDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return (await _employeeService.GetPaginedAsync(filter, cancellationToken)).ToActionResult();
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
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadEmployeeDTO>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return (await _employeeService.GetByIdAsync(id, cancellationToken)).ToActionResult();
        }
    }
}
