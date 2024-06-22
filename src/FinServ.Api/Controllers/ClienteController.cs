using FinServ.Application.UseCases.Clientes.CreateCliente;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClienteController> _logger;
        private readonly IValidator<CreateClienteRequest> _cadastrarClienteValidator;

        public ClienteController(IMediator mediator, ILogger<ClienteController> logger, IValidator<CreateClienteRequest> cadastrarClienteValidator)
        {
            _mediator = mediator;
            _logger = logger;
            _cadastrarClienteValidator = cadastrarClienteValidator;
        }

        [HttpPost("CreateCliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateClinteAsync([FromBody] CreateClienteRequest request)
        {
            var validationResult = _cadastrarClienteValidator.ValidateAsync(request);

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

            return Created(nameof(CreateClinteAsync), response);
        }
    }
}
