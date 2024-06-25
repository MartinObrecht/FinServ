using FinServ.Application.Handlers.Clientes.BuyAtivo;
using FinServ.Application.Handlers.Clientes.CreateCliente;
using FinServ.Application.Handlers.Clientes.GetAtivos;
using FinServ.Application.Handlers.Clientes.SellAtivo;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClientesController> _logger;
        private readonly IValidator<CreateClienteRequest> _createClienteValidator;
        private readonly IValidator<BuyAtivoRequest> _buyAtivoRequestValidator;

        public ClientesController(IMediator mediator, ILogger<ClientesController> logger, IValidator<CreateClienteRequest> cadastrarClienteValidator, IValidator<BuyAtivoRequest> buyAtivoRequestValidator)
        {
            _mediator = mediator;
            _logger = logger;
            _createClienteValidator = cadastrarClienteValidator;
            _buyAtivoRequestValidator = buyAtivoRequestValidator;
        }

        [HttpPost("Registrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateClienteRequest request)
        {
            var validationResult = _createClienteValidator.ValidateAsync(request);

            if (!validationResult.IsCompletedSuccessfully)
            {
                return BadRequest(validationResult.Result);
            }

            var response = await _mediator.Send(request);

            switch (response.CodigoRetorno)
            {
                case StatusCodes.Status400BadRequest:
                    return BadRequest(response);
                case StatusCodes.Status409Conflict:
                    return Conflict(response);
                case StatusCodes.Status500InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Created(nameof(CreateAsync), response);
        }

        [HttpPost("ComprarAtivo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuyAtivoAsync([FromBody] BuyAtivoRequest request)
        {
            var validationResult = _buyAtivoRequestValidator.ValidateAsync(request);
            if (!validationResult.IsCompletedSuccessfully)
            {
                return BadRequest(validationResult.Result);
            }

            var response = await _mediator.Send(request);

            switch (response.CodigoRetorno)
            {
                case StatusCodes.Status400BadRequest:
                    return BadRequest(response);
                case StatusCodes.Status404NotFound:
                    return NotFound(response);
                case StatusCodes.Status500InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Created(nameof(BuyAtivoAsync), response);
        }

        [HttpDelete("VenderAtivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SellAtivoAsync([FromQuery] SellAtivoRequest request)
        {
            var response = await _mediator.Send(request);

            switch (response.CodigoRetorno)
            {
                case StatusCodes.Status400BadRequest:
                    return BadRequest(response);
                case StatusCodes.Status404NotFound:
                    return NotFound(response);
                case StatusCodes.Status500InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }

        [HttpGet("ExtratoAtivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAtivosResponse>>> GetByClienteAsync([FromQuery] GetAtivosRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.Any())
            {
                return NotFound();
            }
            return Ok(response);

        }
    }
}
