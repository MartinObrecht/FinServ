using FinServ.Application.UseCases.Produtos.CadastrarProdutosFinanceiros;
using FinServ.Application.UseCases.Produtos.ExtratoProdutosFinanceiros;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoFinanceiroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProdutoFinanceiroController> _logger;
        private readonly IValidator<CadastrarProdutosFinanceirosRequest> _cadastrarProdutosFinanceirosValidator;

        public ProdutoFinanceiroController(IMediator mediator, ILogger<ProdutoFinanceiroController> logger, IValidator<CadastrarProdutosFinanceirosRequest> cadastrarProdutosFinanceirosValidator)
        {
            _mediator = mediator;
            _logger = logger;
            _cadastrarProdutosFinanceirosValidator = cadastrarProdutosFinanceirosValidator;
        }

        [HttpPost("CadastrarProdutosFinanceiros")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarProdutosFinanceirosAsync([FromBody] CadastrarProdutosFinanceirosRequest request)
        {
            var validationResult = _cadastrarProdutosFinanceirosValidator.ValidateAsync(request);

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

            return Created(nameof(CadastrarProdutosFinanceirosAsync), response);
        }

        [HttpGet("ExtratoProdutosFinanceiros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExtratoProdutosFinanceirosAsync([FromQuery] ExtratoProdutosFinanceirosRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
