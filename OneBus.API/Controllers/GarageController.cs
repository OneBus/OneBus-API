using Microsoft.AspNetCore.Mvc;
using OneBus.Application.DTOs.Garage;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons;
using OneBus.Domain.Commons.Result;
using OneBus.Domain.Entities;
using OneBus.Domain.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [SwaggerTag("Controlador responsável por gerenciar Garagens")]
    public class GarageController : BaseController<Garage, CreateGarageDTO, ReadGarageDTO, UpdateGarageDTO, BaseFilter>
    {
        public GarageController(
            IBaseService<Garage, CreateGarageDTO, ReadGarageDTO, UpdateGarageDTO, BaseFilter> baseService) 
            : base(baseService)
        {
        }

        /// <summary>
        /// Cadastrar nova garagem 
        /// </summary>
        /// <remarks>
        /// POST de Garagem
        /// </remarks>
        /// <param name="createDTO">Campos para cadastrar garagem</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem cadastrada</returns>
        /// <response code="200">Garagem cadastrada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        [ProducesResponseType(typeof(SuccessResult<ReadGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadGarageDTO>), StatusCodes.Status422UnprocessableEntity)]
        public override Task<IActionResult> CreateAsync([FromBody] CreateGarageDTO createDTO, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(createDTO, cancellationToken);
        }

        /// <summary>
        /// Atualizar garagem 
        /// </summary>
        /// <remarks>
        /// PUT de Garagem
        /// </remarks>
        /// <param name="id">Id da garagem</param>
        /// <param name="updateDTO">Campos para atualizar garagem</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem atualizada</returns>
        /// <response code="200">Garagem atualizada com sucesso</response>
        /// <response code="422">Validação encontrou erros</response>
        /// <response code="404">Garagem não encontrada</response>
        /// <response code="409">Conflito entre ids</response>
        [ProducesResponseType(typeof(SuccessResult<ReadGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InvalidResult<ReadGarageDTO>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(NotFoundResult<ReadGarageDTO>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ConflictResult<ReadGarageDTO>), StatusCodes.Status409Conflict)]
        public override Task<IActionResult> UpdateAsync([FromRoute] ulong id, [FromBody] UpdateGarageDTO updateDTO, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, updateDTO, cancellationToken);
        }        

        /// <summary>
        /// Deletar garagem
        /// </summary>
        /// <remarks>
        /// DELETE de Garagem 
        /// </remarks>
        /// <param name="id">Id da garagem</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem deletada</returns>
        /// <response code="200">Garagem deletada com sucesso</response>
        /// <response code="404">Garagem não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<bool>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> DeleteAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Obter garagens paginadas e filtradas
        /// </summary>
        /// <remarks>
        /// GET de Garagens
        /// </remarks>
        /// <param name="filter">Filtros para aplicar</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagens paginadas e filtradas</returns>
        /// <response code="200">Garagens paginadas e filtradas com sucesso</response>
        [ProducesResponseType(typeof(SuccessResult<Pagination<ReadGarageDTO>>), StatusCodes.Status200OK)]
        public override Task<IActionResult> GetPaginedAsync([FromQuery] BaseFilter filter, CancellationToken cancellationToken = default)
        {
            return base.GetPaginedAsync(filter, cancellationToken);
        }

        /// <summary>
        /// Obter garagem por id
        /// </summary>
        /// <remarks>
        /// GET pelo id da garagem
        /// </remarks>
        /// <param name="id">Id da garagem</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Garagem encontrada</returns>
        /// <response code="200">Garagem encontrada com sucesso</response>
        /// <response code="404">Garagem não encontrada</response>
        [ProducesResponseType(typeof(SuccessResult<ReadGarageDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(NotFoundResult<ReadGarageDTO>), StatusCodes.Status404NotFound)]
        public override Task<IActionResult> GetByIdAsync([FromRoute] ulong id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }
    }
}
