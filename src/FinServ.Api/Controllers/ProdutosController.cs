﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FinServ.Application.Handlers.Produtos.CreateProdutos;
using FinServ.Application.Handlers.Produtos.DeleteProduct;
using FinServ.Application.Handlers.Produtos.QueryProdutoByCodigo;
using FinServ.Application.Handlers.Produtos.UpdateProduto;
using FinServ.Application.Handlers.Produtos.QueryAvailableProdutos;

namespace FinServ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProdutosController> _logger;
        private readonly IValidator<CreateProdutosRequest> _createProdutoRequesrValidator;


        public ProdutosController(IMediator mediator, ILogger<ProdutosController> logger, IValidator<CreateProdutosRequest> cadastrarProdutosFinanceirosValidator)
        {
            _mediator = mediator;
            _logger = logger;
            _createProdutoRequesrValidator = cadastrarProdutosFinanceirosValidator;
        }

        [HttpPost("Registrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] CreateProdutosRequest request)
        {
            var validationResult = _createProdutoRequesrValidator.ValidateAsync(request);

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

            return Created(nameof(AddAsync), response);
        }

        [HttpGet("Obter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCodigoAsync([FromQuery] QueryProdutoByCodigoRequest request)
        {
            var response = await _mediator.Send(request);

            switch (response.CodigoRetorno)
            {
                case StatusCodes.Status404NotFound:
                    return NotFound(response);
                case StatusCodes.Status500InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }

        [HttpGet("Disponiveis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAvailableAsync()
        {
            var request = new QueryAvailableProdutosRequest();

            var response = await _mediator.Send(request);

            if (response.Count == 0)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPut("Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProdutoRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.CodigoRetorno == StatusCodes.Status404NotFound)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("Remover")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromQuery] DeleteProdutoRequest request)
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
