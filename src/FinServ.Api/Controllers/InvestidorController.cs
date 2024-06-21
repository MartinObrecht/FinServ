using FinServ.Application.UseCases.Investidores.CadastrarInvestidor;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestidorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<InvestidorController> _logger;
        private readonly IValidator<CadastrarInvestidorRequest> _cadastrarClienteValidator;

        public InvestidorController(IMediator mediator, ILogger<InvestidorController> logger, IValidator<CadastrarInvestidorRequest> cadastrarClienteValidator)
        {
            _mediator = mediator;
            _logger = logger;
            _cadastrarClienteValidator = cadastrarClienteValidator;
        }

        [HttpPost("CadastrarInvestidor")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarInvestidorAsync([FromBody] CadastrarInvestidorRequest request)
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

            return Created(nameof(CadastrarInvestidorAsync), response);
        }
    }
}
