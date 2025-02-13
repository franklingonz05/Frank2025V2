using CreditCard.Core.Application.Features.CreditCard.Queries.GetAll;
using CreditCard.Core.Application.Features.Transaction.Queries.GetbyClient;
using CreditCard.Core.Domain.Commons;
using CreditCard.Core.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard.Api.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con tarjetas de crédito.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="CreditCardController"/>.
        /// </summary>
        /// <param name="mediator">Interfaz de Mediator para manejar solicitudes de CQRS.</param>
        public CreditCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene la lista de todas las tarjetas de crédito registradas.
        /// </summary>
        /// <returns>Una colección de tarjetas de crédito.</returns>
        /// <response code="200">Devuelve la lista de tarjetas de crédito.</response>
        /// <response code="404">No se encontraron tarjetas de crédito registradas.</response>
        /// <response code="500">Ocurrió un error inesperado en el servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<IEnumerable<CreditCardDTO>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BaseResponse<IEnumerable<CreditCardDTO>>>> Get()
        {
            var result = await _mediator.Send(new GetCreditCardAllQuery());
            return Ok(result);
        }
    }
}
