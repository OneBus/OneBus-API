using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneBus.API.Extensions;
using OneBus.Application.DTOs.Dashboard;
using OneBus.Application.Interfaces.Services;
using OneBus.Domain.Commons.Result;
using Swashbuckle.AspNetCore.Annotations;

namespace OneBus.API.Controllers
{
    [Route("api/v1/dashboards")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    [SwaggerTag("Controlador responsável por listar Dashboards")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        /// <summary>
        /// Obter status dos funcionários
        /// </summary>
        /// <remarks>
        /// GET de status dos funcionários
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <returns>Status dos funcionários categorizados</returns>
        /// <response code="200">Status dos funcionários categorizados com sucesso</response>
        [HttpGet("employees")]
        [ProducesResponseType(typeof(SuccessResult<ReadEmployeeTotalCountDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployeeStatusAsync(CancellationToken cancellationToken = default)
        {
            return (await _dashboardService.GetEmployeeStatusAsync(cancellationToken)).ToActionResult();
        }

        /// <summary>
        /// Obter status dos veículos
        /// </summary>
        /// <remarks>
        /// GET de status dos veículos
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <returns>Status dos veículos categorizados</returns>
        /// <response code="200">Status dos veículos categorizados com sucesso</response>
        [HttpGet("vehicles")]
        [ProducesResponseType(typeof(SuccessResult<ReadVehicleTotalCountDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehicleStatusAsync(CancellationToken cancellationToken = default)
        {
            return (await _dashboardService.GetVehicleStatusAsync(cancellationToken)).ToActionResult();
        }
    }
}
