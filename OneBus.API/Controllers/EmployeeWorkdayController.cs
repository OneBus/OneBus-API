using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.EmployeeWorkday;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Horários dos Funcionários")]
    public class EmployeeWorkdayController : BaseController<EmployeeWorkday, CreateEmployeeWorkdayDTO, ReadEmployeeWorkdayDTO, UpdateEmployeeWorkdayDTO, BaseFilter>
    {
        public EmployeeWorkdayController(
            IBaseService<EmployeeWorkday, CreateEmployeeWorkdayDTO, ReadEmployeeWorkdayDTO, UpdateEmployeeWorkdayDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar novo horário do funcionário 
        /// </summary>
        /// <remarks>
        /// POST de Horário do Funcionário
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar horário do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário do Funcionário cadastrado</returns>
        /// <response code="200">Horário do Funcionário cadastrado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeWorkdayDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadEmployeeWorkdayDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateEmployeeWorkdayDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar horário do funcionário 
        /// </summary>
        /// <remarks>
        /// PUT de Horário do Funcionário
        /// </remarks>
        /// <param name="id">Id do horário do funcionário</param>
        /// <param name="updateDTO">Campos para atualizar horário do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário do Funcionário atualizado</returns>
        /// <response code="200">Horário do Funcionário atualizado com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Horário do Funcionário não encontrado</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeWorkdayDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadEmployeeWorkdayDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadEmployeeWorkdayDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadEmployeeWorkdayDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] long id, [FromBody] UpdateEmployeeWorkdayDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }

        /// <summary>
        /// Deletar horário do funcionário
        /// </summary>
        /// <remarks>
        /// DELETE de Horário do Funcionário 
        /// </remarks>
        /// <param name="id">Id do horário do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário do Funcionário deletado</returns>
        /// <response code="200">Horário do Funcionário deletado com sucesso</response>
        /// <response code="404">Horário do Funcionário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter horários dos funcionários paginados e filtrados
        /// </summary>
        /// <remarks>
        /// GET de Horários dos Funcionários
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horários dos Funcionários paginados e filtrados</returns>
        /// <response code="200">Horários dos Funcionários paginados e filtrados com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadEmployeeWorkdayDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter horário do funcionário por id
        /// </summary>
        /// <remarks>
        /// GET pelo id do horário do funcionário
        /// </remarks>
        /// <param name="id">Id do horário do funcionário</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Horário do Funcionário encontrado</returns>
        /// <response code="200">Horário do Funcionário encontrado com sucesso</response>
        /// <response code="404">Horário do Funcionário não encontrado</response>
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeWorkdayDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadEmployeeWorkdayDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
