﻿using FinServ.Application.UseCases.Produtos.CadastrarProdutos;
using FinServ.Application.UseCases.Produtos.ConsultarProdutoPorCodigo;
using FinServ.Application.UseCases.Produtos.ConsultarProdutosDisponiveis;
using FinServ.Application.UseCases.Produtos.EditarProduto;
using FinServ.Application.UseCases.Produtos.DeletarProdutoAsync;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProdutoController> _logger;
        private readonly IValidator<CadastrarProdutosRequest> _cadastrarProdutosFinanceirosValidator;

        public ProdutoController(IMediator mediator, ILogger<ProdutoController> logger, IValidator<CadastrarProdutosRequest> cadastrarProdutosFinanceirosValidator)
        {
            _mediator = mediator;
            _logger = logger;
            _cadastrarProdutosFinanceirosValidator = cadastrarProdutosFinanceirosValidator;
        }

        [HttpPost("CadastrarProdutos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarProdutosAsync([FromBody] CadastrarProdutosRequest request)
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

            return Created(nameof(CadastrarProdutosAsync), response);
        }

        [HttpGet("ConsultarProdutoPorCodigo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterPorCodigoAsync([FromQuery] ConsultarProdutoPorCodigoRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("ConsultarProdutosDisponiveis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterProdutosDisponiveisAsync()
        {
            var request = new ConsultaProdutosDisponiveisRequest();

            var response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("EditarProduto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarProdutoAsync([FromBody] EditarProdutoRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.CodigoRetorno == StatusCodes.Status404NotFound)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("RemoverProduto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoverProdutoAsync([FromQuery] RemoverProdutoRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.CodigoRetorno == StatusCodes.Status404NotFound)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
