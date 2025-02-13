using CreditCard.Core.Application.Features.Transaction.Commands.CreateTransactionCommand;
using CreditCard.Core.Application.Features.Transaction.Queries.GetbyClient;
using CreditCard.Core.Domain.Commons;
using CreditCard.Core.Domain.Dtos;
using CreditCard.Core.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con las transacciones de tarjetas de crédito.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="TransactionController"/>.
        /// </summary>
        /// <param name="mediator">Interfaz de Mediator para manejar solicitudes de CQRS.</param>
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Crea una nueva transacción para una tarjeta de crédito.
        /// </summary>
        /// <param name="command">Comando con la información de la transacción a crear.</param>
        /// <returns>Resultado de la creación de la transacción.</returns>
        /// <response code="200">Transacción creada exitosamente.</response>
        /// <response code="400">Solicitud inválida.</response>
        /// <response code="500">Ocurrió un error inesperado en el servidor.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<int>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(CreateTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene las transacciones del mes actual por número de tarjeta.
        /// </summary>
        /// <param name="cardNumber">Número de la tarjeta de crédito.</param>
        /// <returns>Lista de transacciones.</returns>
        /// <response code="200">Lista de transacciones recuperada exitosamente.</response>
        /// <response code="404">No se encontraron transacciones para la tarjeta proporcionada.</response>
        /// <response code="500">Ocurrió un error inesperado en el servidor.</response>
        [HttpGet("ByCard")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<IEnumerable<TransactionDTOList>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TransactionView>>> GetTransactionsByCard([FromQuery] GetTransactionByQuery consulta)
        {
            var result = await _mediator.Send(consulta);
            return Ok(result);
        }
    }
}