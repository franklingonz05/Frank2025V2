using CreditCard.Core.Application.Features.AccountStatements.Queries.GetById;
using CreditCard.Core.Domain.Commons;
using CreditCard.Core.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con los estados de cuenta.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountStatementController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="AccountStatementController"/>.
        /// </summary>
        /// <param name="mediator">Interfaz de Mediator para manejar solicitudes de CQRS.</param>
        public AccountStatementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene el estado de cuenta de una tarjeta de crédito específica.
        /// </summary>
        /// <param name="consulta">Consulta que contiene el identificador del estado de cuenta.</param>
        /// <returns>El estado de cuenta correspondiente.</returns>
        /// <response code="200">Devuelve el estado de cuenta solicitado.</response>
        /// <response code="404">No se encontró el estado de cuenta solicitado.</response>
        /// <response code="500">Ocurrió un error inesperado en el servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<AccountStatementDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountStatements([FromQuery] GetAccountStatementByIdQuery consulta)
        {
            var result = await _mediator.Send(consulta);
            return Ok(result);
        }
    }
}
